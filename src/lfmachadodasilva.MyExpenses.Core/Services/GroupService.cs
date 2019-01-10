using AutoMapper;
using lfmachadodasilva.MyExpenses.Core.Models;
using lfmachadodasilva.MyExpenses.Core.Models.Dtos;
using lfmachadodasilva.MyExpenses.Core.Repositories;

namespace lfmachadodasilva.MyExpenses.Core.Services
{
    internal class GroupService : ServiceBase<GroupDto, GroupModel>, IGroupService
    {
        internal GroupService(IGroupRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
