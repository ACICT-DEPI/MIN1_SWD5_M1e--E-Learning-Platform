using AutoMapper;
using Entites.Models;
using Enities.ViweModel.Course;
namespace E_Learning.MappingProfile
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, GetCourseVM>().ReverseMap();
            CreateMap<Course, CreateCourseVM>().ReverseMap();
        }
    }
}
