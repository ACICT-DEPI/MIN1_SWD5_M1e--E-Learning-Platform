using Enities.ViweModel;
using Entites.Data;
using Entites.Models;
using Microsoft.AspNetCore.Identity;
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
        private readonly ElearingDbcontext _context;
        private readonly UserManager<User> _userManager;
        public LessonRepository(ElearingDbcontext context):base(context)
        {
            _context = context;
        }
       
        public async Task<IQueryable<Lesson>> GetAllLesson(bool istracked)
        {
            return await FindByCondition(l=>!l.IsDeleted,istracked);
        }
        public async Task<ResponseVM> CreateNewLesson(Lesson lesson)
        {
            return await Create(lesson);
        }

        public async Task<IQueryable<Lesson>> GetAllLessonByMOduleId(int moduleid)
        {
            
            return await FindByCondition((l => l.ModuleId == moduleid&& !l.IsDeleted), false);
        }
    }
}
