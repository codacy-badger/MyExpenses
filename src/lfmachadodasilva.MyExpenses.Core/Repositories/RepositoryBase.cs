using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using lfmachadodasilva.MyExpenses.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace lfmachadodasilva.MyExpenses.Core.Repositories
{
    internal class RepositoryBase<TModel> : IRepository<TModel> where TModel : class, IModel
    {
        private readonly MyExpensesContext _context;
        private readonly IMapper _mapper;

        public RepositoryBase(MyExpensesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public virtual IEnumerable<TModel> GetAll(params Expression<Func<TModel, object>>[] includes)
        {
            IQueryable<TModel> models = _context.Set<TModel>();

            foreach (var include in includes)
                models = models.Include(include);

            return models;
        }

        public virtual Task<TModel> GetByIdAsync(Guid id, params Expression<Func<TModel, object>>[] includes)
        {
            IQueryable<TModel> models = _context.Set<TModel>();

            foreach (var include in includes)
                models = models.Include(include);

            return models.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TModel> UpdateAsync(TModel model)
        {
            if (model == null)
                return null;

            TModel existModel = await GetByIdAsync(model.Id);
            if (existModel == null)
                return null;

            // copy attributes
            _mapper.Map(model, existModel);
            return existModel;
        }
    }
}
