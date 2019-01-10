using System;
using System.Collections.Generic;
using lfmachadodasilva.MyExpenses.Core.Models.Dtos;

namespace lfmachadodasilva.MyExpenses.Core.Services
{
    public interface IService<TDto> where TDto : IDto
    {
        IEnumerable<TDto> GetAll();

        TDto GetById(Guid id);
    }
}
