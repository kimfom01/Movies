using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using Movies.Repositories;

namespace Movies.Controllers;

[Authorize]
public class MyMoviesController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MyMoviesController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public IActionResult Index()
    {
        var likedMovies = _unitOfWork.LikedMovies.GetEntities();
        
        return View(likedMovies);
    }

    public async Task<IActionResult> Details(int? movieId)
    {
        if (movieId is null)
        {
            return NotFound();
        }

        var movie = await _unitOfWork.Movies.GetOneEntity(mov => mov.MovieId == movieId);

        if (movie is null)
        {
            return NotFound();
        }

        var details = _mapper.Map<Details>(movie);

        return View(details);
    }
}