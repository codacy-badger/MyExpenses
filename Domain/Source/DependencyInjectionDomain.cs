/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain
{
    using Microsoft.Extensions.DependencyInjection;

    using MyExpenses.Domain.IoC.Services;
    using MyExpenses.Domain.Services;

    public static class DependencyInjectionDomain
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<ILabelService, LabelService>();
            services.AddScoped<IPaymentService, PaymentService>();
        }
    }
}
