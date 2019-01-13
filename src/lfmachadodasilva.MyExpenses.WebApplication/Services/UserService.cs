using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lfmachadodasilva.MyExpenses.WebApplication.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace lfmachadodasilva.MyExpenses.WebApplication.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public UserService(
            UserManager<IdentityUser> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<Guid> GetUserIdAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return new Guid(user.Id);
        }

        public Task<IEnumerable<UserViewModel>> GetAllUsersAsync()
        {
            return Task.Run(() => _userManager.Users
                .Select(x => new UserViewModel { Id = new Guid(x.Id), Name = x.UserName })
                .AsEnumerable());
        }
    }
}
