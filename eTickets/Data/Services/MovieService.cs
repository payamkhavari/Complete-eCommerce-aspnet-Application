using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace eTickets.Data.Services
{
    public class MovieService : EntityBaseRepository<Movie> ,IMovieService
    {
        private readonly AppDbContext _context;
        public MovieService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Movie UpdateMovie( Movie movie)
        {

            var result = _context.Movies.FirstOrDefault(x => x.Id == movie.Id);

                if (movie == null)
                {
                    throw new Exception("Movie not found");
                }
                else
                {
                    result.Name = movie.Name;
                    result.Description = movie.Description;
                    result.MovieCategory = movie.MovieCategory;
                    result.Producer = movie.Producer;
                    result.Price = movie.Price;
                    //result.Cinema.Name = movie.Cinema.Name;
                    result.ImageUrl = movie.ImageUrl;
                }
                _context.Movies.Update(result);
                _context.SaveChanges();
                return result;
            
        }
    }
}
  
