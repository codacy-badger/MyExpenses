/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Repositories
{
    using MyExpenses.Domain.Domains;
    using MyExpenses.Domain.IoT.Repositories;

    public class GroupRepository : RepositoryBase<GroupDomain>, IGroupRepository
    {
        protected GroupRepository(MyExpensesContext context)
            : base(context)
        {
        }
    }
}
