/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Services
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using MyExpenses.Domain.IoC;
    using MyExpenses.Domain.IoC.Repositories;

    public class ServiceBase<TDomain> : IService<TDomain> where TDomain : IBase
    {
        private readonly IRepository<TDomain> _repository;

        protected ServiceBase(IRepository<TDomain> repository)
        {
            _repository = repository;
        }

        /// <inheritdoc />
        public virtual IQueryable<TDomain> GetAll(params Expression<Func<TDomain, object>>[] includes)
        {
            return _repository.GetAll(includes);
        }

        #region non-async

        /// <inheritdoc />
        public virtual TDomain Add(TDomain obj)
        {
            return _repository.Add(obj);
        }

        /// <inheritdoc />
        public virtual TDomain Update(TDomain obj)
        {
            return _repository.Update(obj);
        }

        /// <inheritdoc />
        public virtual TDomain GetById(Guid id, params Expression<Func<TDomain, object>>[] includes)
        {
            return _repository.GetById(id, includes);
        }

        /// <inheritdoc />
        public virtual bool Remove(Guid id)
        {
            return _repository.Remove(id);
        }

        #endregion

        #region async

        /// <inheritdoc />
        public virtual Task<TDomain> GetByIdAsync(Guid id, params Expression<Func<TDomain, object>>[] includes)
        {
            return _repository.GetByIdAsync(id, includes);
        }

        /// <inheritdoc />
        public virtual Task<bool> RemoveAsync(Guid id)
        {
            return _repository.RemoveAsync(id);
        }

        /// <inheritdoc />
        public virtual Task<TDomain> AddAsync(TDomain obj)
        {
            return _repository.AddAsync(obj);
        }

        /// <inheritdoc />
        public virtual Task<TDomain> UpdateAsync(TDomain obj)
        {
            return _repository.UpdateAsync(obj);
        }

        #endregion
    }
}
