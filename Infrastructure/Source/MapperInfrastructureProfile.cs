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

    public class MapperInfrastructureProfile : Profile
    {
        public MapperInfrastructureProfile()
        {
            CreateMap<ExpenseDomain, ExpenseTable>().ReverseMap();
            CreateMap<GroupDomain, GroupTable>().ReverseMap();
            CreateMap<LabelDomain, LabelTable>().ReverseMap();
            CreateMap<PaymentDomain, PaymentTable>().ReverseMap();
        }
    }
}
