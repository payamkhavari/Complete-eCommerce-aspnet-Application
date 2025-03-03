using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaService _service;
        public CinemaController(ICinemaService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var movies = _service.GetAll();
            return View(movies);
        }

        public IActionResult Details(int id)
        {
           var cinema =  _service.GetById(id);
            return View(cinema);
        }
    }
}
