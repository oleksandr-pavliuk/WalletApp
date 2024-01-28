namespace WalletApp.Domain
{
    public class User
    {
        public int Id { get; set; }
        public double Points { get; set; }
        public decimal Balance { get; set; }
        public string Name { get; set; }
        public double LastPoint {  get; set; }
        public double PreLastPoint { get; set; }
        public DateOnly LastDatePoint { get; set; }
    }
}
