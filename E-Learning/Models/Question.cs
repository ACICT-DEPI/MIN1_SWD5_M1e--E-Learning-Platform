namespace E_Learning.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime QuestionDate { get; set; }
        public string UserId { get; set; }
        public int CourseId { get; set; }
        public int LessonId { get; set; }
    }
}
