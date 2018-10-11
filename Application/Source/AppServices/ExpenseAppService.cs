/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.AppServices
{
    using System.Linq;

    using MyExpenses.Application.AppServices.Interfaces;
    using MyExpenses.Application.Dtos;
    using MyExpenses.Domain.Domains;
    using MyExpenses.Domain.IoT;
    using MyExpenses.Domain.IoT.Services;

    public class ExpenseAppService : AppServiceBase<ExpenseDomain, ExpenseDto>, IExpenseAppService
    {
        private readonly IExpenseService _service;

        public ExpenseAppService(IExpenseService service, IUnitOfWork unitOfwork)
            : base(service, unitOfwork)
        {
            _service = service;
        }
    }
}
