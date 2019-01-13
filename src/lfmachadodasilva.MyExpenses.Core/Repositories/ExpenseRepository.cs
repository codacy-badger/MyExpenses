using AutoMapper;
using lfmachadodasilva.MyExpenses.Core.Models;

namespace lfmachadodasilva.MyExpenses.Core.Repositories
{
    internal class ExpenseRepository : RepositoryBase<ExpenseModel>, IExpenseRepository
    {
        public ExpenseRepository(MyExpensesContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
