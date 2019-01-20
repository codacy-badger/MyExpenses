using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lfmachadodasilva.MyExpenses.Core.Models;
using lfmachadodasilva.MyExpenses.WebApplication.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace lfmachadodasilva.MyExpenses.WebApplication.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly IMapper _mapper;

        public UserService(
            UserManager<UserModel> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<Guid> GetUserIdAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user.IdGuid;
        }

        public Task<IEnumerable<UserViewModel>> GetAllUsersAsync()
        {
            return Task.Run(() => _userManager.Users
                .Select(x => new UserViewModel { Id = x.IdGuid, Name = x.UserName })
                .AsEnumerable());
        }
    }
}
