using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using Movies.Repositories;

namespace Movies.Controllers;

[Authorize]
public class MovieController : Controller
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public MovieController(
        IMovieRepository movieRepository,
        IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }


    public IActionResult Index(string searchString)
    {
        var movies = _movieRepository.GetEntities();

        movies = movies.OrderByDescending(mo => mo.Year).ToList();

        if (!string.IsNullOrWhiteSpace(searchString))
        {
            movies = SearchForMovies(searchString, movies);
        }

        return View(movies);
    }

    private static IEnumerable<Movie> SearchForMovies(string searchString, IEnumerable<Movie> movies)
    {
        movies = movies.Where(mo => mo.Title.ToLower().Contains(searchString.ToLower()) 
            || mo.Genre.ToLower().Contains(searchString.ToLower()));

        return movies;
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var movie = await _movieRepository.GetOneEntity(mov => mov.Id == id);

        if(movie is null)
        {
            return NotFound();
        }

        var details = _mapper.Map<Details>(movie);

        return View(details);
    }
}
