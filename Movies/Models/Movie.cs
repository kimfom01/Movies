namespace Movies.Models;

public class Movie
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string ImageUrl { get; set; }
    public required string Rating { get; set; }
    public required string Genre { get; set; }
    public DateTime ReleaseDate { get; set; }
}
