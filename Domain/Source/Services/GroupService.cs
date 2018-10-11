/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MyExpenses.Domain.Domains;
    using MyExpenses.Domain.IoT.Repositories;
    using MyExpenses.Domain.IoT.Services;

    public class GroupService : ServiceBase<GroupDomain>, IGroupService
    {
        private readonly IGroupRepository _repository;
        private readonly IGroupUserRepository _groupUserRepository;

        public GroupService(IGroupRepository repository, IGroupUserRepository groupUserRepository)
            : base(repository)
        {
            _repository = repository;
            _groupUserRepository = groupUserRepository;
        }

        public IQueryable<GroupDomain> GetAllWithIncludes(Guid userId)
        {
            return _repository.GetAll(x => x.Users).Where(x => x.Users.Any(y => y.UserId == userId));
        }

        public Task<GroupDomain> GetByIdWithIncludeAsync(Guid groupId)
        {
            return _repository.GetByIdAsync(groupId, x => x.Users);
        }

        public void Update(GroupDomain obj, ICollection<Guid> newUsers)
        {
            // clear just to make sure
            obj.Users.Clear();

            // get old user from this group
            var oldUsers = _repository.GetById(obj.Id, x => x.Users).Users;

            // for each new user that do not exist in the old, add
            foreach (var user in newUsers)
            {
                if (!oldUsers.Any(y => user == y.UserId))
                {
                    var newGroupUser = new GroupUserDomain { Id = Guid.NewGuid(), UserId = user, Group = obj };
                    obj.Users.Add(_groupUserRepository.Add(newGroupUser));
                }
            }

            // for each old user, check if need to remove or maintain
            foreach (var user in oldUsers)
            {
                if (newUsers.Any(x => x == user.UserId))
                {
                    // already in
                    obj.Users.Add(user);
                }
                else
                {
                    // this user do not belong to this group any more
                    _groupUserRepository.Remove(user.Id);
                }
            }

            _repository.Update(obj);
        }
    }
}
