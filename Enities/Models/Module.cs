using System.ComponentModel.DataAnnotations.Schema;

namespace Entites.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CourseId { get; set; }
        public bool IsDeleted { get; set; } = false;

        public virtual Course? Course { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }=new List<Lesson>();
    }
}
