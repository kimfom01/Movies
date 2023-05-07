using Microsoft.EntityFrameworkCore;
using Movies.Models;

namespace Movies.Context;

public class MovieDbContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }

    public MovieDbContext(DbContextOptions options) : base(options)
    {
    }
}
