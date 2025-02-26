using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorService _service;
        public ActorsController(IActorService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            //_repository.AddActorsIntoDatabase();
            var result = _service.GetAllActors();
            return View(result);
        } 
        public IActionResult DeleteActor(int id)
        {
            
            var actor = _service.GetActorById(id);
            _service.DeleteActor(id);
            TempData["SuccessMessage"] = $"<strong>{actor.FullName}</strong> با موفقیت حذف شد.";
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var actor = _service.GetActorById(id);
            return View(actor);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var actor = _service.GetActorById(id);

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

            var actor = _service.GetActorById(id);

            if (actor == null)
            {
                return NotFound();
            }

            actor.ProfilePictureUrl = model.ProfilePictureUrl;
            actor.FullName = model.FullName;
            actor.Bio = model.Bio;

            _service.UpdateActor(actor);

            TempData["SuccessMessage"] = "بازیگر با موفقیت ویرایش شد.";

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Add()
        {
                return View();
        }
        [HttpPost]
        public IActionResult Add([Bind("FullName,ProfilePictureUrl,Bio")]Actor actor)
        {
            if(!ModelState.IsValid)
            {
                return View(actor);
            }
            else
            {
                _service.AddActor(actor);
                TempData["SuccessMessage"] = "بازیگر با موفقیت اضافه شد.";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
