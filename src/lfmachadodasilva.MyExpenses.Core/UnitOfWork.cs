using System.Threading.Tasks;

namespace lfmachadodasilva.MyExpenses.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyExpensesContext _context;

        public UnitOfWork(MyExpensesContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            // Method intentionally left empty.
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
