using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using lfmachadodasilva.MyExpenses.Core.Models.Dtos;

namespace lfmachadodasilva.MyExpenses.Core.Services
{
    public interface IService<TDto> where TDto : IDto
    {
        IEnumerable<TDto> GetAll();

        Task<TDto> GetById(Guid id);
    }
}
