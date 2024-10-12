using AutoMapper;
using Microsoft.AspNetCore.Http;
using Repositories.Interfaces;
using Services.Implementations;
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
        private readonly Lazy<ILessonService> _lessonService;
        private readonly Lazy<IUploadFileService> _uploadFileServices;
        private readonly Lazy<IMaterialServices> _materialServices;
        private readonly Lazy<IProgressServices> _progressServices;
        private readonly Lazy<INoteServices> _noteServices;
        public ServicesManger(IRepositoryManger repositoryManger,IMapper mapper,IHttpContextAccessor httpContext) {
            _repositoryManger = repositoryManger;
            _mapper = mapper;
            _httpContext = httpContext;
            _courseServices =new Lazy<ICourseServices>(()=>
            new CourseServices(_repositoryManger,_mapper,_httpContext));
            _moduleServices = new Lazy<IModuleServices>(() =>
            new ModuleServices(_repositoryManger, _mapper));
            _lessonService = new Lazy<ILessonService>(() =>
            new LessonService(_repositoryManger,_mapper));
            _uploadFileServices = new Lazy<IUploadFileService>(() => 
            new UploadFileService());
            _materialServices = new Lazy<IMaterialServices>(() =>
            new MaterialServices(_repositoryManger,_mapper));
            _progressServices = new Lazy<IProgressServices>(() =>
            new ProgressServices(_repositoryManger, _mapper));
            _noteServices = new Lazy<INoteServices>(() =>
            new NoteServices(_repositoryManger, _mapper));
        }
        public ICourseServices courseServices => _courseServices.Value;
        public IModuleServices moduleServices => _moduleServices.Value;

        public ILessonService lessonServices => _lessonService.Value;

        public IUploadFileService uploadFileServices => _uploadFileServices.Value;

        public IMaterialServices materialServices => _materialServices.Value;

		public IProgressServices progressServices => _progressServices.Value;

        public INoteServices noteServices => _noteServices.Value;
    }
}
