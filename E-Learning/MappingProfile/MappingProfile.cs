using AutoMapper;
using Entites.Models;
using Enities.ViweModel.Course;
using Enities.ViweModel.Module;
namespace E_Learning.MappingProfile
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, GetCourseVM>().ReverseMap();
            CreateMap<Course, CreateCourseVM>().ReverseMap();
            CreateMap<Module,CreateModuleVM>().ReverseMap();
            CreateMap<Module,GetModuleVM>().ReverseMap();   
        }
    }
}
