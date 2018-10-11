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

    public class MapperApplicationProfile : Profile
    {
        public MapperApplicationProfile()
        {
            CreateMap<ExpenseDomain, ExpenseDto>().ReverseMap();
            CreateMap<LabelDomain, LabelDto>().ReverseMap();
            CreateMap<PaymentDomain, PaymentDto>().ReverseMap();
            CreateMap<GroupDomain, GroupDto>().ReverseMap();
            CreateMap<GroupUser, GroupUserDto>().ReverseMap();
        }
    }
}
