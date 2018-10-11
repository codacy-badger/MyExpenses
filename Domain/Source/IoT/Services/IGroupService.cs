/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/
namespace MyExpenses.Domain.IoT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MyExpenses.Domain.Domains;
    using MyExpenses.Domain.IoT;

    public interface IGroupService : IService<GroupDomain>
    {
        IQueryable<GroupDomain> GetAllWithIncludes(Guid userId);

        Task<GroupDomain> GetByIdWithIncludeAsync(Guid groupId);

        void Update(GroupDomain obj, ICollection<Guid> users);
    }
}
