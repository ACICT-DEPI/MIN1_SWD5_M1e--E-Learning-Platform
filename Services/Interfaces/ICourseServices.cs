
using Entites.Models;

namespace Services.Interfaces
{
    public interface ICourseServices
    {
        Task<IQueryable<Course>> GetAllCourcesAsync(bool istraked);
    }
}
