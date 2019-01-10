using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using lfmachadodasilva.MyExpenses.Core.Models;

namespace lfmachadodasilva.MyExpenses.Core.Repositories
{
    internal interface IRepository<TModel> where TModel : IModel
    {
        IEnumerable<TModel> GetAll(params Expression<Func<TModel, object>>[] includes);

        Task<TModel> GetById(Guid id, params Expression<Func<TModel, object>>[] includes);
    }
}
