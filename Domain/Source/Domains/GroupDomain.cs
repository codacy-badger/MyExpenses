/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Domains
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using MyExpenses.Domain.IoT;    

    [Table("Group")]
    public class GroupDomain : DomainBase
    {
        public string Name { get; set; }

        public ICollection<GroupUser> Users { get; set; }

        public override void Copy(IBase baseObj)
        {
            if (baseObj is GroupDomain obj)
            {
                AutoMapper.Mapper.Map(this, obj);
            }
        }
    }
}
