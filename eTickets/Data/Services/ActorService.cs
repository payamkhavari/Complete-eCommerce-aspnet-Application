using eTickets.Models;

namespace eTickets.Data.Services
{
    public class ActorService : IActorService
    {
        private readonly AppDbContext _dbContext;
        public ActorService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddActor(Actor actor)
        {
            //List<Actor> actors = new List<Actor>()
            //{
            //    new Actor{FullName = "jason statham" , Bio = "he is a strong men" , ProfilePictureUrl = "/Images/jason-statham.jpg"},
            //    new Actor{FullName = "Michel Jakson" , Bio = "good dancer" , ProfilePictureUrl = "/Images/Vandom.jpg"},
            //};
            _dbContext.Actors.Add(actor);
            _dbContext.SaveChanges();
        }
        public Actor GetActorById(int id)
        {
            var result = _dbContext.Actors.FirstOrDefault(x => x.ActorId == id);
            if (result == null)
            {
                throw new Exception("Actor not found");
            }
            return result;
        }
        public void DeleteActor(int id)
        {
            var result = GetActorById(id);
            _dbContext?.Actors.Remove(result);
            _dbContext?.SaveChanges();
        }

        public IEnumerable<Actor> GetAllActors()
        {
            return _dbContext.Actors.ToList();
        }

        void IActorService.UpdateActor(Actor actor)
        {
            _dbContext.Actors.Update(actor);
            _dbContext.SaveChanges();
        }
    }
}
