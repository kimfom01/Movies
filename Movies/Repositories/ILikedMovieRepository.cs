using Movies.Models;

namespace Movies.Repositories;

public interface ILikedMovieRepository : IRepository<LikedMovie>
{
    public bool CheckMovie(int? movieId);
    
    public IEnumerable<LikedMovie> GetLikedMovies(string userId);
}