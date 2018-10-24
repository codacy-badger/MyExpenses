/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Dtos
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class LabelDto : DtoBase
    {
        [Required]
        public string Name { get; set; }

        public Guid GroupId { get; set; }

        public GroupDto Group { get; set; }
    }
}
