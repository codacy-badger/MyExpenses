/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.AppServices.Interfaces
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using MyExpenses.Application.Dtos;

    public interface IAppService<TDto> where TDto : IDto
    {
        /// <summary>
        /// Get all objects
        /// </summary>
        /// <returns>All objects</returns>
        IQueryable<TDto> GetAll();

        /// <summary>
        /// Get object by Id
        /// </summary>
        /// <param name="id">Id of the object to be find</param>
        /// <returns></returns>
        TDto GetById(Guid id);
        Task<TDto> GetByIdAsync(Guid id);

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
        TDto Add(TDto obj);
        Task<TDto> AddAsync(TDto obj);

        /// <summary>
        /// Update an object
        /// </summary>
        /// <param name="model">Object toupdate</param>
        /// <returns>Object updated</returns>
        TDto Update(TDto obj);
        Task<TDto> UpdateAsync(TDto obj);
    }
}
