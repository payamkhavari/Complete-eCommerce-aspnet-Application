using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace eTickets.Data.Services
{
    public class MovieService : EntityBaseRepository<Movie>, IMovieService
    {
        private readonly AppDbContext _context;
        public MovieService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void AddMovie(MovieViewModel movie)
        {
            var newmovie = new Movie()
            {
                Name = movie.Name,
                CinemaId = movie.CinemaId,
                ProducerId = movie.ProducerId,
                Description = movie.Description,
                StartDate = movie.StartDate,
                EndDate = movie.EndDate,
                ImageUrl = movie.ImageUrl,
                Price = movie.Price,
                MovieCategory = movie.MovieCategory,
            };
            _context.Movies.Add(newmovie);
            _context.SaveChanges();

            foreach (var item in movie.ActorIds)
            {
                var actorExists = _context.Actors.Any(a => a.Id == item);
                if (!actorExists)
                {
                    throw new Exception($"Actor with Id {item} not found in database.");
                }
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newmovie.Id,
                    ActorId = item
                };
                _context.Actor_Movies.Add(newActorMovie);
                _context.SaveChanges();
            }

            _context.SaveChanges();
        }

        public DropDownMovieViewModel GetNewMovieDropdownValues()
        {
            var result = new DropDownMovieViewModel()
            {
                Actors = _context.Actors.OrderBy(n => n.FullName).ToList(),
                Cinemas = _context.Cinemas.OrderBy(n => n.Name).ToList(),
                Producers = _context.Producers.OrderBy(n => n.FullName).ToList(),
            };
            return result;
        }

        public void UpdateMovie(MovieViewModel movie)
        {

            var result = _context.Movies.FirstOrDefault(x => x.Id == movie.Id);

            if (result == null)
            {
                throw new Exception("Movie not found");
            }
            else
            {

                result.Name = movie.Name;
                result.CinemaId = movie.CinemaId;
                result.ProducerId = movie.ProducerId;
                result.Description = movie.Description;
                result.StartDate = movie.StartDate;
                result.EndDate = movie.EndDate;
                result.ImageUrl = movie.ImageUrl;
                result.Price = movie.Price;
                result.MovieCategory = movie.MovieCategory;

                _context.Movies.Update(result);
                _context.SaveChanges();
            }
            //remove existing actors
            var existingActorsDb = _context.Actor_Movies.Where(n => n.MovieId == movie.Id).ToList();
            _context.Actor_Movies.RemoveRange(existingActorsDb);
            _context.SaveChanges();

            foreach (var actorId in movie.ActorIds)
            {

                var newActor_Movie = new Actor_Movie()
                {
                    ActorId = actorId,
                    MovieId = movie.Id,
                };
                _context.Actor_Movies.Add(newActor_Movie);
            }
            _context.SaveChanges();
        }
    }
}

