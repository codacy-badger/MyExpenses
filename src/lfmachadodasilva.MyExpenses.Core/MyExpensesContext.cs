using lfmachadodasilva.MyExpenses.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace lfmachadodasilva.MyExpenses.Core
{
    internal class MyExpensesContext : DbContext
    {
        public MyExpensesContext(DbContextOptions<MyExpensesContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<LabelModel> Labels { get; set; }

        private DbSet<ExpenseModel> Expenses { get; set; }

        public DbSet<PaymentModel> Payments { get; set; }

        public DbSet<GroupModel> Groups { get; set; }
    }
}
