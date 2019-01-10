using AutoMapper;
using lfmachadodasilva.MyExpenses.Core.Models;
using lfmachadodasilva.MyExpenses.Core.Models.Dtos;
using lfmachadodasilva.MyExpenses.Core.Repositories;

namespace lfmachadodasilva.MyExpenses.Core.Services
{
    internal class ExpenseService : ServiceBase<ExpenseDto, ExpenseModel>, IExpenseService
    {
        internal ExpenseService(IExpenseRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
