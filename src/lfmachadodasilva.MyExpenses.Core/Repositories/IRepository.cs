using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using lfmachadodasilva.MyExpenses.Core.Models;

namespace lfmachadodasilva.MyExpenses.Core.Repositories
{
    internal interface IRepository<TModel> where TModel : IModel
    {
        IEnumerable<TModel> Get();

        Task<TModel> GetById(Guid id);
    }
}
