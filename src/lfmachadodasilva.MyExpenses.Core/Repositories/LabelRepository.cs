using lfmachadodasilva.MyExpenses.Core.Models;

namespace lfmachadodasilva.MyExpenses.Core.Repositories
{
    internal class LabelRepository : RepositoryBase<LabelModel>
    {
        public LabelRepository(MyExpensesContext context) : base(context)
        {
        }
    }
}
