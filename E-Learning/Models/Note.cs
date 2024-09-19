namespace E_Learning.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime NoteDate { get; set; }
        public int LessonId  { get; set; }
        public string UserId { get; set; }
    }
}
