/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Repositories
{
    using MyExpenses.Domain.Domains;
    using MyExpenses.Domain.IoT.Repositories;

    public class PaymentRepository : RepositoryBase<PaymentDomain>, IPaymentRepository
    {
        public PaymentRepository(MyExpensesContext context)
            : base(context)
        {
        }
    }
}
