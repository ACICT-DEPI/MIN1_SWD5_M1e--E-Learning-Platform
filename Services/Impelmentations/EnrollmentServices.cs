using AutoMapper;
using Enities.ViweModel;
using Enities.ViweModel.Enrollment;
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
    public class EnrollmentServices : IEnrollmentServices
    {
        private readonly IRepositoryManger _repositoryManger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EnrollmentServices(IRepositoryManger repositoryManger,IMapper mapper,
            UserManager<User> userManager,IHttpContextAccessor httpContextAccessor)
        {
            _repositoryManger = repositoryManger;
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        private async Task<string> GetUserId()
        {
            var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            return user.Id;
        }
        public async Task<List<Enrolment>> GettEnrollmentByUserId()
        {
            var enrollment = await _repositoryManger.enrollmentRepository.GettEnrollmentByUserId(await GetUserId(), false);
            var enrollmentdto = _mapper.Map<List<Enrolment>>(enrollment);
            return enrollmentdto;
        }
        public async Task<ResponseVM> CreateEnrollment(CreateEnrollmentVM enrolment)
        {
            var newenrollment = _mapper.Map<Enrolment>(enrolment);
            newenrollment.UserId = await GetUserId();
            try
            {
               var result= await _repositoryManger.enrollmentRepository.CreateEnrollment(newenrollment);
                if (result.isSuccess)
                {
                    return result;
                }
                result.isSuccess = false;
                result.message = "the process is faild";
                return result;
            }
            catch (Exception ex)
            {
                return new ResponseVM { isSuccess = false ,message=ex.Message};
            }
        }

       
    }
}
