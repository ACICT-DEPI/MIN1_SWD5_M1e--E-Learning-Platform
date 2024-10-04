using AutoMapper;
using Entites.Models;
using Enities.ViweModel.Course;
using Enities.ViweModel.Module;
using Enities.ViweModel.Lesson;
using Enities.ViweModel.Material;
using Enities.ViweModel.Progress;
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
            CreateMap<Lesson,CreateLessonVM>().ReverseMap();
            CreateMap<Lesson,GetLessonVM>().ReverseMap();
            CreateMap<Material, GetMaterialsVM>().ReverseMap();
            CreateMap<Progress, CreateProgressVM>().ReverseMap();
            CreateMap<Progress, GetProgressVM>().ReverseMap();
        }
    }
}
