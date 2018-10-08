/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domains
{
    using MyExpenses.Domain.Domains;
    using MyExpenses.Domain.Interfaces;

    public class PaymentDomain : DomainBase
    {
        public string Name { get; set; }

        public override void Copy(IBaseId baseObj)
        {
            if (baseObj is PaymentDomain obj)
            {
                AutoMapper.Mapper.Map(this, obj);
            }
        }
    }
}
