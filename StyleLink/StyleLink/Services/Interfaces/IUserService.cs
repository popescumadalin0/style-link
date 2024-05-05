using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using StyleLink.Models;

namespace StyleLink.Services.Interfaces;

public interface IUserService
{
    Task<IdentityResult> RegisterAsync(RegisterModel register);

    Task<IdentityResult> UpdateUserAsync(UpdateUserModel model);

    Task<UpdateUserModel> GetUserDetailAsync(string name);
}