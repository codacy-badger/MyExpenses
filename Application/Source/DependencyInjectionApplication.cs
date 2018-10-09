/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application
{
    using Microsoft.Extensions.DependencyInjection;

    using MyExpenses.Application.AppServices;
    using MyExpenses.Application.AppServices.Interfaces;

    public static class DependencyInjectionApplication
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IExpenseAppService, ExpenseAppService>();
            services.AddScoped<IGroupAppService, GroupAppService>();
            services.AddScoped<ILabelAppService, LabelAppService>();
            services.AddScoped<IPaymentAppService, PaymentAppService>();
        }
    }
}
