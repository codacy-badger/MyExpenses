/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Repositories
{
    using MyExpenses.Infrastructure.Tables;

    public class PaymentRepository : RepositoryBase<LabelTable>
    {
        protected PaymentRepository(MyExpensesContext context)
            : base(context)
        {
        }
    }
}
