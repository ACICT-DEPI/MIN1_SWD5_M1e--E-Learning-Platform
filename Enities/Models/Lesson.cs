using System.ComponentModel.DataAnnotations.Schema;

namespace Entites.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public  string Title { get; set; }
        public int ModuleId { get; set; }
        public bool IsDeleted { get; set; }=false;

        public virtual Module? Module { get; set; }
        public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
        public virtual ICollection<Note> Notes { get; set; } = new List<Note>();
        public virtual ICollection<Progress> Progresss { get; set; }= new List<Progress>(); 
        public virtual ICollection<Question> Questions { get; set; } =new List<Question>();
    }
}
