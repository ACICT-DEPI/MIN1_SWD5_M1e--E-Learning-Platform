using Entites.Data;
using Repositories.Interfaces;


namespace Repositories.Impelmentations
{
    public sealed class RepositoryManger : IRepositoryManger
    {
        private readonly ElearingDbcontext _context;
        private readonly Lazy<ICourseRepository> _courseRepository;
        public RepositoryManger(ElearingDbcontext context)
        {
            _context = context;
            _courseRepository=new Lazy<ICourseRepository>(()=>
                new CourseRepository(context));
        }
        public ICourseRepository courseRepository => _courseRepository.Value;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
