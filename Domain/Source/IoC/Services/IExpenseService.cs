/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/
namespace MyExpenses.Domain.IoC.Services
{
    using MyExpenses.Domain.Domains;

    public interface IExpenseService : IService<ExpenseDomain>
    {
    }
}
