using System;
using System.Collections.Generic;
using System.Linq;

namespace lfmachadodasilva.MyExpenses.WebApplication.Models
{
    public class GroupViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<UserViewModel> Users { get; set; } = new List<UserViewModel>();

        public string UsersNames => Users.Any() ? string.Join(", ", Users.Select(x => x.Name).ToList()) : string.Empty;
    }

    public class GroupsViewModel
    {
        public GroupViewModel Empty => new GroupViewModel();

        public IEnumerable<GroupViewModel> Items { get; set; }
    }
}