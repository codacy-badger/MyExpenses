using AutoMapper;
using lfmachadodasilva.MyExpenses.Core.Models;

namespace lfmachadodasilva.MyExpenses.Core.Repositories
{
    public class LabelRepository : RepositoryBase<LabelModel>, ILabelRepository
    {
        public LabelRepository(MyExpensesContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
