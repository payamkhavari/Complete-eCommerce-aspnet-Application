using eTickets.Models;

namespace eTickets.Repositories
{
    public interface IActorRepository
    {
        void AddActorsIntoDatabase();
        List<Actor> GetActors();
        Actor DeleteActor(int id);
        Actor GetActor(int id);
        void UpdateActor(Actor actor);
    }
}
