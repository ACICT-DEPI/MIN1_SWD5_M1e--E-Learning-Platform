using AutoMapper;
using Enities.ViweModel;
using Enities.ViweModel.AnswerVM;
using Entites.Models;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impelmentations
{
    public class AnswerServices : IAnswerServices
    {
        private readonly IRepositoryManger _repositoryManger;
        private readonly IMapper _mapper;

        public AnswerServices(IRepositoryManger repositoryManger, IMapper mapper)
        {
            _repositoryManger = repositoryManger;
            _mapper = mapper;
        }
        public async Task<ResponseVM> CreateAnswer(CreateAnswerVM answer)
        {
            var answerMapped = _mapper.Map<Answer>(answer);
            answerMapped.UserId = await _repositoryManger.GetUserId();
            var result = await _repositoryManger.answerRepository.CreateAnswer(answerMapped);
            if (result.isSuccess)
            {
                try
                {
                    await _repositoryManger.Save();
                }
                catch (Exception ex)
                {
                    result.message = ex.Message.ToString();
                }

            }
            return result;
        }
    }
}
