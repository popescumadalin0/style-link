using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StyleLink.Models;
using StyleLink.Repositories.Interfaces;

namespace StyleLink.Services.Interfaces;

public interface IServiceSalonService
{
    Task<List<AddServiceModel>> GetAddServicesAsync();

    Task AddServiceAsync(AddServiceModel model);
}