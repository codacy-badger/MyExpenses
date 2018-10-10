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

        protected AppServiceBase(IService<TDomain> service)
        {
            _service = service;
        }

        public virtual IQueryable<TDto> Get()
        {
            var objs = _service.GetAll();
            return Mapper.Map<IQueryable<TDomain>, IQueryable<TDto>>(objs);
        }

        public virtual TDto GetById(Guid id)
        {
            var obj = _service.GetById(id);
            return Mapper.Map<TDomain, TDto>(obj);
        }

        public virtual async Task<TDto> GetByIdAsync(Guid id)
        {
            var obj = await _service.GetByIdAsync(id);
            return Mapper.Map<TDomain, TDto>(obj);
        }

        public virtual bool Remove(Guid id)
        {
            return _service.Remove(id);
        }

        public virtual async Task<bool> RemoveAsync(Guid id)
        {
            var result = await _service.RemoveAsync(id);
            return result;
        }

        public virtual TDto Add(TDto obj)
        {
            var domain = Mapper.Map<TDto, TDomain>(obj);
            var newObj = _service.Add(domain);
            return Mapper.Map<TDomain, TDto>(newObj);
        }

        public virtual TDto Update(TDto obj)
        {
            var domain = Mapper.Map<TDto, TDomain>(obj);
            var updatedObj = _service.Update(domain);
            return Mapper.Map<TDomain, TDto>(updatedObj);
        }

        public async Task<TDto> AddAsync(TDto obj)
        {
            var domain = Mapper.Map<TDto, TDomain>(obj);
            var newObj = await _service.AddAsync(domain);
            return Mapper.Map<TDomain, TDto>(newObj);
        }

        public async Task<TDto> UpdateAsync(TDto obj)
        {
            var domain = Mapper.Map<TDto, TDomain>(obj);
            var updatedObj = await _service.UpdateAsync(domain);
            return Mapper.Map<TDomain, TDto>(updatedObj);
        }
    }
}
