/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Dtos
{
    using System;

    public abstract class DtoBase : IDto
    {
        public Guid Id { get; set; }
    }
}
