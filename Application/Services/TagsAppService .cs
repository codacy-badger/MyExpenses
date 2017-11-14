﻿/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Services
{
    using MyExpenses.Application.DataTransferObject;
    using MyExpenses.Application.Interfaces.Adapters;
    using MyExpenses.Application.Interfaces.Services;
    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Interfaces.DomainServices;
    using MyExpenses.Domain.Models;

    public class TagsAppService : AppServiceBase<Tag, TagDto>, ITagsAppService
    {
        public TagsAppService(
            ITagsService domainService,
            IUnitOfWork unitOfWork,
            ITagsAdapter adapter) :
            base(domainService, unitOfWork, adapter) { }
    }
}
