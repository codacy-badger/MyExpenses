/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using MyExpenses.Domain.IoT;
    using MyExpenses.Domain.IoT.Repositories;

    public class RepositoryBase<TTable> : IRepository<TTable> where TTable : class, IBase
    {
        private readonly MyExpensesContext _context;

        protected RepositoryBase(MyExpensesContext context)
        {
            _context = context;
        }

        public virtual IQueryable<TTable> GetAll(params Expression<Func<TTable, object>>[] includes)
        {
            IQueryable<TTable> set = _context.Set<TTable>();

            foreach (var include in includes)
                set = set.Include(include);

            return set;
        }

        public virtual TTable GetById(Guid id, params Expression<Func<TTable, object>>[] includes)
        {
            IQueryable<TTable> set = _context.Set<TTable>();

            foreach (var include in includes)
                set = set.Include(include);

            return set.SingleOrDefault(x => x.Id == id);
        }

        public async Task<TTable> GetByIdAsync(Guid id, params Expression<Func<TTable, object>>[] includes)
        {
            IQueryable<TTable> set = _context.Set<TTable>();

            foreach (var include in includes)
                set = set.Include(include);

            return await set.FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool Remove(Guid id)
        {
            TTable model = _context.Set<TTable>().Find(id);
            if (model == null)
                return false;

            return _context.Set<TTable>().Remove(model) != null;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            TTable model = await GetByIdAsync(id);
            if (model == null)
                return false;

            return _context.Remove(model) != null;
        }

        public TTable Update(TTable model)
        {
            if (model == null)
                return null;

            TTable exisT = _context.Set<TTable>().Find(model.Id);
            if (exisT == null)
                return null;

            // copy attributes
            exisT.Copy(model);
            return exisT;
        }

        public async Task<TTable> UpdateAsync(TTable model)
        {
            if (model == null)
                return null;

            TTable existModel = await GetByIdAsync(model.Id);
            if (existModel == null)
                return null;

            // copy attributes
            existModel.Copy(model);
            return existModel;
        }

        public TTable Add(TTable model)
        {
            if (model == null)
                return null;

            model.Id = Guid.NewGuid();

            var newModel = _context.Set<TTable>().Add(model);
            return newModel?.Entity;
        }

        public async Task<TTable> AddAsync(TTable model)
        {
            if (model == null)
                return null;

            model.Id = Guid.NewGuid();

            var newModel = await _context.Set<TTable>().AddAsync(model);
            return newModel.Entity;
        }
    }
}
