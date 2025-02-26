using eTickets.Data;
using eTickets.Data.Enums;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _service;
        public MovieController(IMovieService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var movies = _service.GetMovies();
            return View(movies);
        }
        public IActionResult Details(int id)
        {
           var movie =  _service.GetMovie(id);
            return View(movie);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _service.GetMovie(id);
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return View(result);
            }
        }

        [HttpPost]
       public IActionResult Edit(int id,Movie movie)
        {
            var result = _service.Update(movie);
            return RedirectToAction("Index");
        }



    }
}
