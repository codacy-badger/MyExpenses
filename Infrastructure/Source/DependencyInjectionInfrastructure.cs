/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure
{
    using Microsoft.Extensions.DependencyInjection;

    using MyExpenses.Domain.IoT.Repositories;
    using MyExpenses.Infrastructure.Repositories;

    public static class DependencyInjectionInfrastructure
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IExpenseRepository, ExpensesRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<ILabelRepository, LabelRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
        }
    }
}
