﻿/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Dtos
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class IndexPaymentDto
    {
        public PaymentDto Payment { get; set; }

        [DisplayName("#")]
        public int Amount { get; set; }

        [DisplayName("Total")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float Value { get; set; }
    }
}
