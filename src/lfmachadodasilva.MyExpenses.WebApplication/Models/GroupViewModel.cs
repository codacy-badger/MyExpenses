using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lfmachadodasilva.MyExpenses.WebApplication.Models
{
    public class GroupViewModel : ViewModelBase
    {
        public string Name { get; set; }

        public IEnumerable<UserViewModel> Users { get; set; } = new List<UserViewModel>();

        public string UsersNames => Users.Any() ? string.Join(", ", Users.Select(x => x.Name).ToList()) : string.Empty;

        public SelectList AllUsersNames { get; set; }
        public IEnumerable<UserViewModel> AllUsers { get; set; }

        public IEnumerable<Guid> SelectedUsersId { get; set; }

        public GroupViewModel()
        {
        }

        public GroupViewModel(IEnumerable<UserViewModel> allUsers, IEnumerable<Guid> selectedUsersId)
        {
            AllUsers = allUsers
                //.Where(x => Guid.Parse(x.Id) != currentUserId) // remove current user from the list
                .Select(u => new UserViewModel { Id = u.Id, Name = u.Name })
                .ToList();
            AllUsersNames = new SelectList(AllUsers, "Id", "Name");
            SelectedUsersId = selectedUsersId;
        }
    }
}