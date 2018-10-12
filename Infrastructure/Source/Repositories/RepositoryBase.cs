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

    public class RepositoryBase<TDomain> : IRepository<TDomain> where TDomain : class, IBase
    {
        private readonly MyExpensesContext _context;

        protected RepositoryBase(MyExpensesContext context)
        {
            _context = context;
        }

        public virtual IQueryable<TDomain> GetAll(params Expression<Func<TDomain, object>>[] includes)
        {
            IQueryable<TDomain> set = _context.Set<TDomain>();

            foreach (var include in includes)
                set = set.Include(include);

            return set;
        }

        public virtual TDomain GetById(Guid id, params Expression<Func<TDomain, object>>[] includes)
        {
            IQueryable<TDomain> set = _context.Set<TDomain>();

            foreach (var include in includes)
                set = set.Include(include);

            return set.SingleOrDefault(x => x.Id == id);
        }

        public async Task<TDomain> GetByIdAsync(Guid id, params Expression<Func<TDomain, object>>[] includes)
        {
            IQueryable<TDomain> set = _context.Set<TDomain>();

            foreach (var include in includes)
                set = set.Include(include);

            return await set.FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool Remove(Guid id)
        {
            TDomain model = _context.Set<TDomain>().Find(id);
            if (model == null)
                return false;

            return _context.Set<TDomain>().Remove(model) != null;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            TDomain model = await GetByIdAsync(id);
            if (model == null)
                return false;

            return _context.Set<TDomain>().Remove(model) != null;
        }

        public TDomain Update(TDomain obj)
        {
            if (obj == null)
                return null;

            TDomain result = _context.Set<TDomain>().Find(obj.Id);
            if (result == null)
                return null;

            UpdateLastUpdate(obj);

            // copy attributes
            result.Copy(obj);
            return result;
        }

        public async Task<TDomain> UpdateAsync(TDomain obj)
        {
            if (obj == null)
                return null;

            TDomain result = await GetByIdAsync(obj.Id);
            if (result == null)
                return null;

            UpdateLastUpdate(obj);

            // copy attributes
            result.Copy(obj);
            return result;
        }

        public TDomain Add(TDomain obj)
        {
            if (obj == null)
                return null;

            obj.Id = Guid.NewGuid();
            UpdateLastUpdate(obj);

            var newModel = _context.Set<TDomain>().Add(obj);
            return newModel?.Entity;
        }

        public async Task<TDomain> AddAsync(TDomain obj)
        {
            if (obj == null)
                return null;

            obj.Id = Guid.NewGuid();
            UpdateLastUpdate(obj);

            var newModel = await _context.Set<TDomain>().AddAsync(obj);
            return newModel?.Entity;
        }

        private static void UpdateLastUpdate(TDomain obj)
        {
            obj.LastUpdate = DateTime.Now;
        }
    }
}
