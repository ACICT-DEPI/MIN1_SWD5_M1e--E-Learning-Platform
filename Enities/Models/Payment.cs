namespace Entites.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string UserId { get; set; }
        public int CourseId { get; set; }
        public virtual User? User { get; set; }
        public virtual Course? Course { get; set; }
    }
}
