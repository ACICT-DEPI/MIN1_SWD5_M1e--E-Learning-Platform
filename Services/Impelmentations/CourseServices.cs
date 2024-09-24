using Entites.Models;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Impelmentations
{
    public sealed class CourseServices:ICourseServices
    {
        private readonly IRepositoryManger _repositoryManger;
        public CourseServices(IRepositoryManger repositoryManger)
        {
            _repositoryManger = repositoryManger;
        }

        public async Task<IQueryable<Course>> GetAllCourcesAsync(bool istraked)
        {
            return await _repositoryManger.courseRepository.GetAllCourcesAsync(istraked);
        }
    }
}
