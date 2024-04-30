using System;
using System.Collections.Generic;
using StyleLink.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayout.Models;
using StyleLink.Models;
using StyleLink.Services.Interfaces;

namespace StyleLink.Services;

public class HairStylistService : IHairStylistService
{
    private readonly IHairStylistRepository _hairStylistRepository;
    private readonly IServiceRepository _serviceRepository;

    private readonly IImageConvertorService _imageConvertorService;


    public HairStylistService(
        IHairStylistRepository hairStylistRepository,
        IServiceRepository serviceRepository,
        IImageConvertorService imageConvertorService)
    {
        _hairStylistRepository = hairStylistRepository;
        _serviceRepository = serviceRepository;
        _imageConvertorService = imageConvertorService;
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
                ConfirmPassword = h.Password,
                Email = h.Email,
                FirstName = h.FirstName,
                LastName = h.LastName,
                Password = h.Password,
                PhoneNumber = h.PhoneNumber,
            });
        }

        return hairStylistsDto;
    }

    public async Task AddHairStylistAsync(AddHairStylistModel model)
    {
        var services = await _serviceRepository.GetServicesAsync();
        var servicesDto = model.Services.Select(s => services.First(ss => ss.Id == Guid.Parse(s))).ToList();
        //todo: sa adaugam si HairStylistSalonService
        var hairStylist = new HairStylist()
        {
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Password = model.Password,
            PhoneNumber = model.PhoneNumber,
            Services = servicesDto,
            Id = Guid.NewGuid(),
            ProfileImage = await _imageConvertorService.ConvertFileFormToByteArrayAsync(model.ProfileImage),
            ProfileImageFileName = model.ProfileImage.FileName,
            ProfileImageName = model.ProfileImage.Name,
        };

        await _hairStylistRepository.CreateHairStylistAsync(hairStylist);
    }
}