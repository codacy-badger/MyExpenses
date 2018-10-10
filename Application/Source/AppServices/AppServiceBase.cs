/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.AppServices
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using MyExpenses.Application.AppServices.Interfaces;
    using MyExpenses.Application.Dtos;
    using MyExpenses.Domain.IoT;

    public abstract class AppServiceBase<TDomain, TDto> : IAppService<TDto> where TDomain : IBase where TDto : IDto
    {
        private readonly IService<TDomain> _service;
        private readonly IUnitOfWork _unitOfwork;

        protected AppServiceBase(IService<TDomain> service, IUnitOfWork unitOfwork)
        {
            _service = service;
            _unitOfwork = unitOfwork;
        }

        public virtual IQueryable<TDto> GetAll()
        {
            var objs = _service.GetAll();
            return Mapper.Map<IQueryable<TDomain>, IQueryable<TDto>>(objs);
        }

        #region non-async methods

        public virtual TDto GetById(Guid id)
        {
            var obj = _service.GetById(id);
            return Mapper.Map<TDomain, TDto>(obj);
        }

        public virtual bool Remove(Guid id)
        {
            _unitOfwork.BeginTransaction();

            var result = _service.Remove(id);

            if (result && _unitOfwork.Commit() > 0)
            {
                return true;
            }

            return false;
        }

        public virtual TDto Add(TDto obj)
        {
            _unitOfwork.BeginTransaction();

            var domain = Mapper.Map<TDto, TDomain>(obj);
            var newObj = _service.Add(domain);

            if (newObj != null && _unitOfwork.Commit() > 0)
            {
                return Mapper.Map<TDomain, TDto>(newObj);
            }

            return default(TDto);
        }

        public virtual TDto Update(TDto obj)
        {
            _unitOfwork.BeginTransaction();

            var domain = Mapper.Map<TDto, TDomain>(obj);
            var newObj = _service.Update(domain);

            if (newObj != null && _unitOfwork.Commit() > 0)
            {
                return Mapper.Map<TDomain, TDto>(newObj);
            }

            return default(TDto);
        }

        #endregion

        #region async methods

        public virtual async Task<TDto> GetByIdAsync(Guid id)
        {
            var obj = await _service.GetByIdAsync(id);
            return Mapper.Map<TDomain, TDto>(obj);
        }

        public virtual async Task<bool> RemoveAsync(Guid id)
        {
            _unitOfwork.BeginTransaction();

            var result = await _service.RemoveAsync(id);

            if (result && await _unitOfwork.CommitAsync() > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<TDto> AddAsync(TDto obj)
        {
            _unitOfwork.BeginTransaction();

            var domain = Mapper.Map<TDto, TDomain>(obj);
            var newObj = await _service.AddAsync(domain);

            if (newObj != null && await _unitOfwork.CommitAsync() > 0)
            {
                return Mapper.Map<TDomain, TDto>(newObj);
            }

            return default(TDto);
        }

        public async Task<TDto> UpdateAsync(TDto obj)
        {
            _unitOfwork.BeginTransaction();

            var domain = Mapper.Map<TDto, TDomain>(obj);
            var newObj = await _service.UpdateAsync(domain);

            if (newObj != null && await _unitOfwork.CommitAsync() > 0)
            {
                return Mapper.Map<TDomain, TDto>(newObj);
            }

            return default(TDto);
        }

        #endregion
    }
}
