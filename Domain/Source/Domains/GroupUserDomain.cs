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

    [Table("GroupUser")]
    public class GroupUserDomain : DomainBase
    {
        public GroupDomain Group { get; set; }

        public Guid UserId { get; set; }

        public override void Copy(IBase baseObj)
        {
            if (baseObj is DomainBase obj)
            {
                AutoMapper.Mapper.Map(this, obj);
            }
        }
    }
}
