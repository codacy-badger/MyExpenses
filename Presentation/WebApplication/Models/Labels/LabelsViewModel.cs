/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace WebApplication.Models.Labels
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc.Rendering;

    using WebApplication.Models.Groups;

    public class LabelsViewModel
    {
        public LabelsViewModel()
        {
            Labels = new List<LabelViewModel>();  
        }

        public GroupViewModel Group { get; set; }

        public SelectList AvailableGroupsSelectList { get; set; }

        /// <summary>
        /// Only used to label
        /// </summary>
        public LabelViewModel LabelLabel { get; set; }

        public ICollection<LabelViewModel> Labels { get; set; }

        public void SetupAvailableGroups(ICollection<GroupViewModel> groups)
        {
            AvailableGroupsSelectList = new SelectList(groups, "Id", "Name");
        }
    }
}
