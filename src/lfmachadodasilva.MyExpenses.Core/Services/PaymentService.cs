using AutoMapper;
using lfmachadodasilva.MyExpenses.Core.Models;
using lfmachadodasilva.MyExpenses.Core.Models.Dtos;
using lfmachadodasilva.MyExpenses.Core.Repositories;

namespace lfmachadodasilva.MyExpenses.Core.Services
{
    internal class PaymentService : ServiceBase<PaymentDto, PaymentModel>, IPaymentService
    {
        internal PaymentService(IPaymentRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
