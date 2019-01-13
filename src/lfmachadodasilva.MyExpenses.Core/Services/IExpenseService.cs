using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using lfmachadodasilva.MyExpenses.Core.Models.Dtos;

namespace lfmachadodasilva.MyExpenses.Core.Services
{
    public interface IExpenseService : IService<ExpenseDto>
    {
        Task<IEnumerable<ExpenseDto>> Get(Guid groupdId, int month, int year);
    }
}
