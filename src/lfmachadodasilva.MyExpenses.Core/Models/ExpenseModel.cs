using System;

namespace lfmachadodasilva.MyExpenses.Core.Models
{
    internal class ExpenseModel : ModelBase
    {
        internal string Name { get; set; }

        internal DateTime Date { get; set; }

        internal decimal Value { get; set; }

        internal LabelModel Label { get; set; }

        internal PaymentModel Payment { get; set; }

        internal GroupModel Group { get; set; }
    }
}
