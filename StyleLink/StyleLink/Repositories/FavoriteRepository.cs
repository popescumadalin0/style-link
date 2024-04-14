using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;
using StyleLink.Repositories.Interfaces;

namespace StyleLink.Repositories;

public class FavoriteRepository : IFavoriteRepository
{
    private readonly IContext _context;

    public FavoriteRepository(IContext context)
    {
        _context = context;
    }

    public async Task<List<Favorite>> GetFavoritesAsync()
    {
        var favorites = await _context.Favorites.ToListAsync();

        return favorites;
    }

    public async Task<Favorite> GetFavoriteAsync(Guid id)
    {
        var favorite = await _context.Favorites.FirstAsync(s => s.Id == id);

        return favorite;
    }

    public async Task DeleteFavoriteAsync(Guid id)
    {
        var favorite = await _context.Favorites.FirstAsync(s => s.Id == id);

        _context.Favorites.Remove(favorite);

        await _context.SaveChangesAsync();
    }

    public async Task CreateFavoriteAsync(Favorite model)
    {
        await _context.Favorites.AddAsync(model);

        await _context.SaveChangesAsync();
    }
}