/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Dtos
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class DtoBase : IDto
    {
        [Key]
        public Guid Id { get; set; }
    }
}
