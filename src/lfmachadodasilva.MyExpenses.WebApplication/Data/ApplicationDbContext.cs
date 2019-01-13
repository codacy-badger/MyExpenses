using Microsoft.EntityFrameworkCore;
using lfmachadodasilva.MyExpenses.Core;

namespace lfmachadodasilva.MyExpenses.WebApplication.Data
{
    public class ApplicationDbContext : MyExpensesContext
    {
        public ApplicationDbContext(DbContextOptions<MyExpensesContext> options)
            : base(options)
        {
        }
    }
}
