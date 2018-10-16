/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace WebApplication.Models.Labels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc.Rendering;

    using WebApplication.Models.Groups;

    public class LabelCreateEditViewModel : ViewModelBase
    {
        public LabelCreateEditViewModel()
        {
            
        }

        public LabelCreateEditViewModel(ICollection<GroupViewModel> availableGroups)
        {
            SetupGroups(availableGroups);
        }

        [Required]
        public string Name { get; set; }

        public GroupViewModel Group { get; set; }

        public SelectList AvailableGroupsSelectList { get; set; }

        public Guid SelectedGroupId { get; set; }

        public void SetupGroups(ICollection<GroupViewModel> availableGroups)
        {
            AvailableGroupsSelectList = new SelectList(availableGroups, "Id", "Name");
            SelectedGroupId = availableGroups.Select(x => x.Id).FirstOrDefault();
        }
    }
}
