﻿/* 
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

    public class GroupViewModel
    {
        public GroupViewModel()
        {
            AvailableUsers = new List<UserViewModel>();
            SelectedUsers = new List<UserViewModel>();
            SelectedUsersId = new List<Guid>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<UserViewModel> AvailableUsers { get; private set; }

        public SelectList AvailableUsersSelectList { get; private set; }

        public ICollection<UserViewModel> SelectedUsers { get; private set; }

        public ICollection<Guid> SelectedUsersId { get; set; }

        public void SetupUsers(IQueryable<IdentityUser> availables, ICollection<Guid> selected = null)
        {
            AvailableUsers = availables.Select(u => new UserViewModel { Id = Guid.Parse(u.Id), UserName = u.UserName }).ToList();
            AvailableUsersSelectList = new SelectList(AvailableUsers, "UserId", "UserName");

            if (selected != null && selected.Any())
            {
                SelectedUsers = AvailableUsers.Where(x => selected.Any(y => y == x.Id)).ToList();
                SelectedUsersId = selected;
            }
        }
    }
}
