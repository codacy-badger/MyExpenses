/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Tables
{
    using System;

    public interface ITable
    {
        Guid Id { get; set; }

        string Name { get; set; }

        DateTime LastUpdate { get; set; }

        void Copy(ITable baseObj);
    }
}
