/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.AppServices.Interfaces
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using MyExpenses.Application.Dtos;

    public interface IGroupAppService : IAppService<GroupDto>
    {
        IQueryable<GroupDto> GetAllWithIncludes(Guid userId);

        Task<GroupDto> GetByIdWithIncludeAsync(Guid id);
    }
}
