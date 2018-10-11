/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.AppServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;

    using MyExpenses.Application.AppServices.Interfaces;
    using MyExpenses.Application.Dtos;
    using MyExpenses.Domain.Domains;
    using MyExpenses.Domain.IoT;
    using MyExpenses.Domain.IoT.Services;

    public class GroupAppService : AppServiceBase<GroupDomain, GroupDto>, IGroupAppService
    {
        private readonly IGroupService _service;

        public GroupAppService(IGroupService service, IUnitOfWork unitOfWork)
            : base(service, unitOfWork)
        {
            _service = service;
        }

        public IEnumerable<GroupDto> GetAllWithIncludes(Guid userId)
        {
            return _service.GetAllWithIncludes(userId).Select(Mapper.Map<GroupDomain, GroupDto>);
        }

        public async Task<GroupDto> GetByIdWithIncludeAsync(Guid groupId)
        {
            var obj = await _service.GetByIdWithIncludeAsync(groupId);
            return Mapper.Map<GroupDomain, GroupDto>(obj);
        }
    }
}
