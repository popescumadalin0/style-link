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
    private readonly IServiceRepository _serviceRepository;
    private readonly IHairStylistServiceRepository _hairStylistServiceRepository;
    private readonly IHairStylistRepository _hairStylistRepository;
    private readonly ISalonImageRepository _salonImageRepository;

    private readonly IImageConvertorService _imageConvertorService;

    public SalonService(
        ISalonRepository salonRepository,
        IHairStylistServiceRepository hairStylistServiceRepository,
        IHairStylistRepository hairStylistRepository,
        IImageConvertorService imageConvertorService,
        ISalonImageRepository salonImageRepository,
        IServiceRepository serviceRepository)
    {
        _salonRepository = salonRepository;
        _hairStylistServiceRepository = hairStylistServiceRepository;
        _hairStylistRepository = hairStylistRepository;
        _imageConvertorService = imageConvertorService;
        _salonImageRepository = salonImageRepository;
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
        var servicesUnique =
            salon.Users?
                .SelectMany(h => h.HairStylistServices)
                .Select(hsss => hsss.Service).Distinct();
        var services = servicesUnique.Select(su => new ServiceModel()
        {
            Currency = su.HairStylistServices.First().Currency,
            Id = su.Id,
            MaxPrice = su.HairStylistServices.Max(x => x.Price),
            MaxServiceDuration = su.HairStylistServices.Max(x => x.Time),
            MinPrice = su.HairStylistServices.Min(x => x.Price),
            MinServiceDuration = su.HairStylistServices.Min(x => x.Time),
            ServiceCategory = su.ServiceType.Name,
            ServiceName = su.Name,
        }).ToList();

        var hairStylists = new List<HairStylistModel>();

        foreach (var h in salon.Users)
        {
            var hairStylistProfileImage =
                await _imageConvertorService.ConvertByteArrayToFileFormAsync(new ImageDto()
                {
                    FileName = h.ProfileImageFileName,
                    Name = h.ProfileImageName,
                    Content = h.ProfileImage
                });
            hairStylists.Add(new HairStylistModel()
            {
                Id = h.Id,
                Name = $"{h.FirstName} {h.LastName}",
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
            },
        };

        return salonDto;
    }

    public async Task AddSalonAsync(AddSalonModel model)
    {
        var hairStylists = await _hairStylistRepository.GetHairStylistsAsync();
        var neededHairStylists = model.Hairstylists.Select(modelHairstylist => hairStylists.First(hs => hs.Id == Guid.Parse(modelHairstylist))).ToList();

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
            Users = neededHairStylists

        };
        await _salonRepository.CreateSalonAsync(salon);

        await AddSalonImagesAsync(model, id);
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