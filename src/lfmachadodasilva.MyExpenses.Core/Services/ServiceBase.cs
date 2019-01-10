using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using lfmachadodasilva.MyExpenses.Core.Models;
using lfmachadodasilva.MyExpenses.Core.Models.Dtos;
using lfmachadodasilva.MyExpenses.Core.Repositories;

namespace lfmachadodasilva.MyExpenses.Core.Services
{
    internal abstract class ServiceBase<TDto, TModel> : IService<TDto> where TDto : IDto where TModel : IModel
    {
        private readonly IRepository<TModel> _repository;
        private readonly IMapper _mapper;

        protected ServiceBase(IRepository<TModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual IEnumerable<TDto> GetAll()
        {
            var models = _repository.GetAll();
            var dtos = _mapper.Map<IEnumerable<TModel>, IEnumerable<TDto>>(models);
            return dtos;
        }

        public virtual async Task<TDto> GetById(Guid id)
        {
            var model = await _repository.GetById(id);
            var dto = _mapper.Map<TModel, TDto>(model);
            return dto;
        }
    }
}
