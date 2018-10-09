﻿/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Domains
{
    using System.ComponentModel.DataAnnotations.Schema;

    using MyExpenses.Domain.IoT;

    [Table("Label")]
    public class LabelDomain : DomainBase
    {
        public string Name { get; set; }

        public override void Copy(IBase baseObj)
        {
            if (baseObj is LabelDomain obj)
            {
                AutoMapper.Mapper.Map(this, obj);
            }
        }
    }
}
