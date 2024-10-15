using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enities.ViweModel.User
{
	public class LoginVM
	{
		 [Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
         [Required] 
		 [DataType(DataType.Password)]
	    public string Password { get; set; }

	}
}
