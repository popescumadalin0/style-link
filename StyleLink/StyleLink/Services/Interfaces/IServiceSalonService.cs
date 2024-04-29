using System.Collections.Generic;
using System.Threading.Tasks;
using StyleLink.Models;

namespace StyleLink.Services.Interfaces;

public interface IServiceSalonService
{
    Task<List<AddServiceModel>> GetAddServicesAsync();

    Task AddServiceAsync(AddServiceModel model);
}