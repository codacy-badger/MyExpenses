using System;
using AutoMapper;
using lfmachadodasilva.MyExpenses.Core.Repositories;
using lfmachadodasilva.MyExpenses.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace lfmachadodasilva.MyExpenses.Core
{
    public static class MyExpensesDependencies
    {
        public static IServiceCollection AddMyExpenses(this IServiceCollection services)
        {
            // Repositories
            services.TryAddTransient<IExpenseRepository, ExpenseRepository>();
            services.TryAddTransient<ILabelRepository, LabelRepository>();
            services.TryAddTransient<IPaymentRepository, PaymentRepository>();
            services.TryAddTransient<IGroupRepository, GroupRepository>();

            // Services
            services.TryAddTransient<IExpenseService, ExpenseService>();
            services.TryAddTransient<ILabelService, LabelService>();
            services.TryAddTransient<IPaymentService, PaymentService>();
            services.TryAddTransient<IGroupService, GroupService>();

            // General
            services.TryAddTransient<IUnitOfWork, UnitOfWork>();

            // AutoMapper
            return services
                .AddAutoMapper(cfg => cfg.AddProfile<MyExpensesProfile>());
        }

        public static IServiceCollection AddMyExpensesContextInMemory(this IServiceCollection services)
        {
            return services
                .AddDbContext<MyExpensesContext>(options => 
                    options.UseInMemoryDatabase(Guid.NewGuid().ToString()));
        }

        public static IServiceCollection AddMyExpensesContext(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            return services
                .AddDbContext<MyExpensesContext>(options =>
                    options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
