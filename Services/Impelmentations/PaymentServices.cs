using AutoMapper;
using Enities.ViweModel;
using Enities.ViweModel.Payment;
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
    public sealed class PaymentServices : IPaymentServices
    {
        private readonly IRepositoryManger _repositoryManger;
        private readonly IMapper _mapper;

        public PaymentServices(IRepositoryManger repositoryManger,IMapper mapper)
        {
            _repositoryManger = repositoryManger;
            _mapper = mapper;
        }
        public async Task<List<GetPaymentVM>> GetAllPayments()
        {
            try
            {
                var payments = await _repositoryManger.paymentRepository.GetAllPayments(false);
                var paymentVM = _mapper.Map<List<GetPaymentVM>>(payments);
                return paymentVM;
            }
            catch
            {
                return new List<GetPaymentVM>();
            }
        }

        public async Task<List<GetPaymentVM>> GetAllPaymentsByUserId(string userId)
        {
            try
            {
                var payments = await _repositoryManger.paymentRepository.GetAllPaymentsByUserId(userId,false);
                var paymentVM = _mapper.Map<List<GetPaymentVM>>(payments);
                return paymentVM;
            }
            catch
            {
                return new List<GetPaymentVM>();
            }
        }
        public async Task<ResponseVM> CreatePayment(CreatePaymentVM model)
        {
            var payment= _mapper.Map<Payment>(model);
            payment.UserId = "new-id";
            var result = await _repositoryManger.paymentRepository.CreatePayment(payment);
            if(result.isSuccess)
            {
                try
                {
                    await _repositoryManger.Save();
                }
                catch(Exception ex)
                {
                    result.isSuccess = false;
                    result.message = ex.Message.ToString();
                }
            }
            return result;
        }

        public async Task<ResponseVM> DeletePayment(int id)
        {
            var payment = await _repositoryManger.paymentRepository.GetPaymentById(id,false);
            if (payment != null)
            {

                var result = await _repositoryManger.paymentRepository.DeletePayment(payment);
                if (result.isSuccess)
                {
                    try
                    {
                        await _repositoryManger.Save();
                    }
                    catch (Exception ex)
                    {
                        result.isSuccess = false;
                        result.message = ex.Message.ToString();
                    }
                }
                return result;
            }
            return new ResponseVM { isSuccess = false ,message="Payment Not Found"};
        }

        
    }
}
