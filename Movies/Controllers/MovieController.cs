using Microsoft.AspNetCore.Mvc;
using Movies.Repositories;

namespace Movies.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IActionResult Index()
        {
            var movies = _movieRepository.GetEntities();

            var moviesSortedByDate = movies.OrderByDescending(mo => mo.Year).ToList();

            return View(moviesSortedByDate);
        }
    }
}
