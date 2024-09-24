

using Entites.Models;

namespace Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task<IQueryable<Course>> GetAllCourcesAsync(bool istraked);
    }
}
