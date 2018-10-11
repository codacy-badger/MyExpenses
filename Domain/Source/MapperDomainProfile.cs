/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain
{
    using AutoMapper;

    using MyExpenses.Domain.Domains;

    public class MapperDomainProfile : Profile
    {
        public MapperDomainProfile()
        {
            CreateMap<ExpenseDomain, ExpenseDomain>();
            CreateMap<GroupDomain, GroupDomain>();
            CreateMap<GroupUserDomain, GroupUserDomain>();
            CreateMap<LabelDomain, LabelDomain>();
            CreateMap<PaymentDomain, PaymentDomain>();
        }
    }
}
