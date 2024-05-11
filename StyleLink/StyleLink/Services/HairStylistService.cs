using System;
using System.Collections.Generic;
using StyleLink.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayout.Models;
using StyleLink.Models;
using StyleLink.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Win32;
using StyleLink.Constants;
using StyleLink.Repositories;

namespace StyleLink.Services;

public class HairStylistService : IHairStylistService
{
    private readonly IHairStylistRepository _hairStylistRepository;
    private readonly IHairStylistServiceRepository _hairStylistServiceRepository;
    private readonly IServiceRepository _serviceRepository;
    private readonly UserManager<User> _userManager;

    private readonly IImageConvertorService _imageConvertorService;


    public HairStylistService(
        IHairStylistRepository hairStylistRepository,
        IServiceRepository serviceRepository,
        IImageConvertorService imageConvertorService,
        IHairStylistServiceRepository hairStylistServiceRepository,
        UserManager<User> userManager)
    {
        _hairStylistRepository = hairStylistRepository;
        _serviceRepository = serviceRepository;
        _imageConvertorService = imageConvertorService;
        _hairStylistServiceRepository = hairStylistServiceRepository;
        _userManager = userManager;
    }

    public async Task<List<AddHairStylistModel>> GetAddHairStylistsAsync()
    {
        var hairStylists = await _hairStylistRepository.GetHairStylistsAsync();
        var hairStylistsDto = new List<AddHairStylistModel>();
        foreach (var h in hairStylists)
        {
            var profileImage = await _imageConvertorService.ConvertByteArrayToFileFormAsync(new ImageDto()
            {
                Name = h.ProfileImageName,
                Content = h.ProfileImage,
                FileName = h.ProfileImageFileName
            });

            hairStylistsDto.Add(new AddHairStylistModel()
            {
                Id = h.Id,
                ProfileImage = profileImage,
                Email = h.Email,
                FirstName = h.FirstName,
                LastName = h.LastName,
                PhoneNumber = h.PhoneNumber,
            });
        }

        return hairStylistsDto;
    }

    public async Task<IdentityResult> AddHairStylistAsync(AddHairStylistModel model)
    {
        var hairStylist = new User()
        {
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = model.PhoneNumber,
            Id = Guid.NewGuid(),
            ProfileImage = await _imageConvertorService.ConvertFileFormToByteArrayAsync(model.ProfileImage),
            ProfileImageFileName = model.ProfileImage.FileName,
            ProfileImageName = model.ProfileImage.Name,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            UserName = model.Email,
            TwoFactorEnabled = false,
        };
        var services = await _serviceRepository.GetServicesAsync();
        var necessaryServices = model.ServiceDetails.Where(x => x.IsUsed);

        foreach (var service in necessaryServices)
        {
            var serviceDto = services.First(s => s.Id == Guid.Parse(service.ServiceId));
            var entity = new DatabaseLayout.Models.HairStylistService()
            {
                Currency = service.Currency,
                Id = new Guid(),
                Service = serviceDto,
                Price = service.Price,
                Time = service.Time,
            };

            hairStylist.HairStylistServices.Add(entity);
        }
        var result = await _hairStylistRepository.CreateHairStylistAsync(hairStylist, model.Password);

        if (!result.Succeeded)
        {
            return result;
        }

        result = await _userManager.AddToRoleAsync(hairStylist, Roles.User);
        if (!result.Succeeded)
        {
            return result;
        }

        result = await _userManager.AddToRoleAsync(hairStylist, Roles.HairStylist);

        return result;
    }
}