/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure
{
    using Microsoft.EntityFrameworkCore;

    public class MyExpensesContext : DbContext
    {
        public MyExpensesContext(DbContextOptions<MyExpensesContext> options)
            : base(options)
        {
        }

        public DbSet<MyExpenses.Domain.Domains.LabelDomain> Labels { get; set; }

        public DbSet<MyExpenses.Domain.Domains.ExpenseDomain> Expenses { get; set; }

        public DbSet<MyExpenses.Domain.Domains.PaymentDomain> Payments { get; set; }

        public DbSet<MyExpenses.Domain.Domains.GroupDomain> Groups { get; set; }
    }
}
