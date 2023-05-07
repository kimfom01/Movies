using System.Text.Json.Serialization;

namespace Movies.Models.APIModels;

public class MovieData
{
    [JsonPropertyName("movies")]
    public IEnumerable<MovieApiDto>? MoviesDto { get; set; }
}