using System;
using System.Collections.Generic;
using lfmachadodasilva.MyExpenses.Core.Models;

namespace lfmachadodasilva.MyExpenses.Core.Repositories
{
    internal class RepositoryBase<TModel> : IRepository<TModel> where TModel : IModel
    {
        public IEnumerable<TModel> Get()
        {
            throw new System.NotImplementedException();
        }

        public TModel GetById(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
