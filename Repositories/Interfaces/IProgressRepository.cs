using Enities.ViweModel;
using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
	public interface IProgressRepository
	{
		
		Task<IQueryable<Progress>> GetProgress(string userid, int lessonid);
		Task<ResponseVM> CreateProgress(Progress progress);
		Task<ResponseVM> DeleteProgress(Progress progress);
	}
}
