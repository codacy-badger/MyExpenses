/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace WebApplication.Models.Groups
{
    using System.Collections.Generic;

    public class GroupsViewModel
    {
        public GroupsViewModel()
        {
            Groups = new List<GroupViewModel>();
        }

        public UserViewModel CurrentUser { get; set; }

        public GroupViewModel GroupLabel { get; set; }

        public ICollection<GroupViewModel> Groups { get; set; }
    }
}
