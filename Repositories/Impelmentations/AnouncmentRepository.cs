using Enities.ViweModel;
using Entites.Data;
using Entites.Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Impelmentations
{
	public sealed class AnouncmentRepository : BaseRepository<Anouncment>,IAnouncmentRepository
	{
		public AnouncmentRepository(ElearingDbcontext dbcontext):base(dbcontext)
		{
		}

		public async Task<IEnumerable<Anouncment>> GetAllAnouncmentsByCourseId(int courseId, bool istracked)
		{
			return await FindByCondition(e=>e.CourseId == courseId, istracked);
		}

		public async Task<Anouncment> GetAnouncmentsById(int id)
		{
			return await FindById(e => e.Id == id);
		}

		public async Task<ResponseVM> CreateNewAnoundment(Anouncment anouncment)
		{
		 	return await Create(anouncment);
		}
		public async Task<ResponseVM> UpdateNewAnoundment(Anouncment anouncment)
		{
			return await Update(anouncment);
		}

		public async Task<ResponseVM> DeleteNewAnoundment(Anouncment anouncment)
		{
			return await Delete(anouncment);
		}

	}
}
