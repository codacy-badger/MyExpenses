/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.AppServices
{
    using MyExpenses.Application.AppServices.Interfaces;
    using MyExpenses.Application.Dtos;
    using MyExpenses.Domain.Domains;
    using MyExpenses.Domain.IoT;
    using MyExpenses.Domain.IoT.Services;

    public class PaymentAppService : AppServiceBase<PaymentDomain, PaymentDto>, IPaymentAppService
    {
        public PaymentAppService(IPaymentService service, IUnitOfWork unitOfWork)
            : base(service, unitOfWork)
        {
        }
    }
}
