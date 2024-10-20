using Enities.ViweModel;
using Entites.Data;
using Entites.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Impelmentations
{
    public class EnrollmentRepository : BaseRepository<Enrolment>, IEnrollmentRepository
    {
        private readonly ElearingDbcontext _context;

        public EnrollmentRepository(ElearingDbcontext context) : base(context)
        {
            _context = context;
        }
        public async Task<IQueryable<Enrolment>> GettEnrollmentByUserId(string id, bool istracked)
        {
            return _context.Enrolments
               .Include(c => c.Course)
               .ThenInclude(c => c.User)
               .AsNoTracking()
               .Where(e => e.UserId == id);
        }
        public async Task<ResponseVM> CreateEnrollment(Enrolment enrolment)
        {
            try
            {
                await Create(enrolment);
                return new ResponseVM { isSuccess = true, message = "this process is success" };
            }
            catch (Exception ex)
            {
                return new ResponseVM { isSuccess = false, message = "this process is failed" };
            }
        }


    }
}
