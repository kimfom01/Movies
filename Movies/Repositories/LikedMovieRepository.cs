using Movies.Data;
using Movies.Models;

namespace Movies.Repositories;

public class LikedMovieRepository: Repository<LikedMovie>, ILikedMovieRepository
{
    public LikedMovieRepository(MoviesContext movieDbContext) : base(movieDbContext)
    {
    }

    public bool CheckMovie(int? movieId)
    {
        return DbSet.Any(mov => mov.MovieId == movieId);
    }
}