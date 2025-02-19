using eTickets.Models;

namespace eTickets.Repositories
{
    public interface IActorRepository
    {
        void AddActorsIntoDatabase();
        List<Actor> GetActors();
    }
}
