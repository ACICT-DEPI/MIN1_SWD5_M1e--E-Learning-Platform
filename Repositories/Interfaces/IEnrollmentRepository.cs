using Enities.ViweModel;
using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task<IQueryable<Enrolment>> GettEnrollmentByUserId(string id, bool istracked);
        Task<ResponseVM> CreateEnrollment(Enrolment enrolment);

     }
}
