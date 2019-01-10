using lfmachadodasilva.MyExpenses.Core.Models;

namespace lfmachadodasilva.MyExpenses.Core.Repositories
{
    internal class ExpenseRepository : RepositoryBase<ExpenseModel>
    {
        public ExpenseRepository(MyExpensesContext context) : base(context)
        {
        }
    }
}
