using Microsoft.AspNetCore.Mvc;
using Movies.Repositories;

namespace Movies.Controllers;

public class MyMoviesController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public MyMoviesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public IActionResult Index()
    {
        var likedMovies = _unitOfWork.LikedMovies.GetEntities();
        
        return View(likedMovies);
    }
}