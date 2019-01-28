using AutoMapper;
using lfmachadodasilva.MyExpenses.Core.Repositories;
using lfmachadodasilva.MyExpenses.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace lfmachadodasilva.MyExpenses.Core
{
    public static class MyExpensesDependencies
    {
        public static IServiceCollection AddMyExpensesCore(this IServiceCollection services, IConfiguration configuration)
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

            var migrationAssembly = configuration.GetSection("MigrationAssembly").Value;
            var connection = configuration.GetConnectionString("DefaultConnection");

            services
                .AddDbContext<MyExpensesContext>(options =>
                    options.UseSqlServer(connection,
                        x => x.MigrationsAssembly(migrationAssembly)));

            // AutoMapper
            return services;//.AddAutoMapper(cfg => cfg.AddProfile<MyExpensesProfile>());
        }
    }
}
