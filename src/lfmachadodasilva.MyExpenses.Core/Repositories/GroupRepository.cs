using lfmachadodasilva.MyExpenses.Core.Models;

namespace lfmachadodasilva.MyExpenses.Core.Repositories
{
    internal class GroupRepository : RepositoryBase<GroupModel>
    {
        public GroupRepository(MyExpensesContext context) : base(context)
        {
        }
    }
}
