using AutoMapper;
using Enities.Models;
using Entites.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
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
		private readonly IOptions<StripeSetting> _stripeSetting;
		private readonly UserManager<User> _userManager;
		private readonly IOptions<PayPalSetting> _payPalSetting;
		private readonly Lazy<ICourseServices> _courseServices;
		private readonly Lazy<IModuleServices> _moduleServices;
		private readonly Lazy<ILessonService> _lessonService;
		private readonly Lazy<IUploadFileService> _uploadFileServices;
		private readonly Lazy<IMaterialServices> _materialServices;
		private readonly Lazy<IProgressServices> _progressServices;
		private readonly Lazy<IPaymentServices> _paymentServices;
		private readonly Lazy<IStripeServices> _stripeServices;
		private readonly Lazy<IPayPalServices> _payPalServices;
		private readonly Lazy<INoteServices> _noteServices;
		private readonly Lazy<IEnrollmentServices> _enrollmentServices;
		private readonly Lazy<IAnouncmentServices> _anouncmentServices;

		public ServicesManger(IRepositoryManger repositoryManger, IMapper mapper, IHttpContextAccessor httpContext,
				IOptions<StripeSetting> stripeSetting, UserManager<User> userManager, IOptions<PayPalSetting> payPalSetting)
		{

			_repositoryManger = repositoryManger;
			_mapper = mapper;
			_httpContext = httpContext;
			_stripeSetting = stripeSetting;
			_userManager = userManager;
			_payPalSetting = payPalSetting;
			_courseServices = new Lazy<ICourseServices>(() =>
			new CourseServices(_repositoryManger, _mapper, _httpContext,_userManager));
			_moduleServices = new Lazy<IModuleServices>(() =>
			new ModuleServices(_repositoryManger, _mapper));
			_lessonService = new Lazy<ILessonService>(() =>
			new LessonService(_repositoryManger, _mapper));
			_uploadFileServices = new Lazy<IUploadFileService>(() =>
			new UploadFileService());
			_materialServices = new Lazy<IMaterialServices>(() =>
			new MaterialServices(_repositoryManger, _mapper));
			_progressServices = new Lazy<IProgressServices>(() =>
			new ProgressServices(_repositoryManger, _mapper));
			_paymentServices = new Lazy<IPaymentServices>(() =>
			new PaymentServices(_repositoryManger, _mapper,_userManager,_httpContext));
			_stripeServices = new Lazy<IStripeServices>(() =>
			new StripeServices(httpContext, _stripeSetting, _userManager));
			_payPalServices = new Lazy<IPayPalServices>(() =>
			new PayPalServices(_payPalSetting, httpContext));
			_noteServices = new Lazy<INoteServices>(() =>
			new NoteServices(_repositoryManger, _mapper));
			_enrollmentServices=new Lazy<IEnrollmentServices>(()=>
			new EnrollmentServices(_repositoryManger, _mapper,_userManager,_httpContext));
            _anouncmentServices = new Lazy<IAnouncmentServices>(()=>
			new AnouncmentServices(_repositoryManger, _mapper));

		}
		public ICourseServices courseServices => _courseServices.Value;
		public IModuleServices moduleServices => _moduleServices.Value;

		public ILessonService lessonServices => _lessonService.Value;

		public IUploadFileService uploadFileServices => _uploadFileServices.Value;

		public IMaterialServices materialServices => _materialServices.Value;

		public IProgressServices progressServices => _progressServices.Value;

		public IPaymentServices paymentServices => _paymentServices.Value;

		public IStripeServices stripeServices => _stripeServices.Value;

		public IPayPalServices payPalServices => _payPalServices.Value;
		public INoteServices noteServices => _noteServices.Value;

        public IEnrollmentServices enrollmentServices => _enrollmentServices.Value;

        public IAnouncmentServices anouncmentServices => _anouncmentServices.Value;
    }
}