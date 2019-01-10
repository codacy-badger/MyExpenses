using System;
using System.Collections.Generic;
using lfmachadodasilva.MyExpenses.Core.Models;

namespace lfmachadodasilva.MyExpenses.Core.Repositories
{
    internal interface IRepository<TModel> where TModel : IModel
    {
        IEnumerable<TModel> Get();

        TModel GetById(Guid Id);
    }
}
