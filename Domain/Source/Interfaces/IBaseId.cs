/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Interfaces
{
    using System;

    public interface IBaseId
    {
        /// <summary>
        /// Identification key
        /// </summary>
        Guid Id { get; set; }

        void Copy(IBaseId obj);
    }
}
