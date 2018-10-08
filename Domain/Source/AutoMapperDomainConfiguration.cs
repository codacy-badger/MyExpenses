/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain
{
    using AutoMapper;
    using MyExpenses.Domains;

    public class AutoMapperDomainConfiguration
    {
        public static void Configure()
        {
            Mapper.Reset();
            Mapper.Initialize(
                cfg =>
                {
                    cfg.CreateMap<ExpenseDomain, ExpenseDomain>();
                    cfg.CreateMap<LabelDomain, LabelDomain>();
                    cfg.CreateMap<PaymentDomain, PaymentDomain>();
                });
        }
    }
}
