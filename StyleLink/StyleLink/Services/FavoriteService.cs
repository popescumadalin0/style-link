using System.Collections.Generic;
using StyleLink.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using StyleLink.Models;
using StyleLink.Services.Interfaces;

namespace StyleLink.Services;

public class FavoriteService : IFavoriteService
{
    private readonly IFavoriteRepository _favoriteRepository;
    private readonly IImageConvertorService _imageConvertorService;

    public FavoriteService(
        IFavoriteRepository favoriteRepository,
        IImageConvertorService imageConvertorService)
    {
        _favoriteRepository = favoriteRepository;
        _imageConvertorService = imageConvertorService;
    }

    public async Task<List<FavoriteModel>> GetFavoritesAsync()
    {
        var favorites = await _favoriteRepository.GetFavoritesAsync();
        var favoritesDto = new List<FavoriteModel>();
        foreach (var f in favorites)
        {
            var profileImage = await _imageConvertorService.ConvertByteArrayToFileFormAsync(new ImageDto()
            {
                Name = f.Salon.Name,
                Content = f.Salon.ProfileImage,
                FileName = f.Salon.ProfileImageFileName
            });

            var images = await _imageConvertorService.ConvertByteArraysToFileFormsAsync(
                f.Salon.SalonImages
                    .Select(si =>
                        new ImageDto()
                        {
                            Content = si.Content,
                            Name = si.Name,
                            FileName = si.FileName
                        }).ToList());

            favoritesDto.Add(new FavoriteModel()
            {
                Address = f.Salon.Address,
                Id = f.Id,
                SalonId = f.Salon.Id,
                SalonName = f.Salon.Name,
                Images = images,
                ProfileImage = profileImage,
                NumberOfEvaluations = f.Salon.ReviewCount,
                SalonRating = f.Salon.Rating
            });
        }

        return favoritesDto;
    }
}