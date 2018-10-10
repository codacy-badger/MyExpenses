/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Dtos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class GroupDto : DtoBase
    {
        [Required]
        public string Name { get; set; }

        public ICollection<GroupUserDto> Users { get; set; }
    }
}
