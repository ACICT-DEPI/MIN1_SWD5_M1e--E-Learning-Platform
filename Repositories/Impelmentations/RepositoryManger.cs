using Entites.Data;
using Repositories.Interfaces;


namespace Repositories.Impelmentations
{
    public sealed class RepositoryManger : IRepositoryManger
    {
        private readonly ElearingDbcontext _context;
        private readonly Lazy<ICourseRepository> _courseRepository;
        private readonly Lazy<IModuleRepository> _moduleRepository;
        public RepositoryManger(ElearingDbcontext context)
        {
            _context = context;
            _courseRepository=new Lazy<ICourseRepository>(()=>
                new CourseRepository(context));
            _moduleRepository=new Lazy<IModuleRepository>(()=> 
            new ModuleRepository(context));
        }
        public ICourseRepository courseRepository => _courseRepository.Value;

		public IModuleRepository moduleRepository => _moduleRepository.Value;

		public async Task Save()
        {
           await _context.SaveChangesAsync();
        }
    }
}
