/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.AppServices
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;

    using Microsoft.EntityFrameworkCore;

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

        public IQueryable<GroupDto> GetAllWithIncludes()
        {
            return _service.GetAll(x => x.Users).Select(x => Mapper.Map<GroupDomain, GroupDto>(x));
        }

        public async Task<GroupDto> GetByIdWithIncludeAsync(Guid id)
        {
            var obj = await _service.GetAll(x => x.Users).FirstAsync(x => x.Id == id);
            return Mapper.Map<GroupDomain, GroupDto>(obj);
        }
    }
}
