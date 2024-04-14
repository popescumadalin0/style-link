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

    public HairStylistService(IHairStylistRepository hairStylistRepository, IServiceRepository serviceRepository)
    {
        _hairStylistRepository = hairStylistRepository;
        _serviceRepository = serviceRepository;
    }

    public async Task<List<AddHairStylistModel>> GetAddHairStylistsAsync()
    {
        var hairStylists = await _hairStylistRepository.GetHairStylistsAsync();

        var hairStylistsDto = hairStylists.Select(h => new AddHairStylistModel()
        {
            Id = h.Id,
            //ProfileImage = h.ProfileImage,
            ConfirmPassword = h.Password,
            Email = h.Email,
            FirstName = h.FirstName,
            LastName = h.LastName,
            Password = h.Password,
            PhoneNumber = h.PhoneNumber,
            //ProfileImageTest = h.ProfileImageTest,
        }).ToList();

        return hairStylistsDto;
    }

    public async Task AddHairStylistAsync(AddHairStylistModel model)
    {

        var services = model.Services.Select(async s => await _serviceRepository.GetServiceAsync(Guid.Parse(s)));
        var hairStylist = new HairStylist()
        {
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Password = model.Password,
            PhoneNumber = model.PhoneNumber,
            //ProfileImage = model.ProfileImage,
            Services = (ICollection<Service>)services,
            Id = Guid.NewGuid(),
        };

        await _hairStylistRepository.CreateHairStylistAsync(hairStylist);
    }
}