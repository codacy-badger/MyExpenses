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

    public class LabelAppService : AppServiceBase<LabelDomain, LabelDto>, ILabelAppService
    {
        private readonly ILabelService _service;

        public LabelAppService(ILabelService service, IUnitOfWork unitOfWork)
            : base(service, unitOfWork)
        {
            _service = service;
        }

        public async Task<ICollection<LabelDto>> GetAllByGroupId(Guid groupId)
        {
            return await _service
                .GetAll(x => x.Group.Users)
                .Where(x => x.Group.Id == groupId)
                .Select(x => Mapper.Map<LabelDomain, LabelDto>(x))
                .ToAsyncEnumerable().ToList();
        }

        //public ICollection<GroupDto> GetAllGroupsByUserId(Guid userId)
        //{
        //    // Method intentionally left empty.
        //}
    }
}
