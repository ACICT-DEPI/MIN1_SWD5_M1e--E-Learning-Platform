using Enities.ViweModel.Anouncment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAnouncmentServices
    {
        public Task<List<GetAnouncmentForStudentVM>> GetAnouncmentForStudent(int courseId);
    }
}
