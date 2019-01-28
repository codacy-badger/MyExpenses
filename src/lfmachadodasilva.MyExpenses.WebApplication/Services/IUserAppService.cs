using System;
using System.Collections.Generic;
using lfmachadodasilva.MyExpenses.WebApplication.Models;

namespace lfmachadodasilva.MyExpenses.WebApplication.Services
{
    public interface IUserAppService
    {
        IEnumerable<UserViewModel> GetAll();

        IEnumerable<UserViewModel> GetAll(IEnumerable<Guid> usersId);
    }
}