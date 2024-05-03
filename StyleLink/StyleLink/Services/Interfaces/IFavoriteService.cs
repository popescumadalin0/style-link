﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StyleLink.Models;

namespace StyleLink.Services.Interfaces;

public interface IFavoriteService
{
    Task<List<FavoriteModel>> GetFavoritesAsync();

    Task CreateFavoriteAsync(Guid id);
}