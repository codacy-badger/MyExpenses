using AutoMapper;
using lfmachadodasilva.MyExpenses.Core.Models;

namespace lfmachadodasilva.MyExpenses.Core.Repositories
{
    public class GroupRepository : RepositoryBase<GroupModel>, IGroupRepository
    {
        public GroupRepository(MyExpensesContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
