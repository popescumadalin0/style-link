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

    public SalonService(ISalonRepository salonRepository)
    {
        _salonRepository = salonRepository;
    }

    public async Task<List<SalonModel>> GetSalonsAsync()
    {
        var salons = await _salonRepository.GetSalonsAsync();

        var salonsDto = salons.Select(s => new SalonModel()
        {
            Address = s.Address,
            Id = s.Id,
            SalonName = s.Name,
            ProfileImage = s.ProfileImage,
            //Images = s.SalonImages?.Select(si => si.Content).ToList(),
            ImagesTest = s.SalonImages?.Select(si => si.Content).ToList(),
            NumberOfEvaluations = s.ReviewCount,
            ProfileImageTest = s.ProfileImage,
            SalonRating = s.Rating
        }).ToList();

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
                ServiceName = g.Key
            })).ToList();

        var hairStylists = new List<HairStylistModel>();
        var salonDto = new SalonDetailModel()
        {
            Services = services,
            HairStylists = hairStylists,
            Id = salon.Id,
            SalonName = salon.Name,
            //Images = salon.SalonImages.Select(si => si.Content).ToList(),
            ImagesTest = salon.SalonImages?.Select(si => si.Content).ToList(),
            MapsUrl = salon.GoogleMapsAddress,
            NumberOfEvaluations = salon.ReviewCount,
            //ProfileImage = salon.ProfileImage,
            ProfileImageTest = salon.ProfileImage,
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
        var salon = new Salon()
        {
            Address = model.Address,
            GoogleMapsAddress = model.GoogleMapsAddress,
            Name = model.SalonName,
            Id = Guid.NewGuid(),
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
            ProfileImage = model.ProfileImage,
            //SalonImages = model.Images
        };

        await _salonRepository.CreateSalonAsync(salon);
    }
}