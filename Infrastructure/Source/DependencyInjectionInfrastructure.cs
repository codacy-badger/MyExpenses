/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure
{
    using Microsoft.Extensions.DependencyInjection;

    using MyExpenses.Domain.IoC;
    using MyExpenses.Domain.IoC.Repositories;
    using MyExpenses.Infrastructure.Repositories;

    public static class DependencyInjectionInfrastructure
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IExpenseRepository, ExpensesRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IGroupUserRepository, GroupUserRepository>();
            services.AddScoped<ILabelRepository, LabelRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
