namespace WalletApp.Presentation.DTOs
{
    public class TransactionDto
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public decimal sum { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int transaction_status {  get; set; }
        public DateTime date {  get; set; }
        public string bank { get; set; }
    }
}
