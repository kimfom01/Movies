using Movies.Models;
using Movies.Models.APIModels;

namespace Movies.Services;

public interface IMovieAPIService
{
    Task<IEnumerable<MovieDto>?> FetchMovies(Filter? filter);
    Task<string?> FetchDetails(int id);
}