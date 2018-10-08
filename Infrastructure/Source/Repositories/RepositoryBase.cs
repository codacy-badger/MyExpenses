/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using MyExpenses.Domain.Interfaces;

    public class RepositoryBase<T> : IService<T> where T : class, IBaseId
    {
        private readonly MyExpensesContext _context;

        protected RepositoryBase(MyExpensesContext context)
        {
            _context = context;
        }

        public virtual IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> set = _context.Set<T>();

            foreach (var include in includes)
                set = set.Include(include);

            return set;
        }

        public virtual T GetById(Guid id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> set = _context.Set<T>();

            foreach (var include in includes)
                set = set.Include(include);

            return set.SingleOrDefault(x => x.Id == id);
        }

        public async Task<T> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> set = _context.Set<T>();

            foreach (var include in includes)
                set = set.Include(include);

            return await set.FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool Remove(long id)
        {
            T model = _context.Set<T>().Find(id);
            if (model == null)
                return false;

            return _context.Set<T>().Remove(model) != null;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            T model = await GetByIdAsync(id);
            if (model == null)
                return false;

            return _context.Remove(model) != null;
        }

        public T Update(T model)
        {
            if (model == null)
                return null;

            T exisT = _context.Set<T>().Find(model.Id);
            if (exisT == null)
                return null;

            // copy attributes
            exisT.Copy(model);
            return exisT;
        }

        public async Task<T> UpdateAsync(T model)
        {
            if (model == null)
                return null;

            T existModel = await GetByIdAsync(model.Id);
            if (existModel == null)
                return null;

            // copy attributes
            existModel.Copy(model);
            return existModel;
        }

        public T Add(T model)
        {
            if (model == null)
                return null;

            var newModel = _context.Set<T>().Add(model);
            return newModel?.Entity;
        }

        public async Task<T> AddAsync(T model)
        {
            if (model == null)
                return null;

            var newModel = await _context.Set<T>().AddAsync(model);
            return newModel.Entity;
        }
    }
}
