﻿/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.AppServices.Interfaces
{
    using MyExpenses.Application.Dtos;

    public interface IExpenseAppService : IAppService<ExpenseDto>
    {
    }
}
