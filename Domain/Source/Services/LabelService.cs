/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/
namespace MyExpenses.Domain.Services
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MyExpenses.Domain.Domains;
    using MyExpenses.Domain.IoC.Repositories;
    using MyExpenses.Domain.IoC.Services;

    public class LabelService : ServiceBase<LabelDomain>, ILabelService
    {
        private readonly ILabelRepository _repository;
        private readonly IExpenseRepository _expenseRepository;

        public LabelService(ILabelRepository repository, IExpenseRepository expenseRepository)
            : base(repository)
        {
            _repository = repository;
            _expenseRepository = expenseRepository;
        }

        public IEnumerable<LabelDomain> GetAllWithIncludes(Guid groupId)
        {
            return _repository
                .GetAll(x => x.Group.Users)
                .Where(x => x.Group.Id == groupId);
        }

        public Task<LabelDomain> GetByIdWithIncludes(Guid id)
        {
            return _repository
                .GetByIdAsync(id, x => x.Group.Users);
        }

        public override Task<bool> RemoveAsync(Guid id)
        {
            ICollection<Task<ExpenseDomain>> expensesToUpdateTask = new List<Task<ExpenseDomain>>();

            // remove all references from each expense what have this label
            var expenses = _expenseRepository.GetAll(x => x.Label).Where(x => x.Label.Id == id);
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
