/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Domains
{
    using System;
    using MyExpenses.Domain.Interfaces;

    public abstract class DomainBase : IBaseId
    {
        public Guid Id { get; set; }

        public abstract void Copy(IBaseId obj);
    }
}
