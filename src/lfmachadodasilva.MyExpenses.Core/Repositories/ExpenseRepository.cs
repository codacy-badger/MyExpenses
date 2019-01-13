using AutoMapper;
using lfmachadodasilva.MyExpenses.Core.Models;

namespace lfmachadodasilva.MyExpenses.Core.Repositories
{
    public class ExpenseRepository : RepositoryBase<ExpenseModel>, IExpenseRepository
    {
        public ExpenseRepository(MyExpensesContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
