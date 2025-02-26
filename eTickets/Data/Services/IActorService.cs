using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IActorService
    {
        IEnumerable<Actor> GetAllActors();
        Actor GetActorById(int id);
        void AddActor(Actor actor);
        void UpdateActor(Actor actor);
        void DeleteActor(int id);
    }
}
