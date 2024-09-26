using Enities.ViweModel;
using System.Linq.Expressions;

namespace Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IQueryable<T>> FindAll(bool istracked);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition,bool istracked);
        Task<ResponseVM> Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
