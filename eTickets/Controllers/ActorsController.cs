using eTickets.Models;
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
        public IActionResult DeleteActor(int id)
        {
            var actor = _repository.GetActor(id);
            _repository.DeleteActor(id);
            TempData["SuccessMessage"] = $"<strong>{actor.FullName}</strong> با موفقیت حذف شد.";
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var actor = _repository.GetActor(id);
            return View(actor);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var actor = _repository.GetActor(id);

            if(actor == null)
            {
                return NotFound();
            }
            return View(actor);
        }

        [HttpPost]
        public IActionResult Edit(int id,Actor model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var actor = _repository.GetActor(id);

            if (actor == null)
            {
                return NotFound();
            }

            actor.ProfilePictureUrl = model.ProfilePictureUrl;
            actor.FullName = model.FullName;
            actor.Bio = model.Bio;

            _repository.UpdateActor(actor);

            TempData["SuccessMessage"] = "بازیگر با موفقیت ویرایش شد.";

            return RedirectToAction("Index");
        }
    }
}
