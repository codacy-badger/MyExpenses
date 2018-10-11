/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class GroupDto : DtoBase
    {
        public GroupDto()
        {
            Users = new List<GroupUserDto>();
        }

        [Required]
        public string Name { get; set; }

        public ICollection<GroupUserDto> Users { get; set; }
    }
}
