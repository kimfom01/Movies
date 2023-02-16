﻿using System.Text.Json.Serialization;

namespace Movies.Models.APIModels;

public class MovieDto
{
    [JsonPropertyName("id")]
    public int MovieId { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("medium_cover_image")]
    public required string ImageUrl { get; set; }

    [JsonPropertyName("rating")]
    public double Rating { get; set; }

    [JsonPropertyName("genres")]
    public required List<string> Genres { get; set; }

    [JsonPropertyName("year")]
    public int Year { get; set; }
}
