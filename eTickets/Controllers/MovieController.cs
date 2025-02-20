using eTickets.Data;
using eTickets.Data.Enums;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppDbContext _dbContex;
        public MovieController(AppDbContext dbContext)
        {
            _dbContex = dbContext;
        }
        public IActionResult Index()
        {
            List<Movie> ListOfMovies = new List<Movie>(){
                new Movie()
                {
                    Description = "ghjk",
                    MovieCategory = MovieCategory.Horror,
                    Name = "koroush"
                },
            new Movie()
            {
                Description = "ghjk",
                MovieCategory = MovieCategory.Action,
                Name = "koroush"
            }
            };

            _dbContex.Movies.AddRange(ListOfMovies);
            _dbContex.SaveChanges();
            return View();
        }
    }
}
