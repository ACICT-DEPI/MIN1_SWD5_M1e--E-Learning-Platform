using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enities.ViweModel.Payment
{
    public class GetPaymentVM
    {
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int CourseId { get; set; }
    }
}
