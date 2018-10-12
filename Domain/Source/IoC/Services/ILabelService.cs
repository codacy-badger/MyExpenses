/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/
namespace MyExpenses.Domain.IoC.Services
{
    using System;
    using System.Collections.Generic;

    using MyExpenses.Domain.Domains;

    public interface ILabelService : IService<LabelDomain>
    {
        IEnumerable<LabelDomain> GetAllWithIncludes(Guid userId);
    }
}
