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
    internal class AnswerRepository : BaseRepository<Answer>, IAnswerRepository
    {
        private readonly ElearingDbcontext _context;

        public AnswerRepository(ElearingDbcontext context) : base(context)
        {
            _context = context;
        }
        public Task<ResponseVM> CreateAnswer(Entites.Models.Answer answer)
        {
            return Create(answer);
        }
    }
}
