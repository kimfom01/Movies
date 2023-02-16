using Movies.Models;

namespace Movies.Services
{
    public interface IMovieAPIService
    {
        Task<IEnumerable<Movie>?> FetchMovies();
        Task<string?> FetchDetails(int id);
    }
}