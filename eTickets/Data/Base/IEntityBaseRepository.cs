using eTickets.Models;
using System.Linq.Expressions;

namespace eTickets.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class ,IEntityBase ,new()
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes);
        T GetById(int id, Expression<Func<T, object>> include);
        IEnumerable<T> GetById(int id,params Expression<Func<T, object>>[] includes);
        T GetByIdIncludes(int id, params Expression<Func<T, object>>[] includes);
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
