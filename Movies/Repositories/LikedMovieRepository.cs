using Movies.Areas.Identity.Data;
using Movies.Models;

namespace Movies.Repositories;

public class LikedMovieRepository: Repository<LikedMovie>, ILikedMovieRepository
{
    public LikedMovieRepository(MoviesContext movieDbContext) : base(movieDbContext)
    {
    }
}