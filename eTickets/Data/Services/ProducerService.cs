using eTickets.Data;
using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public class ProducerService : EntityBaseRepository<Producer> ,IProducerService
    {
        private readonly AppDbContext _appDbContext;
        public ProducerService(AppDbContext appDbContext):base(appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public void UpdateProducer(Producer producer)
        {
            var result = _appDbContext.Producers.FirstOrDefault(x => x.Id == producer.Id);

            if (result == null)
            {
                throw new Exception("Movie not found");
            }
            else 
            {
                result.Bio = producer.Bio;
                result.ProfilePictureUrl = producer.ProfilePictureUrl;
                result.FullName = producer.FullName;
            }
            _appDbContext.Producers.Update(producer);
            _appDbContext.SaveChanges();
        }
    }
}
