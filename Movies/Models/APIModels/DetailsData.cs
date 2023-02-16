using System.Text.Json.Serialization;

namespace Movies.Models.APIModels;

public class DetailsData
{
    [JsonPropertyName("movies")]
    public DetailsDto? MoviesDetail { get; set; }
}
