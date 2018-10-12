/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.IoT
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Service interface
    /// </summary>
    /// <typeparam name="TDomain"></typeparam>
    public interface IService<TDomain>
    {
        /// <summary>
        /// Get all objects
        /// </summary>
        /// <param name="includes">Include expression</param>
        /// <returns>All objects</returns>
        IQueryable<TDomain> GetAll(params Expression<Func<TDomain, object>>[] includes);

        /// <summary>
        /// Get object by Id
        /// </summary>
        /// <param name="id">Id of the object to be find</param>
        /// <param name="includes">Include expression</param>
        /// <returns></returns>
        TDomain GetById(Guid id, params Expression<Func<TDomain, object>>[] includes);
        Task<TDomain> GetByIdAsync(Guid id, params Expression<Func<TDomain, object>>[] includes);

        /// <summary>
        /// Remove object
        /// </summary>
        /// <param name="id">If of the object to remove</param>
        /// <returns>True if could remove and false otherwise</returns>
        bool Remove(Guid id);
        Task<bool> RemoveAsync(Guid id);

        /// <summary>
        /// Add an object
        /// </summary>
        /// <param name="obj">Object to add</param>
        /// <returns>Object added</returns>
        TDomain Add(TDomain obj);
        Task<TDomain> AddAsync(TDomain obj);

        /// <summary>
        /// Update an object
        /// </summary>
        /// <param name="obj">Object to update</param>
        /// <returns>Object updated</returns>
        TDomain Update(TDomain obj);
        Task<TDomain> UpdateAsync(TDomain obj);
    }
}
