/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Repositories
{
    using MyExpenses.Domain.Domains;
    using MyExpenses.Domain.IoC.Repositories;

    public class GroupUserRepository : RepositoryBase<GroupUserDomain>, IGroupUserRepository
    {
        public GroupUserRepository(MyExpensesContext context)
            : base(context)
        {
        }
    }
}
