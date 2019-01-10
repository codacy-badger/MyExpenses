using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lfmachadodasilva.MyExpenses.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace lfmachadodasilva.MyExpenses.Core.Repositories
{
    internal class RepositoryBase<TModel> : IRepository<TModel> where TModel : class, IModel
    {
        private readonly MyExpensesContext _context;

        public RepositoryBase(MyExpensesContext context)
        {
            _context = context;
        }

        public virtual IEnumerable<TModel> Get()
        {
            IQueryable<TModel> models = _context.Set<TModel>();
            return models;
        }

        public virtual Task<TModel> GetById(Guid id)
        {
            IQueryable<TModel> models = _context.Set<TModel>();
            return models.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
