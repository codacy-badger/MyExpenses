/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Tables
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using MyExpenses.Domain.Domains;

    [Table("Expense")]
    public class ExpenseTable : TableBase
    {
        public float Value { get; set; }

        public DateTime ExpenseDate { get; set; }

        public bool IsIncoming { get; set; }

        public LabelDomain Label { get; set; }

        public PaymentDomain Payment { get; set; }

        public override void Copy(ITable baseObj)
        {
            if (baseObj is ExpenseTable obj)
            {
                AutoMapper.Mapper.Map(this, obj);
            }
        }
    }
}
