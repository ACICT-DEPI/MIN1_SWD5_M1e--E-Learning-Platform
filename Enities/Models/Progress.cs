namespace Entites.Models
{
    public class Progress
    {
        public string UserId { get; set; }
        public int LessonId { get; set; }
        public virtual Lesson? Lesson { get; set; }
        public virtual User? User { get; set; }  
    }
}
