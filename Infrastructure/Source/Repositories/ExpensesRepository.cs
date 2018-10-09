/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Repositories
{
    using MyExpenses.Infrastructure.Tables;

    public class ExpensesRepository : RepositoryBase<LabelTable>
    {
        protected ExpensesRepository(MyExpensesContext context)
            : base(context)
        {
        }
    }
}
