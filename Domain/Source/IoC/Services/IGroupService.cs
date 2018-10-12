/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/
namespace MyExpenses.Domain.IoC.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MyExpenses.Domain.Domains;

    public interface IGroupService : IService<GroupDomain>
    {
        IQueryable<GroupDomain> GetAllWithIncludes(Guid userId);

        Task<GroupDomain> GetByIdWithIncludeAsync(Guid groupId);

        Task<GroupDomain> Update(GroupDomain obj, ICollection<Guid> newUsersId);
    }
}
