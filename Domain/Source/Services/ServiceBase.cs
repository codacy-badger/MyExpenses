/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Services
{
    using MyExpenses.Domain.Interfaces;

    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class ServiceBase<T> : IService<T> where T : IBaseId
    {
        private readonly IService<T> _repository;

        protected ServiceBase(IService<T> repository)
        {
            _repository = repository;
        }

        #region non-async

        public virtual IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            return _repository.GetAll(includes);
        }

        public virtual T Add(T model)
        {
            return _repository.Add(model);
        }

        public virtual T Update(T model)
        {
            return _repository.Update(model);
        }

        public virtual T GetById(Guid id, params Expression<Func<T, object>>[] includes)
        {
            return _repository.GetById(id, includes);
        }

        public virtual bool Remove(Guid id)
        {
            return _repository.Remove(id);
        }

        #endregion

        #region async

        public Task<T> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes)
        {
            return _repository.GetByIdAsync(id, includes);
        }

        public Task<bool> RemoveAsync(Guid id)
        {
            return _repository.RemoveAsync(id);
        }

        public Task<T> AddAsync(T model)
        {
            return _repository.AddAsync(model);
        }

        public Task<T> UpdateAsync(T model)
        {
            return _repository.UpdateAsync(model);
        }

        #endregion
    }
}
