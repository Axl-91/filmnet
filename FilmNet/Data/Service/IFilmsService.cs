using FilmNet.Models;

namespace FilmNet.Data.Service;

public interface IFilmsService
{
    Task<IEnumerable<Film>> GetAllFilmsAsync();
    
    Task AddFilmAsync(Film film);
}