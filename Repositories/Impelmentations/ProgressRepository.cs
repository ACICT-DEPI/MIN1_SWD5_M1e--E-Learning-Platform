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
	public class ProgressRepository : BaseRepository<Progress>, IProgressRepository
	{
		public ProgressRepository(ElearingDbcontext context) : base(context)
		{
		}
		public async Task<IQueryable<Progress>> GetProgress(string userid, int lessonid)
		{
			return await FindByCondition((p => p.UserId == userid && p.LessonId == lessonid),false);
		}
		public async Task<ResponseVM> CreateProgress(Progress progress)
		{
			return await Create(progress);
		}

		public async Task<ResponseVM> DeleteProgress(Progress progress)
		{ 
			return await Delete(progress);
		}
	}
}
