/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace WebApplication.Models.Labels
{
    using System.ComponentModel.DataAnnotations;

    using WebApplication.Models.Groups;

    public class LabelViewModel : ViewModelBase
    {
        [Required]
        public string Name { get; set; }

        public GroupViewModel Group { get; set; }
    }
}
