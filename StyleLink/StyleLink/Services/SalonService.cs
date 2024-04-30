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
    private readonly IHairStylistSalonServiceRepository _hairStylistSalonServiceRepository;
    private readonly IServiceRepository _serviceRepository;
    private readonly IHairStylistSalonRepository _hairStylistSalonRepository;
    private readonly IHairStylistRepository _hairStylistRepository;
    private readonly ISalonImageRepository _salonImageRepository;

    private readonly IImageConvertorService _imageConvertorService;

    public SalonService(
        ISalonRepository salonRepository,
        IHairStylistSalonRepository hairStylistSalonRepository,
        IHairStylistRepository hairStylistRepository,
        IImageConvertorService imageConvertorService,
        ISalonImageRepository salonImageRepository,
        IHairStylistSalonServiceRepository hairStylistSalonServiceRepository,
        IServiceRepository serviceRepository)
    {
        _salonRepository = salonRepository;
        _hairStylistSalonRepository = hairStylistSalonRepository;
        _hairStylistRepository = hairStylistRepository;
        _imageConvertorService = imageConvertorService;
        _salonImageRepository = salonImageRepository;
        _hairStylistSalonServiceRepository = hairStylistSalonServiceRepository;
        _serviceRepository = serviceRepository;
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
                ProfileImage = await _imageConvertorService.ConvertFormFileToImageAsync(profileImage),
                Images = await _imageConvertorService.ConvertFormFilesToImagesAsync(images),
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
                Currency = hsss.Currency,
                Id = hsss.Service.Id,
                MaxPrice = g.Value.Max(x => x.Price),
                MaxServiceDuration = new DateTime(g.Value.Max(x => x.Time.Ticks)),
                MinPrice = g.Value.Min(x => x.Price),
                MinServiceDuration = new DateTime(g.Value.Min(x => x.Time.Ticks)),
                ServiceCategory = hsss.Service.ServiceType.Name,
                ServiceName = g.Key,
            })).ToList();

        var hairStylists = new List<HairStylistModel>();

        foreach (var hss in salon.HairStylistSalons)
        {
            var hairStylistProfileImage =
                await _imageConvertorService.ConvertByteArrayToFileFormAsync(new ImageDto()
                {
                    FileName = hss.HairStylist.ProfileImageFileName,
                    Name = hss.HairStylist.ProfileImageName,
                    Content = hss.HairStylist.ProfileImage
                });
            hairStylists.Add(new HairStylistModel()
            {
                Id = hss.HairStylist.Id,
                Name = $"{hss.HairStylist.FirstName} {hss.HairStylist.LastName}",
                ProfileImage = await _imageConvertorService.ConvertFormFileToImageAsync(hairStylistProfileImage),
            });
        }
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
            Images = await _imageConvertorService.ConvertFormFilesToImagesAsync(images),
            MapsUrl = salon.GoogleMapsAddress,
            NumberOfEvaluations = salon.ReviewCount,
            ProfileImage = await _imageConvertorService.ConvertFormFileToImageAsync(profileImage),
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


        await AddSalonHairstylists(model, id);

        await AddSalonImagesAsync(model, id);
    }

    private async Task AddSalonHairstylists(AddSalonModel model, Guid id)
    {
        var salonRef = await _salonRepository.GetSalonAsync(id);
        var hairStylists = await _hairStylistRepository.GetHairStylistsAsync();
        var hairStylistSalons = await _hairStylistSalonRepository.GetHairStylistSalonsAsync();
        var services = await _serviceRepository.GetServicesAsync();
        foreach (var h in model.Hairstylists)
        {
            var hairStylistSalonId = Guid.NewGuid();

            var entity = new HairStylistSalon()
            {
                Id = hairStylistSalonId,
                Salon = salonRef,
                HairStylist = hairStylists.First(x => x.Id == Guid.Parse(h)),
            };
            await _hairStylistSalonRepository.CreateHairStylistSalonAsync(entity);

            var hairStylistSalon = hairStylistSalons.First(x => x.Id == hairStylistSalonId);

            var service = await _serviceRepository.GetServiceAsync(id);
            var hssService = new HairStylistSalonService()
            {
                HairStylistSalon = hairStylistSalon,
                Id = Guid.NewGuid(),
                Service = service
            };

            await _hairStylistSalonServiceRepository.CreateHairStylistSalonServiceAsync(hssService);
        }
    }

    private async Task AddSalonImagesAsync(AddSalonModel model, Guid id)
    {
        var salonRef = await _salonRepository.GetSalonAsync(id);

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