namespace WalletApp.Domain
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status TransactionStatus { get; set; }
        public DateTime Date { get; set; }
        public string Bank { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }

    public enum Status
    {
        Pending = 1,
        Accepted
    }
}
