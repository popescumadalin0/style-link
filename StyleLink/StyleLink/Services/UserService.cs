using System;
using StyleLink.Repositories.Interfaces;
using System.Threading.Tasks;
using DatabaseLayout.Models;
using Microsoft.AspNetCore.Identity;
using StyleLink.Constants;
using StyleLink.Models;
using StyleLink.Services.Interfaces;

namespace StyleLink.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly UserManager<User> _userManager;
    private readonly IImageConvertorService _imageConvertorService;

    public UserService(
        IUserRepository userRepository,
        IImageConvertorService imageConvertorService,
        UserManager<User> userManager)
    {
        _userRepository = userRepository;
        _imageConvertorService = imageConvertorService;
        _userManager = userManager;
    }

    public async Task<IdentityResult> RegisterAsync(RegisterModel register)
    {
        var user = new User()
        {
            Id = Guid.NewGuid(),
            ProfileImage = await _imageConvertorService.ConvertFileFormToByteArrayAsync(register.ProfileImage),
            LastName = register.LastName,
            Email = register.Email,
            FirstName = register.FirstName,
            PhoneNumber = register.PhoneNumber,
            TwoFactorEnabled = false,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            ProfileImageName = register.ProfileImage.Name,
            ProfileImageFileName = register.ProfileImage.FileName,
            UserName = register.Email
        };
        var result = await _userRepository.CreateUserAsync(user, register.Password);
        if (!result.Succeeded)
        {
            return result;
        }

        result = await _userManager.AddToRoleAsync(user, Roles.User);

        return result;
    }

    public async Task<IdentityResult> UpdateUserAsync(UpdateUserModel model)
    {
        IdentityResult result;
        var currentUser = await _userRepository.GetUserAsync(model.Id);
        if (currentUser.Email != model.Email)
        {
            result = await _userRepository.UpdateUserEmailAsync(currentUser, model.Email, "TODO");
            if (!result.Succeeded)
            {
                return result;
            }
        }
        if (currentUser.PhoneNumber != model.PhoneNumber)
        {
            result = await _userRepository.UpdateUserPhoneNumberAsync(currentUser, model.PhoneNumber, "TODO");
            if (!result.Succeeded)
            {
                return result;
            }
        }

        currentUser.ProfileImage = await _imageConvertorService.ConvertFileFormToByteArrayAsync(model.ProfileImage);
        currentUser.LastName = model.LastName;
        currentUser.FirstName = model.FirstName;
        currentUser.ProfileImageName = model.ProfileImage.Name;
        currentUser.ProfileImageFileName = model.ProfileImage.FileName;

        result = await _userRepository.UpdateUserAsync(currentUser);
        return result;
    }

    public async Task<UpdateUserModel> GetUserDetailAsync(string name)
    {
        var user = await _userRepository.GetUserAsync(name);

        var profileImageFileForm = await _imageConvertorService.ConvertByteArrayToFileFormAsync(new ImageDto()
        {
            Name = user.ProfileImageName,
            FileName = user.ProfileImageFileName,
            Content = user.ProfileImage
        });

        var userDto = new UpdateUserModel()
        {
            Email = user.Email,
            FirstName = user.FirstName,
            PhoneNumber = user.PhoneNumber,
            Id = user.Id,
            ProfileImage = profileImageFileForm,
            LastName = user.LastName,
            ProfileImageDisplay = await _imageConvertorService.ConvertFormFileToImageAsync(profileImageFileForm)
        };

        return userDto;
    }
}