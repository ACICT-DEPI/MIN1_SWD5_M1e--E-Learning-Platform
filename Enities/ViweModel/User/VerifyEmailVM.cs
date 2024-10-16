using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enities.ViweModel.User
{
    public class verifyEmailVM
    {
        [Required(ErrorMessage = "Email required ")]
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; } 
        
    }
}
