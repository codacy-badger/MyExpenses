using System;
using System.Collections.Generic;
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

        public IEnumerable<TDto> GetAll()
        {
            var models = _repository.Get();
            var dtos = _mapper.Map<IEnumerable<TModel>, IEnumerable<TDto>>(models);
            return dtos;
        }

        public TDto GetById(Guid id)
        {
            var model = _repository.GetById(id);
            var dto = _mapper.Map<TModel, TDto>(model);
            return dto;
        }
    }
}
