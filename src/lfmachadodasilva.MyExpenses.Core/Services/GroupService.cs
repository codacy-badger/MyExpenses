using AutoMapper;
using lfmachadodasilva.MyExpenses.Core.Models;
using lfmachadodasilva.MyExpenses.Core.Models.Dtos;
using lfmachadodasilva.MyExpenses.Core.Repositories;

namespace lfmachadodasilva.MyExpenses.Core.Services
{
    internal class GroupService : ServiceBase<GroupDto, GroupModel>, IGroupService
    {
        public GroupService(IGroupRepository repository, IUnitOfWork unitOfWork, IMapper mapper) :
            base(repository, unitOfWork, mapper)
        {
        }
    }
}
