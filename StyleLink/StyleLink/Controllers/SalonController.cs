using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayout.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StyleLink.Models;
using StyleLink.Repositories;

namespace StyleLink.Controllers;

public class SalonController : Controller
{
    private readonly ILogger<SalonController> _logger;

    private readonly ISalonRepository _salonRepository;

    public SalonController(
        ILogger<SalonController> logger,
        ISalonRepository salonRepository)
    {
        _logger = logger;
        _salonRepository = salonRepository;
    }

    [HttpGet]
    public async Task<IActionResult> SalonAsync(Guid id)
    {
        var salon = await _salonRepository.GetSalonAsync(id);

        var servicesGroup =
            salon.HairStylistSalons
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
            ImagesTest = salon.SalonImages.Select(si => si.Content).ToList(),
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

        return View(salonDto);
    }
}