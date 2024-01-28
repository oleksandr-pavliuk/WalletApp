using Microsoft.EntityFrameworkCore;
using WalletApp.Domain;

namespace WalletApp.Infrastructure.DatabaseContext
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(/*db conn string*/);
        }
    }
}
