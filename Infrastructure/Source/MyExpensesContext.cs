/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using MyExpenses.Infrastructure.Configuration;

    public class MyExpensesContext : IdentityDbContext
    {
        public MyExpensesContext(DbContextOptions<MyExpensesContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            
            base.OnConfiguring(optionsBuilder);
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.ApplyConfiguration(new LabelConfiguration());
        //}

        public virtual DbSet<MyExpenses.Domain.Domains.LabelDomain> Labels { get; set; }

        public virtual DbSet<MyExpenses.Domain.Domains.ExpenseDomain> Expenses { get; set; }

        public virtual DbSet<MyExpenses.Domain.Domains.PaymentDomain> Payments { get; set; }

        public virtual DbSet<MyExpenses.Domain.Domains.GroupDomain> Groups { get; set; }

        public virtual DbSet<MyExpenses.Domain.Domains.GroupUserDomain> GroupUsers { get; set; }
    }
}
