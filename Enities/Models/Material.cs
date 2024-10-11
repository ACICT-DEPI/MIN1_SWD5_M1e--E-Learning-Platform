using System.ComponentModel.DataAnnotations.Schema;

namespace Entites.Models
{
    public class Material
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public string? Path { get; set; }
        public string? Type { get; set; }
        public DateTime UploadDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;

        public virtual Lesson? Lesson { get; set; }
    }
}
