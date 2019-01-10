using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public virtual IEnumerable<TModel> GetAll(params Expression<Func<TModel, object>>[] includes)
        {
            IQueryable<TModel> models = _context.Set<TModel>();

            foreach (var include in includes)
                models = models.Include(include);

            return models;
        }

        public virtual Task<TModel> GetById(Guid id, params Expression<Func<TModel, object>>[] includes)
        {
            IQueryable<TModel> models = _context.Set<TModel>();

            foreach (var include in includes)
                models = models.Include(include);

            return models.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
