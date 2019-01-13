using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using lfmachadodasilva.MyExpenses.Core.Models.Dtos;

namespace lfmachadodasilva.MyExpenses.Core.Services
{
    public interface ILabelService : IService<LabelDto>
    {
        Task<IEnumerable<LabelDto>> Get(Guid groupdId, int month, int year);
    }
}
