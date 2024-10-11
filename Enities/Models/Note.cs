namespace Entites.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime NoteDate { get; set; }= DateTime.Now;
        public int LessonId  { get; set; }
        public string UserId { get; set; }

        public virtual Lesson? Lesson { get; set; }
        public virtual User? User { get; set; }  
  
    }
}
