﻿using System;
using System.Collections.Generic;

namespace lfmachadodasilva.MyExpenses.Core.Models.Dtos
{
    public class PaymentDto : DtoBase
    {
        public string Name { get; set; }

        public IEnumerable<ExpenseDto> Expenses { get; set; }

        public GroupDto Group { get; set; }
    }
}
