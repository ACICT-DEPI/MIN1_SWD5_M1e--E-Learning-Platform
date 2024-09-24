namespace Entites.Models
{
    public class Deposit
    {
        public int Id { get; set; }
        public DateTime DepositDate { get; set; }
        public decimal Amount { get; set; }
        public string UserId { get; set; }
    }
}
