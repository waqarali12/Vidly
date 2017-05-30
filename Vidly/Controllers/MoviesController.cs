using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ViewResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie {id = 1, name = "Shrek"},
                new Movie {id = 2, name = "Wall-e"},
                new Movie {id = 3, name = "Something"}
            };
        }
    }
}