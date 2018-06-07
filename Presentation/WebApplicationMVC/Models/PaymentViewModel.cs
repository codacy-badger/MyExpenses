﻿/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.WebApplicationMVC.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.ComponentModel;

    using MyExpenses.Application.Dtos;
    using MyExpenses.Application.ViewModels;

    public class PaymentIndexViewModel
    {
        public List<PaymentViewModel> Payments { get; set; }

        public PaymentViewModel Payment { get; set; }

        [DisplayName("Month")]
        public int Month { get; set; }

        [DisplayName("Year")]
        public int Year { get; set; }
    }
}