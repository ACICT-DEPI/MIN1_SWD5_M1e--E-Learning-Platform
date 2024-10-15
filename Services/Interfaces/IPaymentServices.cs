using Enities.ViweModel;
using Enities.ViweModel.Payment;
using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPaymentServices
    {
        public Task<List<GetPaymentVM>> GetAllPaymentsByUserId(string userId);
        public Task<List<GetPaymentVM>> GetAllPayments();
        public Task<ResponseVM> CreatePayment(CreatePaymentVM model);
        public Task<ResponseVM> DeletePayment(int id);
    }
}
