/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using MyExpenses.Domain.Domains;

    public class MyExpensesContext : IdentityDbContext
    {
        public MyExpensesContext(DbContextOptions<MyExpensesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MyExpenses.Domain.Domains.LabelDomain> Labels { get; set; }

        public virtual DbSet<MyExpenses.Domain.Domains.ExpenseDomain> Expenses { get; set; }

        public virtual DbSet<MyExpenses.Domain.Domains.PaymentDomain> Payments { get; set; }

        public virtual DbSet<MyExpenses.Domain.Domains.GroupDomain> Groups { get; set; }
    }
}
