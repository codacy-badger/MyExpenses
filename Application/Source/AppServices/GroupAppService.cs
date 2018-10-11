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

        public IQueryable<GroupDto> GetAllWithIncludes(Guid userId)
        {
            return _service
                .GetAll(x => x.Users)
                .Where(x => x.Users.Any(y => y.UserId == userId))
                .Select(x => Mapper.Map<GroupDomain, GroupDto>(x));
        }

        public GroupDto GetByIdWithIncludeAsync(Guid id)
        {
            var obj = _service
                .GetAll(x => x.Users)
                .First(x => x.Id == id);
            return Mapper.Map<GroupDomain, GroupDto>(obj);
        }
    }
}
