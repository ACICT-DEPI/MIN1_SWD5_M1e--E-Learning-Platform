using Enities.ViweModel;
using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        public Task<IQueryable<Payment>> GetAllPaymentsByUserId(string userId,bool istracked);
        public Task<IQueryable<Payment>> GetAllPayments(bool istracked);
        public Task<Payment> GetPaymentById(int id, bool istracked);
        public Task<ResponseVM> CreatePayment(Payment payment);
        public Task<ResponseVM> DeletePayment(Payment payment);

    }
}
