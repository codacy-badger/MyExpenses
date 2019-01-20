using System;
using System.Collections.Generic;
using lfmachadodasilva.MyExpenses.Core.Models.Dtos;

namespace lfmachadodasilva.MyExpenses.Core.Services
{
    public interface IGroupService : IService<GroupDto>
    {
        IEnumerable<GroupDto> GetAllByUser(Guid userId);
    }
}
