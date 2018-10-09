/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure
{
    using Microsoft.EntityFrameworkCore;

    using MyExpenses.Infrastructure.Tables;

    public class MyExpensesContext : DbContext
    {
        public MyExpensesContext(DbContextOptions<MyExpensesContext> options)
            : base(options)
        {
        }

        public DbSet<LabelTable> Labels { get; set; }

        public DbSet<ExpenseTable> Expenses { get; set; }

        public DbSet<PaymentTable> Payments { get; set; }

        public DbSet<GroupTable> Groups { get; set; }
    }
}
