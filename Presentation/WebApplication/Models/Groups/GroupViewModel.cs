/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace WebApplication.Models.Groups
{
    using System.ComponentModel.DataAnnotations;

    public class GroupViewModel : ViewModelBase
    {
        [Required]
        public string Name { get; set; }
    }
}
