using System;
using System.Collections.Generic;
using System.Linq;
using lfmachadodasilva.MyExpenses.WebApplication.Models;
using Microsoft.AspNetCore.Identity;

namespace lfmachadodasilva.MyExpenses.WebApplication.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserAppService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IEnumerable<UserViewModel> GetAll(IEnumerable<Guid> usersId)
        {
            return _userManager.Users.Join(usersId,
                a => a.Id,
                b => b.ToString(),
                (a, b) => new UserViewModel { Id = b, Name = a.UserName });
            //return from a in _userManager.Users
            //       join b in usersId on a.Id equals b
            //       select new UserViewModel { Id = b, Name = a.UserName };
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            return _userManager.Users
                .Select(x => new UserViewModel { Id = Guid.Parse(x.Id), Name = x.UserName });
        }
    }
}
