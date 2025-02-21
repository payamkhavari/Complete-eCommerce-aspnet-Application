using eTickets.Data;
using eTickets.Models;

namespace eTickets.Repositories.ProducerRepository
{
    public class ProducerService : IProducerService
    {
        private readonly AppDbContext _appDbContext;
        public ProducerService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void AddProducer()
        {
            throw new NotImplementedException();
        }

        public Producer DeleteProducer(int id)
        {
            throw new NotImplementedException();
        }

        public Producer GetProducerById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Producer> GetProducers()
        {
            List<Producer> producerlist = new List<Producer>()
            {
                new Producer() {FullName = "james katler" , Bio = "good Producer"},
                new Producer() {FullName = "Kamal Tabrizi" , Bio = "Iranian Producer"}
            };

            //_appDbContext.Producers.AddRange(producerlist);
            //_appDbContext.SaveChanges();
            return producerlist;
        }
    }
}
