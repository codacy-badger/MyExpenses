using AutoMapper;
using lfmachadodasilva.MyExpenses.Core.Models;

namespace lfmachadodasilva.MyExpenses.Core.Repositories
{
    internal class PaymentRepository : RepositoryBase<PaymentModel>, IPaymentRepository
    {
        public PaymentRepository(MyExpensesContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
