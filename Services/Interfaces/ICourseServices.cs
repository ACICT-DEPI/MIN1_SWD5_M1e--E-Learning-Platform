﻿
using Enities.ViweModel;
using Enities.ViweModel.Course;
using Entites.Models;

namespace Services.Interfaces
{
    public interface ICourseServices
    {
      public Task<List<Course>> GetAllCourcesAsync(bool istraked);
        public Task<List<Course>> GetCoursesunpaidforUsers(bool istracked);
      public  Task<Course> GetCourseByIdAsync(int id, bool istracked);
        public Task<List<Course>> GetCourseByTeacherIdAsync(string id, bool istracked);
        public Task<List<Course>> GetCourseByUserIdAsync();
      public Task<ResponseVM> CreateNewCourse(CreateorUpdateCourseVM course);
      public Task<ResponseVM> UpdateCourse(CreateorUpdateCourseVM courseVM,int id);
      public Task<ResponseVM> DeleteCourseAsync(int id);

    }
}
