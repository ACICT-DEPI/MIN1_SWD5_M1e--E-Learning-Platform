namespace Entites.Models
{
    public class Enrolment
    {
        public string UserId {  get; set; } 
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int Achieved { get; set; }

    }
}
