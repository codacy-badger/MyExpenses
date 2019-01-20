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
    public class LabelService : ServiceBase<LabelDto, LabelModel>, ILabelService
    {
        private readonly ILabelRepository _repository;
        private readonly IMapper _mapper;

        public LabelService(ILabelRepository repository, IUnitOfWork unitOfWork, IMapper mapper) :
            base(repository, unitOfWork, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual Task<IEnumerable<LabelDto>> Get(Guid groupdId, int month, int year)
        {
            return Task.Run<IEnumerable<LabelDto>>(() =>
            {
                var models = _repository
                    .GetAll(
                        x => x.Group, 
                        x => x.Expenses.Where(y => 
                            y.Date.Month.Equals(month) &&
                            y.Date.Year.Equals(year)))
                    .Where(x =>
                        x.Group.Id.Equals(groupdId))
                    .ToList();

                return _mapper.Map<IEnumerable<LabelModel>, IEnumerable<LabelDto>>(models);
            });
        }
    }
}
