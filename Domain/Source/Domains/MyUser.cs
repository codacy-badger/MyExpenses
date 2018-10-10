/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Domains
{
    using System;

    using MyExpenses.Domain.IoT;

    public class GroupUser : DomainBase
    {
        public Guid UserId { get; set; }

        public GroupDomain Group { get; set; }

        public override void Copy(IBase baseObj)
        {
            if (baseObj is DomainBase obj)
            {
                AutoMapper.Mapper.Map(this, obj);
            }
        }
    }
}
