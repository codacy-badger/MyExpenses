﻿/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.IoC
{
    using System;

    public interface IBase
    {
        /// <summary>
        /// Identification key
        /// </summary>
        Guid Id { get; set; }

        DateTime LastUpdate { get; set; }

        void Copy(IBase baseObj);
    }
}