using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StyleLink.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StyleLink.Repositories;

namespace StyleLink.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ISalonRepository _salonRepository;

    public HomeController(ILogger<HomeController> logger, ISalonRepository salonRepository)
    {
        _logger = logger;
        _salonRepository = salonRepository;
    }

    public async Task<IActionResult> Index()
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

        return View(salonsDto);
    }
}