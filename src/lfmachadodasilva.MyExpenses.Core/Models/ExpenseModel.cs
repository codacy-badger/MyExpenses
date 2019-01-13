using System;

namespace lfmachadodasilva.MyExpenses.Core.Models
{
    public class ExpenseModel : ModelBase
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public decimal Value { get; set; }

        public LabelModel Label { get; set; }

        public PaymentModel Payment { get; set; }

        public GroupModel Group { get; set; }
    }
}
