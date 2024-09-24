using Repositories.Interfaces;
using Services.Interfaces;


namespace Services.Impelmentations
{
    public sealed class ServicesManger : IServicesManger
    {
        private readonly IRepositoryManger _repositoryManger;
        private readonly Lazy<ICourseServices> _courseServices;
        public ServicesManger(IRepositoryManger repositoryManger) {
            _repositoryManger = repositoryManger;
            _courseServices=new Lazy<ICourseServices>(()=>
            new CourseServices(_repositoryManger));
        }
        public ICourseServices courseServices => _courseServices.Value;
    }
}
