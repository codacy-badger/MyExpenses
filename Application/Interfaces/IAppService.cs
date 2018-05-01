﻿/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using MyExpenses.Domain.Interfaces;

    public interface IAppService<TModel> where TModel : IModel
    {
        Task<IEnumerable<TModel>> GetAsync(Expression<Func<TModel, bool>> filter, params Expression<Func<TModel, object>>[] includes);

        Task<IEnumerable<TModel>> GetAllAsync(params Expression<Func<TModel, object>>[] includes);

        Task<TModel> GetByIdAsync(long id, params Expression<Func<TModel, object>>[] includes);

        Task<bool> RemoveAsync(TModel model);

        Task<bool> RemoveAsync(long id);

        Task<TModel> AddOrUpdateAsync(TModel model);
    }
}
