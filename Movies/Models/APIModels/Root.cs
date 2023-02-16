using System.Text.Json.Serialization;

namespace Movies.Models.APIModels;

public class Root
{
    [JsonPropertyName("data")]
    public MovieData? MovieData { get; set; }
}
