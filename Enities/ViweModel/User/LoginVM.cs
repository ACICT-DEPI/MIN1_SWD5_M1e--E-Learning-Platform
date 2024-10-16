using System.ComponentModel.DataAnnotations;

namespace Entites.ViewModel.User
{
	public class LoginVM
	{
		[Required(ErrorMessage ="username is required ?")]   
		public string? UserName { get; set; }
		[DataType(DataType.Password)]
		[Required(ErrorMessage = "password is required ?")]
		public string? Password { get; set; }
		[Display(Name ="Remember Me")]
		public bool RememberMe { get; set; }
	}
}
