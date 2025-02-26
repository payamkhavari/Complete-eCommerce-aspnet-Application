using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace eTickets.Data.Services
{
    public class MovieService : IMovieService
    {
        private readonly AppDbContext _dbContext;

        public MovieService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Movie GetMovie(int id)
        {
            var movie = _dbContext.Movies.FirstOrDefault(x => x.MovieId == id);

            if (movie == null)
            {
                throw new Exception("Movie not found");
            }
            else
            {
                return movie;
            }
        }

        public List<Movie> GetMovies()
        {
            return _dbContext.Movies.Include(x => x.Cinema).ToList();
        }

        public Movie Update(Movie movie)
        {
            var result = GetMovie(movie.MovieId);

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
            _dbContext.Movies.Update(result);
            _dbContext.SaveChanges();
            return result;
        }
    }
}
  
