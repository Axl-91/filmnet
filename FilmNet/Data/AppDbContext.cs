using FilmNet.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FilmNet.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options): IdentityDbContext(options)
{
    public DbSet<Film> Films { get; set; }
}