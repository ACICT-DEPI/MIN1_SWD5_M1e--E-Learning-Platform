namespace Entites.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string TItle { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public DateTime CreationDate { get; set; }
        public string Language { get; set; }
        public string SkillLevel { get; set; }
        public decimal Price { get; set; }
        public string Requirments { get; set; }
        public string InstractourId { get; set; }

    }
}
