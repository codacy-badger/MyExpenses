/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Domains
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using MyExpenses.Domain.IoC;

    [Table("Group")]
    public class GroupDomain : DomainBase
    {
        public GroupDomain()
        {
            Users = new List<GroupUserDomain>();
        }

        public string Name { get; set; }

        public ICollection<GroupUserDomain> Users { get; set; }

        public ICollection<LabelDomain> Labels { get; set; }

        public ICollection<PaymentDomain> Payments { get; set; }

        public ICollection<ExpenseDomain> Expenses { get; set; }

        public override void Copy(IBase baseObj)
        {
            if (baseObj is GroupDomain obj)
            {
                AutoMapper.Mapper.Map(this, obj);
            }
        }
    }
}
