/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Interfaces
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Service interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IService<T>
    {
        /// <summary>
        /// Get all objects
        /// </summary>
        /// <param name="includes">Include expression</param>
        /// <returns>All objects</returns>
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Get object by Id
        /// </summary>
        /// <param name="id">Id of the object to be find</param>
        /// <param name="includes">Include expression</param>
        /// <returns></returns>
        T GetById(Guid id, params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes);

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
        /// <param name="model">Object to add</param>
        /// <returns>Object added</returns>
        T Add(T model);
        Task<T> AddAsync(T model);

        /// <summary>
        /// Update an object
        /// </summary>
        /// <param name="model">Object to update</param>
        /// <returns>Object updated</returns>
        T Update(T model);
        Task<T> UpdateAsync(T model);
    }
}
