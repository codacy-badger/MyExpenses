using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        protected ServiceBase(IRepository<TModel> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public virtual IEnumerable<TDto> GetAll()
        {
            var models = _repository.GetAll();
            var dtos = _mapper.Map<IEnumerable<TModel>, IEnumerable<TDto>>(models);
            return dtos;
        }

        public virtual async Task<TDto> GetByIdAsync(Guid id)
        {
            var model = await _repository.GetByIdAsync(id);
            var dto = _mapper.Map<TModel, TDto>(model);
            return dto;
        }

        public virtual async Task<TDto> UpdateAsync(TDto dto)
        {
            _unitOfWork.BeginTransaction();

            var model = await _repository.UpdateAsync(_mapper.Map<TDto, TModel>(dto));

            await _unitOfWork.CommitAsync();

            return _mapper.Map<TModel, TDto>(model);
        }

        public virtual async Task<TDto> AddAsync(TDto dto)
        {
            _unitOfWork.BeginTransaction();

            var model = await _repository.UpdateAsync(_mapper.Map<TDto, TModel>(dto));

            await _unitOfWork.CommitAsync();

            return _mapper.Map<TModel, TDto>(model);
        }

        public virtual Task<bool> RemoveAsync(Guid id)
        {
            return _repository.RemoveAsync(id);
        }
    }
}
