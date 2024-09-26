using Entites.Data;
using Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Enities.ViweModel;



namespace Repositories.Impelmentations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ElearingDbcontext _context;
        public BaseRepository(ElearingDbcontext context)
        {
            _context = context;
        }

        public async Task<IQueryable<T>> FindAll(bool istracked)
        {
            return !istracked? 
                _context.Set<T>()
                .AsNoTracking():
                _context.Set<T>();
        }

        public  IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition, bool istracked)
        {
            return !istracked?
                 _context.Set<T>()
                .Where(condition)
                .AsNoTracking():
                _context.Set<T>()
                .Where(condition);
        }
        public async Task<ResponseVM> Create(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                return new ResponseVM { isSuccess = true, model = entity, message = "the Process of add Success" };
            }
            catch (Exception ex) {
                return new ResponseVM { isSuccess = false, model = entity, message = ex.Message.ToString() };

            }
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
