using AutoMapper;
using lfmachadodasilva.MyExpenses.Core.Models;

namespace lfmachadodasilva.MyExpenses.Core.Repositories
{
    internal class GroupRepository : RepositoryBase<GroupModel>, IGroupRepository
    {
        public GroupRepository(MyExpensesContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
