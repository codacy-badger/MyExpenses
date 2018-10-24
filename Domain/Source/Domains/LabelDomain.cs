/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Domains
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using MyExpenses.Domain.IoC;

    [Table("Label")]
    public class LabelDomain : DomainBase
    {
        public string Name { get; set; }

        public Guid? GroupId { get; set; }

        public GroupDomain Group { get; set; }

        public override void Copy(IBase baseObj)
        {
            if (baseObj is LabelDomain obj)
            {
                AutoMapper.Mapper.Map(obj, this);
            }
        }
    }
}
