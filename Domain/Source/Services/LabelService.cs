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

    using MyExpenses.Domain.Domains;
    using MyExpenses.Domain.IoC.Repositories;
    using MyExpenses.Domain.IoC.Services;

    public class LabelService : ServiceBase<LabelDomain>, ILabelService
    {
        private readonly ILabelRepository _repository;

        public LabelService(ILabelRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<LabelDomain> GetAllWithIncludes(Guid userId)
        {
            return _repository
                .GetAll(x => x.Group.Users)
                .Where(x => x.Group.Users.Any(y => y.UserId == userId));
        }
    }
}
