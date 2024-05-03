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
    private readonly IHairStylistServiceRepository _hairStylistServiceRepository;
    private readonly IServiceRepository _serviceRepository;

    private readonly IImageConvertorService _imageConvertorService;


    public HairStylistService(
        IHairStylistRepository hairStylistRepository,
        IServiceRepository serviceRepository,
        IImageConvertorService imageConvertorService,
        IHairStylistServiceRepository hairStylistServiceRepository)
    {
        _hairStylistRepository = hairStylistRepository;
        _serviceRepository = serviceRepository;
        _imageConvertorService = imageConvertorService;
        _hairStylistServiceRepository = hairStylistServiceRepository;
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
        var hairStylistId = Guid.NewGuid();
        var hairStylist = new HairStylist()
        {
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Password = model.Password,
            PhoneNumber = model.PhoneNumber,
            Id = hairStylistId,
            ProfileImage = await _imageConvertorService.ConvertFileFormToByteArrayAsync(model.ProfileImage),
            ProfileImageFileName = model.ProfileImage.FileName,
            ProfileImageName = model.ProfileImage.Name,
        };

        await _hairStylistRepository.CreateHairStylistAsync(hairStylist);

        var hairStylistNeeded = await _hairStylistRepository.GetHairStylistAsync(hairStylistId);

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
                HairStylist = hairStylistNeeded,
                Price = service.Price,
                Time = service.Time,
            };

            await _hairStylistServiceRepository.CreateHairStylistServiceAsync(entity);
        }
    }
}