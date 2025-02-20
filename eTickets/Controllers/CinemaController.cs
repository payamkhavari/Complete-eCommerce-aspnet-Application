using eTickets.Data;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class CinemaController : Controller
    {
        private readonly AppDbContext _dbContex;
        public CinemaController(AppDbContext dbContext)
        {
            _dbContex = dbContext;
        }
        public IActionResult Index()
        {
            List<Cinema> cinemas = new List<Cinema>(){
                new Cinema()
                {
                    Description = "ghjk",
                    CinemaLogo = "this part was not defined",
                    Name = "koroush"
                },
            new Cinema()
            {
                Description = "ghjk",
                CinemaLogo = "this part was not defined",
                Name = "koroush"
            }
            };

            _dbContex.Cinemas.AddRange(cinemas);
            _dbContex.SaveChanges();
            return View();
        }
    }
}
