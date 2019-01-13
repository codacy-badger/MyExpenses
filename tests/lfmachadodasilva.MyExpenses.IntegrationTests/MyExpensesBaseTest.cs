using lfmachadodasilva.MyExpenses.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lfmachadodasilva.MyExpenses.IntegrationTests
{
    public class MyExpensesBaseTest
    {
        protected readonly ServiceProvider ServiceProvider;

        public MyExpensesBaseTest()
        {
            IServiceCollection services = new ServiceCollection()
                .AddMyExpenses()
                .AddMyExpensesContextInMemory();

            // build
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
