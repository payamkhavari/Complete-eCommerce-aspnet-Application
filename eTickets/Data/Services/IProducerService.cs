using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IProducerService : IEntityBaseRepository<Producer> 
    {
        void UpdateProducer(Producer producer);
    }
}
