/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace WebApplication.Models.Groups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class GroupCreateEditViewModel
    {
        public GroupCreateEditViewModel()
        {
            AvailableUsers = new List<UserViewModel>();
            SelectedUsers = new List<GroupUserViewModel>();
            SelectedUsersId = new List<Guid>();
        }

        public GroupCreateEditViewModel(IQueryable<IdentityUser> availables, ICollection<GroupUserViewModel> selected = null)
        {
            SetupUsers(availables, selected);
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<UserViewModel> AvailableUsers { get; private set; }

        public SelectList AvailableUsersSelectList { get; set; }

        public ICollection<GroupUserViewModel> SelectedUsers { get; private set; }

        public ICollection<Guid> SelectedUsersId { get; set; }

        private void SetupUsers(IQueryable<IdentityUser> availables, ICollection<GroupUserViewModel> selected = null)
        {
            AvailableUsers = availables.Select(u => new UserViewModel { Id = Guid.Parse(u.Id), UserName = u.UserName }).ToList();
            AvailableUsersSelectList = new SelectList(AvailableUsers, "Id", "UserName");

            if (selected != null && selected.Any())
            {
                SelectedUsers = selected;
                SelectedUsersId = selected.Select(x => x.UserId).ToList();
            }
        }
    }
}
