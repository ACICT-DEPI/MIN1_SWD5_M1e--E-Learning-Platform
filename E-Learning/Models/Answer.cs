namespace E_Learning.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
        public DateTime AnswerDate { get; set; }
    }
}
