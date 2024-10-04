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

        public async Task<List<Course>> GetAllCourcesAsync(bool istraked)
        {
            var courses = await _repositoryManger.courseRepository.GetAllCourcesAsync(istraked);
            var Coursesdto= _mapper.Map<List<Course>>(courses);
            return Coursesdto;
        }

        public async Task<Course> GetCourseByIdAsync(int id, bool istracked)
        {
            var course =await _repositoryManger.courseRepository.GetCourseByIdAsync(id,istracked);
            
            return course;
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
				 await	_repositoryManger.Save();

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
