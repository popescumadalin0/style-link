using System;
using System.Collections.Generic;
using StyleLink.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayout.Models;
using StyleLink.Models;
using StyleLink.Services.Interfaces;

namespace StyleLink.Services;

public class FavoriteService : IFavoriteService
{
    private readonly IFavoriteRepository _favoriteRepository;
    private readonly ISalonRepository _salonRepository;
    private readonly IUserRepository _userRepository;
    private readonly IImageConvertorService _imageConvertorService;

    public FavoriteService(
        IFavoriteRepository favoriteRepository,
        IImageConvertorService imageConvertorService,
        ISalonRepository salonRepository, 
        IUserRepository userRepository)
    {
        _favoriteRepository = favoriteRepository;
        _imageConvertorService = imageConvertorService;
        _salonRepository = salonRepository;
        _userRepository = userRepository;
    }

    public async Task<List<FavoriteModel>> GetFavoritesAsync(string userName)
    {
        var favorites = await _favoriteRepository.GetFavoritesAsync();
        var favoritesDto = new List<FavoriteModel>();
        foreach (var favorite in favorites.Where(f=> f.User.Email == userName || f.User.UserName == userName))
        {
            var profileImage = await _imageConvertorService.ConvertByteArrayToFileFormAsync(new ImageDto()
            {
                Name = favorite.Salon.Name,
                Content = favorite.Salon.ProfileImage,
                FileName = favorite.Salon.ProfileImageFileName
            });

            var images = await _imageConvertorService.ConvertByteArraysToFileFormsAsync(
                favorite.Salon.SalonImages
                    .Select(si =>
                        new ImageDto()
                        {
                            Content = si.Content,
                            Name = si.Name,
                            FileName = si.FileName
                        }).ToList());

            favoritesDto.Add(new FavoriteModel()
            {
                Address = favorite.Salon.Address,
                Id = favorite.Id,
                SalonId = favorite.Salon.Id,
                SalonName = favorite.Salon.Name,
                Images = await _imageConvertorService.ConvertFormFilesToImagesAsync(images),
                ProfileImage = await _imageConvertorService.ConvertFormFileToImageAsync(profileImage),
                NumberOfEvaluations = favorite.Salon.ReviewCount,
                SalonRating = favorite.Salon.Rating
            });
        }

        return favoritesDto;
    }

    public async Task CreateFavoriteAsync(Guid id, string userName)
    {
        var salon = await _salonRepository.GetSalonAsync(id);
        var user = await _userRepository.GetUserAsync(userName);

        await _favoriteRepository.CreateFavoriteAsync(new Favorite()
        {
            Id = Guid.NewGuid(),
            Salon = salon,
            User = user
        });
    }
}