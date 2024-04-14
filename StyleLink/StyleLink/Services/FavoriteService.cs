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

    public FavoriteService(IFavoriteRepository favoriteRepository)
    {
        _favoriteRepository = favoriteRepository;
    }

    public async Task<List<FavoriteModel>> GetFavoritesAsync()
    {
        var favorites = await _favoriteRepository.GetFavoritesAsync();

        var favoritesDto = favorites.Select(f => new FavoriteModel()
        {
            Address = f.Salon.Address,
            Id = f.Id,
            SalonId = f.Salon.Id,
            SalonName = f.Salon.Name,
            //Images = f.Salon.SalonImages.Select(si => si.Content).ToList(),
            ImagesTest = f.Salon.SalonImages.Select(si => si.Content).ToList(),
            //ProfileImage = f.Salon.ProfileImage,
            ProfileImageTest = f.Salon.ProfileImage,
            NumberOfEvaluations = f.Salon.ReviewCount,
            SalonRating = f.Salon.Rating
        }).ToList();

        return favoritesDto;
    }
}