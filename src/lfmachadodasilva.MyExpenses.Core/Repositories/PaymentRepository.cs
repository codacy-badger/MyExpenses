using AutoMapper;
using lfmachadodasilva.MyExpenses.Core.Models;

namespace lfmachadodasilva.MyExpenses.Core.Repositories
{
    public class PaymentRepository : RepositoryBase<PaymentModel>, IPaymentRepository
    {
        public PaymentRepository(MyExpensesContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
