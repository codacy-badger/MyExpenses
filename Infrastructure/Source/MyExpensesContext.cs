/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure
{
    using Microsoft.EntityFrameworkCore;

    using MyExpenses.Domains;

    public class MyExpensesContext : DbContext
    {
        public MyExpensesContext(DbContextOptions<MyExpensesContext> options)
            : base(options)
        {
        }

        public DbSet<LabelDomain> Label { get; set; }

        public DbSet<ExpenseDomain> Expense { get; set; }

        public DbSet<PaymentDomain> Payment { get; set; }
    }
}
