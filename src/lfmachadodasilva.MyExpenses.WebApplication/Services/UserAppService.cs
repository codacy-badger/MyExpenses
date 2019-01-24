using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lfmachadodasilva.MyExpenses.WebApplication.Models;
using Microsoft.AspNetCore.Identity;

namespace lfmachadodasilva.MyExpenses.WebApplication.Services
{
    public interface IUserAppService
    {
        IEnumerable<UserViewModel> GetAll();

        IEnumerable<UserViewModel> GetAll(IEnumerable<Guid> usersId);
    }

    public class UserAppService : IUserAppService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserAppService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IEnumerable<UserViewModel> GetAll(IEnumerable<Guid> usersId)
        {
            return from user in _userManager.Users
                   join id in usersId on user.Id equals usersId.ToString()
                   select new UserViewModel { Id = id, Name = user.UserName };
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            return _userManager.Users
                .Select(x => new UserViewModel { Id = Guid.Parse(x.Id), Name = x.UserName });
        }
    }
}
