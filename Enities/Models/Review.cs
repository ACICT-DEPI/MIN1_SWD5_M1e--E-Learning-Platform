using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enities.Models
{
	public class Review
	{
		public double Rate {  get; set; } 
		public string UserId {  get; set; }
		public int CourseId {  get; set; }
		public virtual Course Course { get; set; } = new Course(); 
		public virtual User User {  get; set; } =new User();
	}
}
