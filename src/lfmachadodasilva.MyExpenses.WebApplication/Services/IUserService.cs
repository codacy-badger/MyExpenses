using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using lfmachadodasilva.MyExpenses.WebApplication.Models.ViewModels;

namespace lfmachadodasilva.MyExpenses.WebApplication.Services
{
    public interface IUserService
    {
        Task<Guid> GetUserIdAsync(string userName);

        Task<IEnumerable<UserViewModel>> GetAllUsersAsync();
    }
}
