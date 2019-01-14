using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lfmachadodasilva.MyExpenses.Core.Models
{
    [Table(ModelUtility.PaymentTable)]
    internal class PaymentModel : ModelBase
    {
        public string Name { get; set; }

        public IEnumerable<ExpenseModel> Expenses { get; set; }

        public GroupModel Group { get; set; }
    }
}
