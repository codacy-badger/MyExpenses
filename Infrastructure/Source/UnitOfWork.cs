/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using MyExpenses.Domain.IoC;

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MyExpensesContext _context;

        public UnitOfWork(MyExpensesContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public void BeginTransaction()
        {
            // Method intentionally left empty.
        }

        /// <inheritdoc />
        public int Commit()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                Console.WriteLine(e);
                throw new Exception(e.Message);
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
                throw new Exception(e.Message);
            }
        }

        /// <inheritdoc />
        public async Task<int> CommitAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                Console.WriteLine(e);
                throw new Exception(e.Message);
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
                throw new Exception(e.Message);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
