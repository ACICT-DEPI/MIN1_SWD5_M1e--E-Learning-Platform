using Enities.ViweModel;
using Enities.ViweModel.AnswerVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAnswerServices
    {
        public Task<ResponseVM> CreateAnswer(CreateAnswerVM answer);
    }
}
