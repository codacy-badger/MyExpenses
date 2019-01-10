namespace lfmachadodasilva.MyExpenses.Core.Models
{
    internal class PaymentModel : ModelBase
    {
        internal string Name { get; set; }

        internal GroupModel Group { get; set; }
    }
}
