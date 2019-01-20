using System;
using System.Collections.Generic;

namespace lfmachadodasilva.MyExpenses.WebApplication.Models.ViewModels
{
    public class GroupsViewModel : ViewModelBase<GroupViewModel>
    {
        public override GroupViewModel Empty { get; } = new GroupViewModel();
    }

    public class GroupViewModel : ViewModelBase
    {
        public string Name { get; set; }

        public IEnumerable<UserViewModel> Users { get; set; }

        public IEnumerable<UserViewModel> AllUsers { get; set; }

        public IEnumerable<UserViewModel> SelectedUsers { get; set; }
    }
}
