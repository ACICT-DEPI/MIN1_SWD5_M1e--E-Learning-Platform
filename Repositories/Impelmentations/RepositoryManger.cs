using Entites.Data;
using Entites.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Repositories.Interfaces;


namespace Repositories.Impelmentations
{
    public sealed class RepositoryManger : IRepositoryManger
    {
        private readonly ElearingDbcontext _context;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<User> _userManager;
        private readonly Lazy<ICourseRepository> _courseRepository;
        private readonly Lazy<IModuleRepository> _moduleRepository;
        private readonly Lazy<ILessonRepository> _lessonRepository;
        private readonly Lazy<IMaterialRepository> _materialRepository; 
        private readonly Lazy<IProgressRepository> _progressRepository;
        private readonly Lazy<INoteRepository> _noteRepository;
        private readonly Lazy<IPaymentRepository> _paymentRepository;
        private readonly Lazy<IEnrollmentRepository> _enrollmentRepository;
        private readonly Lazy<IQuestionRepository> _questionRepository;
        private readonly Lazy<IAnouncmentRepository> _anouncmentRepository;
        public RepositoryManger(ElearingDbcontext context, IHttpContextAccessor httpContext,UserManager<User> userManager)
        {
            _context = context;
            _httpContext = httpContext;
            _userManager = userManager;
            _courseRepository =new Lazy<ICourseRepository>(()=>
                new CourseRepository(context));
            _moduleRepository=new Lazy<IModuleRepository>(()=> 
            new ModuleRepository(context));
            _lessonRepository=new Lazy<ILessonRepository>(()=>
            new LessonRepository(context));
            _materialRepository=new Lazy<IMaterialRepository>(()=>
            new MaterialRepository(context));
            _progressRepository=new Lazy<IProgressRepository>(()=>
            new ProgressRepository(context));
            _noteRepository=new Lazy<INoteRepository>(()=>
            new NoteRepository(context));
            _paymentRepository=new Lazy<IPaymentRepository>(()=>
            new PaymentRepository(context));
            _enrollmentRepository=new Lazy<IEnrollmentRepository>(()=>
            new EnrollmentRepository(context));
          _questionRepository=new Lazy<IQuestionRepository>(()=>
            new QuestionRepository(context));
            _anouncmentRepository = new Lazy<IAnouncmentRepository>(()=>
            new AnouncmentRepository(context));
        }
        public ICourseRepository courseRepository => _courseRepository.Value;

		public IModuleRepository moduleRepository => _moduleRepository.Value;

        public ILessonRepository lessonRepository => _lessonRepository.Value;

        public IMaterialRepository materialRepository =>_materialRepository.Value;

		public IProgressRepository progressRepository =>_progressRepository.Value;

        public INoteRepository noteRepository => _noteRepository.Value;

        public IPaymentRepository paymentRepository => _paymentRepository.Value;
        public IQuestionRepository questionRepository => _questionRepository.Value;

        public IEnrollmentRepository enrollmentRepository => _enrollmentRepository.Value;
        public IAnouncmentRepository anouncmentRepository => _anouncmentRepository.Value;

        public async Task<string> GetCurrentUserId()
        {
            var user = await _userManager.FindByNameAsync(_httpContext.HttpContext.User.Identity.Name);
            return user.Id;
        }

        public async Task Save()
        {
           await _context.SaveChangesAsync();
        }
    }
}
