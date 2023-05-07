using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using Movies.MovieApi;
using Movies.Repositories;

namespace Movies.Controllers;

public class AdminController : Controller
{
    private readonly IMovieApiService _movieApiService;
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public AdminController(
        IMovieApiService movieApiService, 
        IMovieRepository movieRepository, 
        IMapper mapper)
    {
        _movieApiService = movieApiService;
        _movieRepository = movieRepository;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> FetchMovies([Bind("Rating")] Filter filter)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Index", controllerName: "Movie");
        }
        var moviesApiDto = await _movieApiService.FetchMovies(filter);

        var movies = _mapper.Map<IEnumerable<Movie>>(moviesApiDto);

        await _movieRepository.AddEntities(movies);

        await _movieRepository.SaveChanges();

        return RedirectToAction("Index", controllerName: "Movie");
    }
}
