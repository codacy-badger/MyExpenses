/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Domains
{
    using System.ComponentModel.DataAnnotations.Schema;

    using MyExpenses.Domain.IoT;

    [Table("Payment")]
    public class PaymentDomain : DomainBase
    {
        public string Name { get; set; }

        public override void Copy(IBase baseObj)
        {
            if (baseObj is PaymentDomain obj)
            {
                AutoMapper.Mapper.Map(this, obj);
            }
        }
    }
}
