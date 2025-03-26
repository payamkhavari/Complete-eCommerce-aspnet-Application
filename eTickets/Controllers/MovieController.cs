using eTickets.Data;
using eTickets.Data.Enums;
using eTickets.Data.Services;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

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
        // the parameters of filter for search should be  the same of name of input which is in form in _layout view.
        public IActionResult Filter(string searchString)
        {
            var allMovies = _service.GetAll();

            if(!string.IsNullOrEmpty(searchString))
            {
                var result = allMovies.Where(n =>n.Name.Contains(searchString,StringComparison.OrdinalIgnoreCase) ||  n.Description.Contains(searchString,StringComparison.OrdinalIgnoreCase)).ToList();
                return View("Index", result);
            }

            return View("Index",allMovies);
        }
        public IActionResult Details(int id)
        {
            var movie = _service.GetByIdIncludes(id, p => p.Producer, c => c.Cinema, Ac => Ac.Actor_Movies);
          
            return View(movie);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _service.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                var newMovie = new MovieViewModel()
                {
                    Id = result.Id, 
                    Name = result.Name,
                    CinemaId = result.CinemaId,
                    ProducerId = result.ProducerId,
                    Description = result.Description,
                    ImageUrl = result.ImageUrl,
                    Price = result.Price,
                    EndDate = result.EndDate,
                    StartDate = result.StartDate,
                    MovieCategory= result.MovieCategory,
                    ActorIds = result.Actor_Movies != null ? result.Actor_Movies.Select(n => n.ActorId).ToList() : new List<int>(),
                };
                var response = _service.GetNewMovieDropdownValues();
                ViewBag.Actors = new SelectList(response.Actors, "Id", "FullName");
                ViewBag.Producers = new SelectList(response.Producers, "Id", "FullName");
                ViewBag.Cinemas = new SelectList(response.Cinemas, "Id", "Name");
               
                return View(newMovie);
                
            }
        }


        [HttpPost]
        public IActionResult Edit(int id, MovieViewModel movie)
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
        [HttpGet]
        public IActionResult Add()
        {
           var response = _service.GetNewMovieDropdownValues();
            ViewBag.Actors = new SelectList(response.Actors, "Id", "FullName");
            ViewBag.Producers = new SelectList(response.Producers,"Id" , "FullName");
            ViewBag.Cinemas = new SelectList(response.Cinemas, "Id", "Name");
            ViewBag.MovieCategories = new SelectList(Enum.GetValues(typeof(MovieCategory)));
            return View();
        }
        public IActionResult Add(MovieViewModel movie)
        {
            _service.AddMovie(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
