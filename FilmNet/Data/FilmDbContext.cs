using FilmNet.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmNet.Data;

public class FilmDbContext: DbContext
{
    public FilmDbContext(DbContextOptions<FilmDbContext> options) : base(options) { }
    
    public DbSet<Film> Films { get; set; }
}