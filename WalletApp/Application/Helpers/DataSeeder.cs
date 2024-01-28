using WalletApp.Domain;
using WalletApp.Infrastructure.DatabaseContext;

namespace WalletApp.Application.Helpers
{
    public static class DataSeeder
    {


        public static void Seed()
        {
            using (var _context = new ApplicationContext())
            {
                if (_context.Users.Count() == 0 && _context.Transactions.Count() == 0)
                {
                    var user = new User() { Points = 1043, Balance = 1000, Name = "Oleksandr", LastDatePoint = DateOnly.FromDateTime(DateTime.UtcNow), LastPoint= 0.5, PreLastPoint = 0.7 };

                    var transactionList = new List<Transaction>()
                {
                    new Transaction() { User = user, Bank = "monobank", Date = DateTime.UtcNow, Description = "Purchases", Name = "Netflix",
                                        Sum = -120.00M, TransactionStatus = Status.Accepted },
                    new Transaction() { User = user, Bank = "wallet", Date = DateTime.UtcNow, Description = "Income", Name = "Apple",
                                        Sum = 100.00M, TransactionStatus = Status.Pending, UserSender = "Alex"}
                };

                    _context.Users.Add(user);
                    _context.Transactions.AddRange(transactionList);
                    _context.SaveChanges();
                }
            }   
        }
    }
}
