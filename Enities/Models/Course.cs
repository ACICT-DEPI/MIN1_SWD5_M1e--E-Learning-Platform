using Enities.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entites.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double RatingSum { get; set; } = 0d;
        public double NumberOfRating { get; set; } = 0d;
        public DateTime CreationDate { get; set; }= DateTime.Now;
        public string Language { get; set; }
        public string SkillLevel { get; set; }
        public decimal Price { get; set; }
        public string Requirments { get; set; }
        public bool IsPublic { get; set; }= false;
        public bool IsDeleted { get; set; } = false;
        public int NumberOfStudents { get; set; } = 0;
        public string? InstractourId { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Module> Modules { get; set; } = new List<Module>();
        public virtual ICollection<Anouncment> Anouncments { get; set; }= new List<Anouncment>();
        public virtual ICollection<Enrolment> Enrolments { get; set; } = new List<Enrolment>();
        public virtual ICollection<Payment> Payments { get; set; }=new List<Payment>();
        public virtual ICollection<Question>Questions { get; set; }= new List<Question>();
		public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
	}
}
