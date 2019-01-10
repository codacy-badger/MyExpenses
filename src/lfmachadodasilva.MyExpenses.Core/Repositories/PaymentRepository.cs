using lfmachadodasilva.MyExpenses.Core.Models;

namespace lfmachadodasilva.MyExpenses.Core.Repositories
{
    internal class PaymentRepository : RepositoryBase<PaymentModel>
    {
        public PaymentRepository(MyExpensesContext context) : base(context)
        {
        }
    }
}
