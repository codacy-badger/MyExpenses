/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure
{
    using AutoMapper;

    using MyExpenses.Domain.Domains;
    using MyExpenses.Infrastructure.Tables;

    public static class MapperInfrastructure
    {
        public static void Configure()
        {
            Mapper.Reset();
            Mapper.Initialize(
                cfg =>
                    {
                        cfg.CreateMap<ExpenseDomain, ExpenseTable>().ReverseMap();
                        cfg.CreateMap<LabelDomain, LabelTable>().ReverseMap();
                        cfg.CreateMap<PaymentDomain, PaymentTable>().ReverseMap();
                        cfg.CreateMap<GroupDomain, GroupTable>().ReverseMap();
                    });
        }
    }
}
