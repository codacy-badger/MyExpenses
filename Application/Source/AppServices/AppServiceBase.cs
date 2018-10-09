/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.AppServices
{
    using System;
    using System.Linq;

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
            throw new NotImplementedException();
        }

        public virtual TDto GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual TDto Add(TDto model)
        {
            throw new NotImplementedException();
        }

        public virtual TDto Update(TDto model)
        {
            throw new NotImplementedException();
        }
    }
}
