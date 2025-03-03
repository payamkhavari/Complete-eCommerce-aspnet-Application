using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IProducerService _producerService;
        public ProducerController(IProducerService producerService)
        {
            _producerService = producerService;
        }
        public IActionResult Index()
        {
           var result =  _producerService.GetAll();
            return View(result);
        }
        public IActionResult Details(int id) 
        {
            var reasult = _producerService.GetById(id);
            if (reasult == null) return View("not found");
            return View(reasult);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Add([Bind("FullName,ProfilePictureUrl,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            else
            {
                _producerService.Add(producer);
                TempData["SuccessMessage"] = "تولید کننده با موفقیت اضافه شد.";
                return RedirectToAction(nameof(Index));
            }
        }
        public IActionResult DeleteProducer(int id)
        {
           var result =  _producerService.GetById(id);
            if (result == null)
            {
                return View("Error");
            }
            else
            {
                _producerService.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
