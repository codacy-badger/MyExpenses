/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Repositories
{
    using MyExpenses.Domain.Domains;
    using MyExpenses.Domain.IoT.Repositories;

    public class LabelRepository : RepositoryBase<LabelDomain>, ILabelRepository
    {
        protected LabelRepository(MyExpensesContext context)
            : base(context)
        {
        }
    }
}
