/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.IoC.Repositories
{
    public interface IRepository<TTable> : IService<TTable> where TTable : IBase
    {
    }
}
