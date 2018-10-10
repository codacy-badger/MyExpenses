/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Repositories
{
    using MyExpenses.Domain.Domains;
    using MyExpenses.Domain.IoT.Repositories;

    public class ExpensesRepository : RepositoryBase<ExpenseDomain>, IExpenseRepository
    {
        public ExpensesRepository(MyExpensesContext context)
            : base(context)
        {
        }
    }
}
