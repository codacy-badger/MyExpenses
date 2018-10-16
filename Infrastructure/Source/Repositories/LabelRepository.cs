/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Repositories
{
    using System.Threading.Tasks;

    using MyExpenses.Domain.Domains;
    using MyExpenses.Domain.IoC.Repositories;

    public class LabelRepository : RepositoryBase<LabelDomain>, ILabelRepository
    {
        private readonly MyExpensesContext _context;

        public LabelRepository(MyExpensesContext context)
            : base(context)
        {
            _context = context;
        }

        public override async Task<LabelDomain> UpdateAsync(LabelDomain obj)
        {
            if (obj == null)
                return null;

            LabelDomain result = await GetByIdAsync(obj.Id, x => x.Group);
            if (result == null)
                return null;

            UpdateLastUpdate(obj);

            // copy attributes
            result.Copy(obj);

            result.Group = await _context.Groups.FindAsync(obj.Id);

            return result;
        }
    }
}
