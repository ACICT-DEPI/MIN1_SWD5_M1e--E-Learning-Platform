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

        public async Task <IQueryable<T>> FindByCondition(Expression<Func<T, bool>> condition, bool istracked)
        {
            return !istracked?
                 _context.Set<T>()
                .Where(condition)
                .AsNoTracking():
                _context.Set<T>()
                .Where(condition);
        }
		public  Task<T> FindById(Expression<Func<T,bool>> condition)
		{
            var entity =  _context.Set<T>().SingleOrDefaultAsync(condition);

			return entity;
			   
		}
		public async Task<ResponseVM> Create(T entity)
        {
            try
            {
                var newEntity=await _context.Set<T>().AddAsync(entity);

                return new ResponseVM { isSuccess = true, model = newEntity, message = "the Process of add Success" };
            }
            catch (Exception ex) {
                return new ResponseVM { isSuccess = false, model = entity, message = ex.Message.ToString() };

            }
        }
        public async Task<ResponseVM> Update(T entity)
        {
            try
            {
                var updatedEntity = _context.Set<T>().Update(entity);
                return new ResponseVM { isSuccess = true, model = updatedEntity, message = "the Process od update Success" };
            }
            catch (Exception ex)
            {
                return new ResponseVM { isSuccess = false, model = entity, message = ex.Message.ToString() };
            }
        }
        public async Task<ResponseVM> Delete(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                return new ResponseVM { isSuccess = true, model = entity, message = "the Process od Delete Success" };
            }
            catch (Exception ex)
            {
                return new ResponseVM { isSuccess = false,model=entity, message = ex.Message.ToString() };
            }
        }

		
	}
}
