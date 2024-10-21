using Enities.ViweModel;
using Enities.ViweModel.Enrollment;
using Entites.Models;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IEnrollmentServices
    {
        Task<List<Enrolment>> GettEnrollmentByUserId();
        Task<ResponseVM> CreateEnrollment(Session session);
    }
}
