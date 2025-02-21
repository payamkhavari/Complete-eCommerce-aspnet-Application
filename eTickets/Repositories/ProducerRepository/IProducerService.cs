using eTickets.Models;

namespace eTickets.Repositories.ProducerRepository
{
    public interface IProducerService
    {
        void AddProducer();
        List<Producer> GetProducers();
        Producer GetProducerById(int id);
        Producer DeleteProducer(int id);
    }
}
