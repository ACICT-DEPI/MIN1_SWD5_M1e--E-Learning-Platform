using Entites.Data;
using Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;



namespace Repositories.Impelmentations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ElearingDbcontext _context;
        public BaseRepository(ElearingDbcontext context)
        {
            context = _context;
        }

        public IQueryable<T> FindAll(bool istracked)
        {
            return !istracked? 
                _context.Set<T>()
                .AsNoTracking():
                _context.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition, bool istracked)
        {
            return !istracked?
                _context.Set<T>()
                .Where(condition)
                .AsNoTracking():
                _context.Set<T>()
                .Where(condition);
        }
        public void Create(T entity)
        {
            _context.Set<T>().AddAsync(entity);
        }
        public void Update(T entity)
        {
           _context.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
       
    }
}
