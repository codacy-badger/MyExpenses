using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lfmachadodasilva.MyExpenses.Core.Models;
using lfmachadodasilva.MyExpenses.Core.Models.Dtos;
using lfmachadodasilva.MyExpenses.Core.Repositories;

namespace lfmachadodasilva.MyExpenses.Core.Services
{
    public class ExpenseService : ServiceBase<ExpenseDto, ExpenseModel>, IExpenseService
    {
        private readonly IExpenseRepository _repository;
        private readonly IMapper _mapper;

        public ExpenseService(IExpenseRepository repository, IUnitOfWork unitOfWork, IMapper mapper) :
            base(repository, unitOfWork, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual Task<IEnumerable<ExpenseDto>> Get(Guid groupdId, int month, int year)
        {
            return Task.Run<IEnumerable<ExpenseDto>>(() =>
            {
                var models = _repository
                    .GetAll(x => x.Group)
                    .Where(x =>
                        x.Group.Id.Equals(groupdId) &&
                        x.Date.Day.Equals(month) &&
                        x.Date.Year.Equals(year))
                    .ToList();

                return _mapper.Map<IEnumerable<ExpenseModel>, IEnumerable<ExpenseDto>>(models);
            });
        }
    }
}
