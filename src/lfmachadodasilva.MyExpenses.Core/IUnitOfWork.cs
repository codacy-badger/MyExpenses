using System.Threading.Tasks;

namespace lfmachadodasilva.MyExpenses.Core
{
    internal interface IUnitOfWork
    {
        /// <summary>
        /// Begin transaction
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Commit
        /// </summary>
        Task<int> CommitAsync();
    }
}
