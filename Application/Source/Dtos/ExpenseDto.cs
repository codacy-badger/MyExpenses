/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Dtos
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ExpenseDto : DtoBase
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public float Value { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ExpenseDate { get; set; }

        public bool IsIncoming { get; set; }

        public LabelDto Label { get; set; }

        public PaymentDto Payment { get; set; }
    }
}
