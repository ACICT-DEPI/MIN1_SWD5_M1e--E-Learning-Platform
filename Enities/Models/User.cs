using Microsoft.AspNetCore.Identity;

namespace Entites.Models
{
    public class User:IdentityUser
    {
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public decimal Balance { get; set; }
        public string image { get; set; }

    }
}
