using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StyleLink.Models;

namespace StyleLink.Services.Interfaces;

public interface IFavoriteService
{
    Task<List<FavoriteModel>> GetFavoritesAsync(string userName);

    Task CreateFavoriteAsync(Guid id, string userName);
}