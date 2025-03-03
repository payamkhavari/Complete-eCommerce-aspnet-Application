using eTickets.Data.Base;
using eTickets.Models;
using System.Linq.Expressions;

namespace eTickets.Data.Services
{
    public class CinemaService : EntityBaseRepository<Cinema>, ICinemaService
    {
        
        public CinemaService(AppDbContext appDbContext) : base(appDbContext)
        {
            
        }
       
    }
}
