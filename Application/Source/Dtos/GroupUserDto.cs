/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Dtos
{
    using System;

    public class GroupUserDto : DtoBase
    {
        public GroupDto Group { get; set; }

        public Guid UserId { get; set; }
    }
}
