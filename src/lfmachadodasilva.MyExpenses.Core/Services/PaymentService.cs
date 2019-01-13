using AutoMapper;
using lfmachadodasilva.MyExpenses.Core.Models;
using lfmachadodasilva.MyExpenses.Core.Models.Dtos;
using lfmachadodasilva.MyExpenses.Core.Repositories;

namespace lfmachadodasilva.MyExpenses.Core.Services
{
    public class PaymentService : ServiceBase<PaymentDto, PaymentModel>, IPaymentService
    {
        public PaymentService(IPaymentRepository repository, IUnitOfWork unitOfWork, IMapper mapper) :
            base(repository, unitOfWork, mapper)
        {
        }
    }
}
