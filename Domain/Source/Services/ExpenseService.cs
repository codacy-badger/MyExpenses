/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Services
{
    using MyExpenses.Domain.Domains;
    using MyExpenses.Domain.IoC.Repositories;
    using MyExpenses.Domain.IoC.Services;

    public class ExpenseService : ServiceBase<ExpenseDomain>, IExpenseService
    {
        public ExpenseService(IExpenseRepository repository)
            : base(repository)
        {
        }
    }
}
