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

        public IActionResult Index(string searchString)
        {

            var movies = _movieRepository.GetEntities();

            movies = movies.OrderByDescending(mo => mo.Year).ToList();

            if(!string.IsNullOrWhiteSpace(searchString))
            {
                movies = movies.Where(m => m.Title.Contains(searchString));
            }

            return View(movies);
        }
    }
}
