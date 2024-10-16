using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enities.ViweModel.User
{
    public class changePasswordVM
    {
        //[Required]
        //[DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        //[Required]
        //[DataType(DataType.Password)]
        public string? NewPassword { get; set; }
        //[Required]
        //[DataType(DataType.Password)]
       // [Compare("Password", ErrorMessage = "password don't match ? ")]
        //[Display(Name = "confirm New password")]
        public string? ConfirmNewPassword { get; set; }
    }
}
