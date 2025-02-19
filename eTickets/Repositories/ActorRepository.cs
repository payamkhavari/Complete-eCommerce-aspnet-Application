using eTickets.Data;
using eTickets.Models;

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
                new Actor{FullName = "jason statham" , Bio = "he is a strong men" , ProfilePictureUrl = "~/Images/1.avif"},
                new Actor{FullName = "Michel Jakson" , Bio = "good dancer" , ProfilePictureUrl = "~/Images/1.avif"}
            };
            _dbContext.AddRange(actors);
            _dbContext.SaveChanges();
        }

        public List<Actor> GetActors()
        {
           return _dbContext.Actors.ToList();
        }
    }
}
