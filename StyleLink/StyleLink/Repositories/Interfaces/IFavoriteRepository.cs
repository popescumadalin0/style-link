using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout.Models;

namespace StyleLink.Repositories.Interfaces;

public interface IFavoriteRepository
{
    Task<List<Favorite>> GetFavoritesAsync();

    Task<Favorite> GetFavoriteAsync(Guid id);

    Task DeleteFavoriteAsync(Guid id);

    Task CreateFavoriteAsync(Favorite model);
}