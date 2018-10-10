/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/
namespace MyExpenses.Domain.Services
{
    using MyExpenses.Domain.Domains;
    using MyExpenses.Domain.IoT.Repositories;
    using MyExpenses.Domain.IoT.Services;

    public class PaymentService : ServiceBase<PaymentDomain>, IPaymentService
    {
        public PaymentService(IPaymentRepository repository)
            : base(repository)
        {
        }
    }
}
