using System;

namespace lfmachadodasilva.MyExpenses.Core.Models.Dtos
{
    public class ExpenseDto : DtoBase
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public decimal Value { get; set; }
    }
}
