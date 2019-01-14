using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lfmachadodasilva.MyExpenses.Core.Models
{
    [Table(ModelUtility.ExpenseTable)]
    internal class ExpenseModel : ModelBase
    {
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Currency)]
        public decimal Value { get; set; }

        public LabelModel Label { get; set; }

        public PaymentModel Payment { get; set; }

        public GroupModel Group { get; set; }
    }
}
