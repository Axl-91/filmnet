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

    public async Task<Film?> GetFilmByIdAsync(int id)
    {
        return await context.Films.FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task UpdateFilmAsync(Film film)
    {
        context.Films.Update(film);
        await context.SaveChangesAsync();
    }

    public async Task DeleteFilmAsync(Film film)
    {
        context.Films.Remove(film);
        await context.SaveChangesAsync();
    }
    
}