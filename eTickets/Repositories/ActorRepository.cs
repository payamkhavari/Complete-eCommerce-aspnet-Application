using eTickets.Data;
using eTickets.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly AppDbContext _dbContext;

        public ActorRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddActorsIntoDatabase()
        {
            List<Actor> actors = new List<Actor>()
            {
                new Actor{FullName = "jason statham" , Bio = "he is a strong men" , ProfilePictureUrl = "/Images/jason-statham.jpg"},
                new Actor{FullName = "Michel Jakson" , Bio = "good dancer" , ProfilePictureUrl = "/Images/Vandom.jpg"},
            };
            _dbContext.AddRange(actors);
            _dbContext.SaveChanges();
        }

        public Actor GetActor(int id)
        {
            var result = _dbContext.Actors.FirstOrDefault(x => x.ActorId == id);
            if (result == null)
            {
                throw new Exception("Actor not found");
            }
            return result;
        }
        public Actor DeleteActor(int id)
        {
            var result = GetActor(id);
            _dbContext?.Actors.Remove(result);
            _dbContext?.SaveChanges();
            return result;
        }

        public List<Actor> GetActors()
        {
            return _dbContext.Actors.ToList();
        }

        public void UpdateActor(Actor actor)
        {
            _dbContext.Actors.Update(actor);
            _dbContext.SaveChanges();
        }
    }
}
