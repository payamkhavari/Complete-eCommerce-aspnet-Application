using eTickets.Data;
using eTickets.Data.Enums;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            
          
                List<Movie> ListOfMovies = new List<Movie>()
               {
            new Movie()
            {
                ImageUrl = "/Images/Ad Astra DVD Cover.jpg" ,
                Description = "ghjk",
                MovieCategory = MovieCategory.Horror,
                Name = "koroush",
                CinemaId = 1 ,
                ProducerId = 1
            },
            new Movie()
            {
                ImageUrl ="/Images/Primal DVD Cover.jpg" ,
                Description = "ghjk",
                MovieCategory = MovieCategory.Action,
                Name = "koroush 2",
                CinemaId = 1 ,
                ProducerId= 2
            },
            new Movie()
            {
                ImageUrl ="/Images/Primal DVD Cover.jpg" ,
                Description = "ghjk",
                MovieCategory = MovieCategory.Cartoon,
                Name = "koroush 4",
                CinemaId = 1 ,
                ProducerId= 1
            }
        };

            //_dbContex.Movies.AddRange(ListOfMovies);
            //_dbContex.SaveChanges();


            var movies = _dbContex.Movies.Include(x => x.Cinema).ToList(); // دریافت فیلم‌های ذخیره‌شده
            return View(movies);
        }

    }
}
