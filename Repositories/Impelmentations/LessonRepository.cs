using Enities.ViweModel;
using Entites.Data;
using Entites.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Impelmentations
{
    public class LessonRepository:BaseRepository<Lesson>,ILessonRepository
    {
       
        public LessonRepository(ElearingDbcontext context):base(context)
        {
            
        }
       
        public async Task<IQueryable<Lesson>> GetAllLesson(bool istracked)
        {
            return await FindByCondition(l=>!l.IsDeleted,istracked);
        }
        public async Task<Lesson> GetLessonById(int id, bool istracked)
        {
           var lesson= await FindByCondition(l=>l.Id==id,istracked);
            return await lesson.FirstOrDefaultAsync();
        }
        public async Task<ResponseVM> CreateNewLesson(Lesson lesson)
        {
            return await Create(lesson);
        }

        public async Task<IQueryable<Lesson>> GetAllLessonByMOduleId(int moduleid)
        {
            
            return await FindByCondition((l => l.ModuleId == moduleid&& !l.IsDeleted), false);
        }

        public async Task<ResponseVM> UpdateLesson(Lesson lesson)
        {
            return await Update(lesson);
        }

        public async Task<ResponseVM> DeleteLesson(Lesson lesson)
        {
            return await Delete(lesson);
        }

       
    }
}
