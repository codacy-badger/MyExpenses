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

    using MyExpenses.Domain.IoT;
    using MyExpenses.Domain.IoT.Repositories;

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
        public virtual TDomain Add(TDomain model)
        {
            return _repository.Add(model);
        }

        /// <inheritdoc />
        public virtual TDomain Update(TDomain model)
        {
            return _repository.Update(model);
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
        public Task<TDomain> GetByIdAsync(Guid id, params Expression<Func<TDomain, object>>[] includes)
        {
            return _repository.GetByIdAsync(id, includes);
        }

        /// <inheritdoc />
        public Task<bool> RemoveAsync(Guid id)
        {
            return _repository.RemoveAsync(id);
        }

        /// <inheritdoc />
        public Task<TDomain> AddAsync(TDomain model)
        {
            return _repository.AddAsync(model);
        }

        /// <inheritdoc />
        public Task<TDomain> UpdateAsync(TDomain model)
        {
            return _repository.UpdateAsync(model);
        }

        #endregion
    }
}
