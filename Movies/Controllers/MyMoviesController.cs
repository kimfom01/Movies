using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using Movies.Repositories;

namespace Movies.Controllers;

[Authorize]
public class MyMoviesController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;

    public MyMoviesController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userManager = userManager;
    }
    
    public IActionResult Index()
    {
        var userId = _userManager.GetUserId(User);
        
        var likedMovies = _unitOfWork.LikedMovies.GetLikedMovies(userId!);
        
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