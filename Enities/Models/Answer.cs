namespace Entites.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
        public DateTime AnswerDate { get; set; }
        public virtual Question? Question { get; set; }
        public virtual User? User { get; set; }
    }
}
