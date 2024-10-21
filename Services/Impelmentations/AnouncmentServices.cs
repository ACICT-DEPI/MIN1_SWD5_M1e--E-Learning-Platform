using AutoMapper;
using Enities.ViweModel.Anouncment;
using Entites.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impelmentations
{
    public sealed class AnouncmentServices : IAnouncmentServices
    {
        private IRepositoryManger _repositoryManger;
        private IMapper _mapper;


        public AnouncmentServices(IRepositoryManger repositoryManger, IMapper mapper)
        {
            _repositoryManger = repositoryManger;
            _mapper = mapper; 
        }

        public async Task<List<GetAnouncmentForStudentVM>> GetAnouncmentForStudent(int courseId)
        {
            try
            {
                var anouncment = await _repositoryManger.anouncmentRepository.GetAllAnouncmentsByCourseId(courseId, false);
                var anouncmentVM = _mapper.Map<List<GetAnouncmentForStudentVM>>(anouncment);
                return anouncmentVM;
            }
            catch 
            { 
                return new List<GetAnouncmentForStudentVM> { };
            }
        }
    }

}
