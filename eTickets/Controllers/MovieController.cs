using eTickets.Data;
using eTickets.Data.Enums;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _service;
        private readonly IProducerService _producerService;
        private readonly IActorService _actorService;
        public MovieController(IMovieService service, IProducerService producerService, IActorService actorService)
        {
            _service = service;
            _producerService = producerService;
            _actorService = actorService;
        }
        public IActionResult Index()
        {
            var movies = _service.GetAll(c => c.Cinema , p => p.Producer);
            return View(movies);
        }
        public IActionResult Details(int id)
        {
            var movie = _service.GetByIdIncludes(id, p => p.Producer, c => c.Cinema, Ac => Ac.Actor_Movies);
          
            return View(movie);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _service.GetById(id, C => C.Cinema);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return View(result);
            }
        }


        [HttpPost]
        public IActionResult Edit(int id, Movie movie)
        {
             _service.UpdateMovie(movie);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Cinemas = new SelectList(_service.GetAll(c => c.Cinema), "Id", "Name");
            ViewBag.Producers = new SelectList(_producerService.GetAll(), "Id", "FullName");
            ViewBag.MovieCategories = new SelectList(Enum.GetValues(typeof(MovieCategory)));
            ViewBag.Actors = new SelectList(_actorService.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            
            _service.Add(movie);
            return View(movie);
        }
    }
}
