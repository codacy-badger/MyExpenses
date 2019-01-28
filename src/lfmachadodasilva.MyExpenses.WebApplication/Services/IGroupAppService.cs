using System;
using System.Threading.Tasks;
using lfmachadodasilva.MyExpenses.WebApplication.Models;

namespace lfmachadodasilva.MyExpenses.WebApplication.Services
{
    public interface IGroupAppService
    {
        Task<GroupsViewModel> GetAllAsync();

        Task<GroupViewModel> GetEmpty();

        Task<GroupViewModel> AddAsync(GroupViewModel groupViewModel);

        GroupViewModel GetByIdAsync(Guid groupId);

        GroupViewModel UpdateAsync(GroupViewModel groupViewModel);

        GroupViewModel RemoveAsync(Guid groupId);
    }
}