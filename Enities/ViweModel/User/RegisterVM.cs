
using System.ComponentModel.DataAnnotations;

namespace Enities.ViewModel.User
{
	public class RegisterVM
	{
		[Required]
		public string? Name { get; set; }
		[Required]
		[DataType(DataType.EmailAddress)]
		public string? Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string? Password { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[Compare("Password",ErrorMessage ="password don't match ? ")]
		[Display(Name="confirm password")]
		public string? ConfirmPassword { get; set; }
	}
}
