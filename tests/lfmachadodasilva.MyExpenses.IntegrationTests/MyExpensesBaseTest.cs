using lfmachadodasilva.MyExpenses.Core;
using Microsoft.Extensions.DependencyInjection;

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
