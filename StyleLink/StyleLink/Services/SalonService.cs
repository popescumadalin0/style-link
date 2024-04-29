using System;
using System.Collections.Generic;
using StyleLink.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayout.Models;
using StyleLink.Models;
using StyleLink.Services.Interfaces;

namespace StyleLink.Services;

public class SalonService : ISalonService
{
    private readonly ISalonRepository _salonRepository;
    private readonly IHairStylistSalonRepository _hairStylistSalonRepository;
    private readonly IHairStylistRepository _hairStylistRepository;
    private readonly ISalonImageRepository _salonImageRepository;

    private readonly IImageConvertorService _imageConvertorService;

    public SalonService(
        ISalonRepository salonRepository,
        IHairStylistSalonRepository hairStylistSalonRepository,
        IHairStylistRepository hairStylistRepository,
        IImageConvertorService imageConvertorService,
        ISalonImageRepository salonImageRepository)
    {
        _salonRepository = salonRepository;
        _hairStylistSalonRepository = hairStylistSalonRepository;
        _hairStylistRepository = hairStylistRepository;
        _imageConvertorService = imageConvertorService;
        _salonImageRepository = salonImageRepository;
    }

    public async Task<List<SalonModel>> GetSalonsAsync()
    {
        var salons = await _salonRepository.GetSalonsAsync();

        var salonsDto = new List<SalonModel>();
        foreach (var s in salons)
        {

            var profileImage = await _imageConvertorService.ConvertByteArrayToFileFormAsync(new ImageDto()
            {
                Name = s.ProfileImageName,
                Content = s.ProfileImage,
                FileName = s.ProfileImageFileName,
            });

            var images = await _imageConvertorService.ConvertByteArraysToFileFormsAsync(
                s.SalonImages
                    .Select(si =>
                        new ImageDto()
                        {
                            Content = si.Content,
                            Name = si.Name,
                            FileName = si.FileName
                        }).ToList());

            salonsDto.Add(new SalonModel()
            {
                Address = s.Address,
                Id = s.Id,
                SalonName = s.Name,
                ProfileImage = profileImage,
                Images = images,
                NumberOfEvaluations = s.ReviewCount,
                SalonRating = s.Rating,
            });
        }
        return salonsDto;
    }

    public async Task<SalonDetailModel> GetSalonDetailsAsync(Guid id)
    {
        var salon = await _salonRepository.GetSalonAsync(id);

        var servicesGroup =
            salon.HairStylistSalons?
                .SelectMany(hss => hss.HairStylistSalonServices
                    .GroupBy(hsss => hsss.Service.Name))
                .ToDictionary(k => k.Key, v => v.ToList());
        var services = servicesGroup
            .SelectMany(g => g.Value.Select(hsss => new ServiceModel()
            {
                Currency = hsss.Service.Currency,
                Id = hsss.Service.Id,
                MaxPrice = g.Value.Max(x => x.Service.Price),
                MaxServiceDuration = new DateTime(g.Value.Max(x => x.Service.Time.Ticks)),
                MinPrice = g.Value.Min(x => x.Service.Price),
                MinServiceDuration = new DateTime(g.Value.Min(x => x.Service.Time.Ticks)),
                ServiceCategory = hsss.Service.ServiceType.Name,
                ServiceName = g.Key,
            })).ToList();

        var hairStylists = new List<HairStylistModel>();

        var profileImage = await _imageConvertorService.ConvertByteArrayToFileFormAsync(new ImageDto()
        {
            Name = salon.ProfileImageName,
            Content = salon.ProfileImage,
            FileName = salon.ProfileImageFileName,
        });

        var images = await _imageConvertorService.ConvertByteArraysToFileFormsAsync(
            salon.SalonImages
                .Select(si =>
                    new ImageDto()
                    {
                        Content = si.Content,
                        Name = si.Name,
                        FileName = si.FileName
                    }).ToList());

        var salonDto = new SalonDetailModel()
        {
            Services = services,
            HairStylists = hairStylists,
            Id = salon.Id,
            SalonName = salon.Name,
            Images = images,
            MapsUrl = salon.GoogleMapsAddress,
            NumberOfEvaluations = salon.ReviewCount,
            ProfileImage = profileImage,
            SalonAddress = salon.Address,
            SalonRating = salon.Rating,
            TimeSchedule = new TimeSchedule()
            {
                Friday = salon.WorkProgram.Friday,
                Id = salon.WorkProgram.SalonId,
                Monday = salon.WorkProgram.Monday,
                Saturday = salon.WorkProgram.Saturday,
                Sunday = salon.WorkProgram.Sunday,
                Thursday = salon.WorkProgram.Thursday,
                Tuesday = salon.WorkProgram.Tuesday,
                Wednesday = salon.WorkProgram.Wednesday
            }
        };

        return salonDto;
    }

    public async Task AddSalonAsync(AddSalonModel model)
    {
        var id = Guid.NewGuid();
        var salon = new Salon()
        {
            Address = model.Address,
            GoogleMapsAddress = model.GoogleMapsAddress,
            Name = model.SalonName,
            Id = id,
            WorkProgram = new WorkProgram()
            {
                Monday = model.WorkProgram.Monday,
                Tuesday = model.WorkProgram.Tuesday,
                Wednesday = model.WorkProgram.Wednesday,
                Thursday = model.WorkProgram.Thursday,
                Friday = model.WorkProgram.Friday,
                Saturday = model.WorkProgram.Saturday,
                Sunday = model.WorkProgram.Sunday
            },
            ProfileImage = await _imageConvertorService.ConvertFileFormToByteArrayAsync(model.ProfileImage),
            ProfileImageFileName = model.ProfileImage.FileName,
            ProfileImageName = model.ProfileImage.Name,

        };
        await _salonRepository.CreateSalonAsync(salon);
        var salonRef = await _salonRepository.GetSalonAsync(id);

        foreach (var h in model.Hairstylists)
        {
            var entity = new HairStylistSalon()
            {
                Id = Guid.NewGuid(),
                Salon = salonRef,
                HairStylist = await _hairStylistRepository.GetHairStylistAsync(Guid.Parse(h))
            };
            await _hairStylistSalonRepository.CreateHairStylistSalonAsync(entity);
        }

        foreach (var i in model.Images)
        {
            var entity = new SalonImage()
            {
                Content = await _imageConvertorService.ConvertFileFormToByteArrayAsync(i),
                FileName = i.FileName,
                Id = Guid.NewGuid(),
                Name = i.Name,
                Salon = salonRef
            };

            await _salonImageRepository.CreateSalonImageAsync(entity);
        }
    }
}