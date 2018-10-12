/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.AppServices.Interfaces
{
    using System;
    using System.Collections.Generic;

    using MyExpenses.Application.Dtos;

    public interface ILabelAppService : IAppService<LabelDto>
    {
        IEnumerable<LabelDto> GetAllWithIncludes(Guid userId);
    }
}
