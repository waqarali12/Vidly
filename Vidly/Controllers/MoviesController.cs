using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context= new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ViewResult Index()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }

        public ActionResult MovieDetails(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.id==id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }
    }
}