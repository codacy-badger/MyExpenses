/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace WebApplication.Models.Groups
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class GroupUserViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public GroupViewModel Group { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public string Name { get; set; }
    }
}
