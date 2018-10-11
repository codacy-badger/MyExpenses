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

        public async Task<GroupDomain> Update(GroupDomain obj, ICollection<Guid> newUsers)
        {
            // clear just to make sure
            obj.Users.Clear();

            // get old user from this group
            var oldGroup = await _repository.GetByIdAsync(obj.Id, x => x.Users);
            var oldUsers = oldGroup.Users;

            var removeTask = Task.Run(() => RemoveGroupUserTask(newUsers, oldUsers, obj, _groupUserRepository));
            var addTask = Task.Run(() => AddGroupUserTask(newUsers, oldUsers, _groupUserRepository));

            var users = obj.Users as List<GroupUserDomain>;
            users.AddRange(await removeTask);
            users.AddRange(await addTask);

            return await _repository.UpdateAsync(obj);
        }

        private async Task<ICollection<GroupUserDomain>> RemoveGroupUserTask(
            ICollection<Guid> newUsers,
            ICollection<GroupUserDomain> oldUsers,
            GroupDomain obj,
            IGroupUserRepository groupUserRepository)
        {
            var ret = new List<GroupUserDomain>();

            foreach (var user in newUsers)
            {
                if (!oldUsers.Any(y => user == y.UserId))
                {
                    var groupUser = new GroupUserDomain
                    {
                        Id = Guid.NewGuid(),
                        UserId = user,
                        Group = obj
                    };

                    var newGroupUser = await _groupUserRepository.AddAsync(groupUser);
                    ret.Add(newGroupUser);
                }
            }

            return ret;
        }

        private async Task<ICollection<GroupUserDomain>> AddGroupUserTask(
            ICollection<Guid> newUsers,
            ICollection<GroupUserDomain> oldUsers,
            IGroupUserRepository groupUserRepository)
        {
            var ret = new List<GroupUserDomain>();
            var tasks = new List<Task<bool>>();

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
