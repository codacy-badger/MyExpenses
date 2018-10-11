/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Dtos
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class GroupUserDto : DtoBase
    {
        [Required]
        public GroupDto Group { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}
