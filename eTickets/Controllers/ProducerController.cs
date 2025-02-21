using eTickets.Repositories.ProducerRepository;
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
            var result = _producerService.GetProducers().ToList();
            return View(result);
        }
    }
}
