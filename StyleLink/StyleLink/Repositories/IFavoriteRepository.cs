using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace StyleLink.Repositories;

public interface IFavoriteRepository
{
    Task<List<Favorite>> GetFavoritesAsync();

    Task<Favorite> GetFavoriteAsync(Guid id);

    Task DeleteFavoriteAsync(Guid id);

    Task CreateFavoriteAsync(Favorite model);
}