/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/
namespace MyExpenses.Domain.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MyExpenses.Domain.Domains;
    using MyExpenses.Domain.IoC.Repositories;
    using MyExpenses.Domain.IoC.Services;

    public class PaymentService : ServiceBase<PaymentDomain>, IPaymentService
    {
        private readonly IPaymentRepository _repository;
        private readonly IExpenseRepository _expenseRepository;

        public PaymentService(IPaymentRepository repository, IExpenseRepository expenseRepository)
            : base(repository)
        {
            _repository = repository;
            _expenseRepository = expenseRepository;
        }

        public IEnumerable<PaymentDomain> GetAllWithIncludes(Guid groupId)
        {
            return _repository
                .GetAll(x => x.Group.Users)
                .Where(x => x.Group.Id == groupId);
        }

        public override Task<bool> RemoveAsync(Guid id)
        {
            ICollection<Task<ExpenseDomain>> expensesToUpdateTask = new List<Task<ExpenseDomain>>();

            // remove all references from each expense what have this label
            var expenses = _expenseRepository.GetAll(x => x.Payment).Where(x => x.Payment.Id == id);
            foreach (ExpenseDomain expense in expenses)
            {
                expense.Label = null;
                expensesToUpdateTask.Add(_expenseRepository.UpdateAsync(expense));
            }

            Task.WaitAll(expensesToUpdateTask.ToArray());

            return _repository.RemoveAsync(id);
        }
    }
}
