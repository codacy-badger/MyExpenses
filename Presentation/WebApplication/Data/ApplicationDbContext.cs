/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace WebApplication.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using MyExpenses.Infrastructure;

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //public override DbSet<MyExpenses.Domain.Domains.LabelDomain> Labels { get; set; }

        //public override DbSet<MyExpenses.Domain.Domains.ExpenseDomain> Expenses { get; set; }

        //public override DbSet<MyExpenses.Domain.Domains.PaymentDomain> Payments { get; set; }

        //public override DbSet<MyExpenses.Domain.Domains.GroupDomain> Groups { get; set; }
    }
}
