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

    public HairStylistService(IHairStylistRepository hairStylistRepository)
    {
        _hairStylistRepository = hairStylistRepository;
    }

    public async Task<List<AddHairStylistModel>> GetAddHairStylistsAsync()
    {
        var hairStylists = await _hairStylistRepository.GetHairStylistsAsync();

        var hairStylistsDto = hairStylists.Select(h => new AddHairStylistModel()
        {
            Id = h.Id,
            //ProfileImage = h.ProfileImage,
            Services = h.Services.Select(s => new AddServiceModel()
            {
                Currency = s.Currency,
                Id = s.Id,
                ServiceType = new ServiceTypeModel() { Name = s.ServiceType.Name },
                Name = s.ServiceType.Name,
                Price = s.Price,
                Time = s.Time,
            }).ToList(),
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
        var hairStylist = new HairStylist()
        {
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Password = model.Password,
            PhoneNumber = model.PhoneNumber,
            //ProfileImage = model.ProfileImage,
            Services = model.Services.Select(s => new Service()
            {
                Currency = s.Currency,
                Name = s.Name,
                Price = s.Price,
                Time = s.Time,
                Id = s.Id,
                ServiceType = new ServiceType() { Name = s.ServiceType.Name }
            }).ToList(),
            Id = Guid.NewGuid(),
        };

        await _hairStylistRepository.CreateHairStylistAsync(hairStylist);
    }
}