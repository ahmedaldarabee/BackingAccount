
using Microsoft.EntityFrameworkCore;
using UserBankAccount.Models;

namespace UserBankAccount.Data {
    public class APIDbContext : DbContext {

        public APIDbContext(DbContextOptions<APIDbContext> options): base(options) {}

        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }

    }
}
