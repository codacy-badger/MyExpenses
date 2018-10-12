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

        public override async Task<bool>  RemoveAsync(Guid id)
        {
            var obj = await _repository.GetByIdAsync(id, x => x.Users);

            foreach (var user in obj.Users)
            {
                await _groupUserRepository.RemoveAsync(user.Id);
            }

            return await _repository.RemoveAsync(id);
        }

        public async Task<GroupDomain> Update(GroupDomain obj, ICollection<Guid> newUsersId)
        {
            // clear just to make sure
            obj.Users.Clear();

            // get old user from this group
            var oldGroup = await _repository.GetByIdAsync(obj.Id, x => x.Users);
            var oldUsers = oldGroup.Users;

            if (obj.Users is List<GroupUserDomain> users)
            {
                var removeTask = Task.Run(() => RemoveGroupUserTask(newUsersId, oldUsers, obj));
                var addTask = Task.Run(() => AddGroupUserTask(newUsersId, oldUsers));

                users.AddRange(await removeTask);
                users.AddRange(await addTask);
            }

            return await _repository.UpdateAsync(obj);
        }

        private async Task<ICollection<GroupUserDomain>> RemoveGroupUserTask(
            ICollection<Guid> newUsers,
            ICollection<GroupUserDomain> oldUsers,
            GroupDomain obj)
        {
            var ret = new List<GroupUserDomain>();

            foreach (var user in newUsers)
            {
                if (!oldUsers.Any(y => user == y.UserId))
                {
                    // create new user for this group
                    var groupUser = new GroupUserDomain { UserId = user, Group = obj };

                    // add
                    var newGroupUser = await _groupUserRepository.AddAsync(groupUser);
                    ret.Add(newGroupUser);
                }
            }

            return ret;
        }

        private async Task<ICollection<GroupUserDomain>> AddGroupUserTask(
            ICollection<Guid> newUsers,
            ICollection<GroupUserDomain> oldUsers)
        {
            var ret = new List<GroupUserDomain>();

            // for each old user, check if need to remove or maintain
            foreach (var user in oldUsers)
            {
                if (newUsers.Any(x => x == user.UserId))
                {
                    // already in
                    ret.Add(user);
                }
                else
                {
                    // this user do not belong to this group any more
                    await _groupUserRepository.RemoveAsync(user.Id);
                }
            }

            return ret;
        }
    }
}
