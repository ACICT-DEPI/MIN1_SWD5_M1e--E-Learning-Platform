using Enities.Models;
using Microsoft.AspNetCore.Identity;

namespace Entites.Models
{
    public class User:IdentityUser
    {
        public string Name {  get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public decimal? Balance { get; set; }
        
        public string? image { get; set; }
        public virtual ICollection<Course> Courses { get; set; }=new HashSet<Course>();
        public virtual ICollection<Answer> Answers { get;set; }=new HashSet<Answer>();
        public virtual ICollection<Deposit> Deposits { get;set;}=new HashSet<Deposit>();
        public virtual ICollection<Enrolment> Enrolments { get; set; } = new List<Enrolment>();
        public virtual ICollection<Note> Notes { get; set; } = new List<Note>();
        public virtual ICollection<Payment> Payments { get; set;}=new HashSet<Payment>();
        public virtual ICollection<Progress> Progresses { get;set ; }=new HashSet<Progress>();
        public virtual ICollection<Question> Questions { get; set; }=new HashSet<Question>();
        public virtual ICollection<Withdrow> Withdrows { get; set; } =new HashSet<Withdrow>();
		public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
	}
}
