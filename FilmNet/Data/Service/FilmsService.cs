using FilmNet.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmNet.Data.Service;

public class FilmsService(FilmDbContext context) : IFilmsService
{
    public async Task<IEnumerable<Film>> GetAllFilmsAsync()
    {
        return await context.Films.ToListAsync();
    }

    public async Task AddFilmAsync(Film film)
    {
        context.Films.Add(film);
        await context.SaveChangesAsync();
    }
    
}