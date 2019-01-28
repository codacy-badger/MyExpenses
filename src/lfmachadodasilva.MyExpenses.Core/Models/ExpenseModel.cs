using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lfmachadodasilva.MyExpenses.Core.Models
{
    [Table(ModelUtility.ExpenseTable)]
    public class ExpenseModel : ModelBase
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Value { get; set; }

        public LabelModel Label { get; set; }

        public PaymentModel Payment { get; set; }

        [Required]
        public GroupModel Group { get; set; }
    }
}
