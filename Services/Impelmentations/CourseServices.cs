using AutoMapper;
using Enities.ViweModel.Course;
using Entites.Models;
using Repositories.Interfaces;
using Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Enities.ViweModel;
namespace Services.Impelmentations
{
    public sealed class CourseServices:ICourseServices
    {
        private readonly IRepositoryManger _repositoryManger;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public CourseServices(IRepositoryManger repositoryManger,IMapper mapper,IHttpContextAccessor httpContext)
        {
            _repositoryManger = repositoryManger;
            _mapper = mapper;
            _httpContext = httpContext;
        }
        private string GetUserId() 
        {
            return _httpContext.HttpContext.User.Identity.Name;
        }

        public IQueryable<GetCourseVM> GetAllCourcesAsync(bool istraked)
        {
            var courses = _repositoryManger.courseRepository.GetAllCourcesAsync(istraked);
            var Coursesdto= _mapper.Map<IQueryable<GetCourseVM>>(courses);
            return Coursesdto;
        }

        public GetCourseVM GetCourseByConditionAsync(int id, bool istracked)
        {
            var course = _repositoryManger.courseRepository.GetCourseByConditionAsync(id,istracked);
            var Coursedto = _mapper.Map<GetCourseVM>(course);
            return Coursedto;
        }

        public async Task<ResponseVM> CreateNewCourse(CreateCourseVM course)
        {
            Course newcourse=_mapper.Map<Course>(course);
            newcourse.InstractourId= "new-id";
           ResponseVM result= await _repositoryManger.courseRepository.CreateNewCourse(newcourse);
			if (result.isSuccess)
			{
				try
				{
					_repositoryManger.Save();

				}
				catch (Exception ex)
				{
					result.message += ex.Message;
				}
			}
			return result;
		}
    }
}
