namespace Entites.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime QuestionDate { get; set; }
        public string UserId { get; set; }
        public int CourseId { get; set; }
        public int LessonId { get; set; }
        public virtual User? User { get; set; } 
        public virtual Course? Course { get; set; }  
        public virtual Lesson? Lesson { get; set; }
        public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();
    }
}
