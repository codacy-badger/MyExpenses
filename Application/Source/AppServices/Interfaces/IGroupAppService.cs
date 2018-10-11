/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.AppServices.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyExpenses.Application.Dtos;

    public interface IGroupAppService : IAppService<GroupDto>
    {
        IEnumerable<GroupDto> GetAllWithIncludes(Guid userId);

        Task<GroupDto> GetByIdWithIncludeAsync(Guid groupId);

        Task<GroupDto> Update(GroupDto obj, ICollection<Guid> users);
    }
}
