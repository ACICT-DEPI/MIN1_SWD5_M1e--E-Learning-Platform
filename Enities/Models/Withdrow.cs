namespace Entites.Models
{
    public class Withdrow
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime WithdrowDate { get; set; }
        public string UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
