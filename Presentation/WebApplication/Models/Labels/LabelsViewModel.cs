/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace WebApplication.Models.Labels
{
    using System.Collections.Generic;

    using WebApplication.Models.Groups;

    public class LabelsViewModel
    {
        public LabelsViewModel()
        {
            AvailableGroups = new List<GroupViewModel>();
            Labels = new List<LabelViewModel>();  
        }

        public GroupViewModel Group { get; set; }

        public ICollection<GroupViewModel> AvailableGroups { get; set; }

        /// <summary>
        /// Only used to label
        /// </summary>
        public LabelViewModel LabelLabel { get; set; }

        public ICollection<LabelViewModel> Labels { get; set; }
    }
}
