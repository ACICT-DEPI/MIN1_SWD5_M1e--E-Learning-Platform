namespace Entites.Models
{
    public class Anouncment
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Text { get; set; }
        public virtual Course? Course { get; set; }
    }
}
