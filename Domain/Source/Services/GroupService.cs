/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using MyExpenses.Domain.Domains;
    using MyExpenses.Domain.IoT.Repositories;
    using MyExpenses.Domain.IoT.Services;

    public class GroupService : ServiceBase<GroupDomain>, IGroupService
    {
        private readonly IGroupRepository _repository;

        public GroupService(IGroupRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public IQueryable<GroupDomain> GetAllWithIncludes(Guid userId)
        {
            return _repository.GetAll(x => x.Users).Where(x => x.Users.Any(y => y.UserId == userId));
        }

        public Task<GroupDomain> GetByIdWithIncludeAsync(Guid groupId)
        {
            return _repository.GetByIdAsync(groupId, x => x.Users);
        }
    }
}
