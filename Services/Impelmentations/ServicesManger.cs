using AutoMapper;
using Microsoft.AspNetCore.Http;
using Repositories.Interfaces;
using Services.Interfaces;


namespace Services.Impelmentations
{
    public sealed class ServicesManger : IServicesManger
    {
        private readonly IRepositoryManger _repositoryManger;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly Lazy<ICourseServices> _courseServices;
        private readonly Lazy<IModuleServices> _moduleServices;
        public ServicesManger(IRepositoryManger repositoryManger,IMapper mapper,IHttpContextAccessor httpContext) {
            _repositoryManger = repositoryManger;
            _mapper = mapper;
            _httpContext = httpContext;
            _courseServices =new Lazy<ICourseServices>(()=>
            new CourseServices(_repositoryManger,_mapper,_httpContext));
            _moduleServices = new Lazy<IModuleServices>(() =>
            new ModuleServices(_repositoryManger, _mapper));
        }
        public ICourseServices courseServices => _courseServices.Value;
        public IModuleServices moduleServices => _moduleServices.Value;
    }
}
