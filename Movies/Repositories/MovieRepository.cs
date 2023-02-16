using Movies.Data;
using Movies.Models;

namespace Movies.Repositories;

public class MovieRepository : Repository<Movie>, IMovieRepository
{
    public MovieRepository(MovieDbContext movieDbContext) : base(movieDbContext)
    {
    }
}
