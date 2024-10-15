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
    public sealed class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ElearingDbcontext context) : base(context)
        {
        }
        public async Task<IQueryable<Payment>> GetAllPayments(bool istracked)
        {
           return await FindAll(istracked);
        }

        public async Task<IQueryable<Payment>> GetAllPaymentsByUserId(string userId, bool istracked)
        {
            return await FindByCondition(p=>p.UserId==userId, istracked);
        }
        public async Task<Payment> GetPaymentById(int id,bool istracked)
        {
            var payment = await FindByCondition(p => p.Id == id, istracked);
            return payment.First();
        }
        public async Task<ResponseVM> CreatePayment(Payment payment)
        {
           return await Create(payment);
        }

        public async Task<ResponseVM> DeletePayment(Payment payment)
        {
           return await Delete(payment);
        }

       
    }
}
