using Movies.Models.APIModels;

namespace Movies.MovieApi;

public interface IMovieApiService
{
    Task<IEnumerable<MovieApiDto>?> FetchMovies(Filter? filter);
}
