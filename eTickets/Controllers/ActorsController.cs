using eTickets.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorRepository _repository;
        public ActorsController(IActorRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            //_repository.AddActorsIntoDatabase();
            var result = _repository.GetActors();
            return View(result);
        }
    }
}
