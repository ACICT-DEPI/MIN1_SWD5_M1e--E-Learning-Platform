using Enities.ViweModel;
using System.Linq.Expressions;

namespace Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IQueryable<T>> FindAll(bool istracked);
        Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> condition,bool istracked);
        Task<T> FindById(Expression<Func<T, bool>> condition);
        Task<ResponseVM> Create(T entity);
        Task<ResponseVM> Update(T entity);
        Task<ResponseVM> Delete(T entity);
    }
}
