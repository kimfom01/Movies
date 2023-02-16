using Movies.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Movies.Services;

public class MovieAPIService : IMovieAPIService
{
    private readonly HttpClient _httpClient;

    public MovieAPIService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.BaseAddress = new Uri(config.GetSection("BaseAddress").Value
            ?? throw new NullReferenceException("Base address is missing from configuration(appsettings.json)"));
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<string?> FetchDetails(int id)
    {
        using var response = await _httpClient.GetAsync($"movie_details.json?movie_id={id}");

        if (response.IsSuccessStatusCode)
        {
            var stream = await response.Content.ReadAsStreamAsync();
            var movieDetails = await JsonSerializer.DeserializeAsync<string>(stream);

            return movieDetails;
        }

        return null;
    }

    public async Task<IEnumerable<Movie>?> FetchMovies()
    {
        using var response = await _httpClient.GetAsync("list_movies.json");

        if (response.IsSuccessStatusCode)
        {
            var stream = await response.Content.ReadAsStreamAsync();
            var movieList = await JsonSerializer.DeserializeAsync<IEnumerable<Movie>>(stream);

            return movieList;
        }

        return null;
    }   
}
