/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Domains
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using MyExpenses.Domain.IoT;

    [Table("Expense")]
    public class ExpenseDomain : DomainBase
    {
        public string Name { get; set; }

        public float Value { get; set; }

        public DateTime ExpenseDate { get; set; }

        public bool IsIncoming { get; set; }

        public LabelDomain Label { get; set; }

        public PaymentDomain Payment { get; set; }

        public override void Copy(IBase baseObj)
        {
            if (baseObj is ExpenseDomain obj)
            {
                AutoMapper.Mapper.Map(this, obj);
            }
        }
    }
}
