/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application
{
    using AutoMapper;

    using MyExpenses.Application.Dtos;
    using MyExpenses.Domain.Domains;

    public static class MapperApplication
    {
        public static void Configure()
        {
            Mapper.Initialize(
                cfg =>
                    {
                        cfg.CreateMap<ExpenseDomain, ExpenseDto>().ReverseMap();
                        cfg.CreateMap<LabelDomain, LabelDto>().ReverseMap();
                        cfg.CreateMap<PaymentDomain, PaymentDto>().ReverseMap();
                        cfg.CreateMap<GroupDomain, GroupDto>().ReverseMap();
                    });
        }
    }
}
