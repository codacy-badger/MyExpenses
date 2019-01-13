﻿using System.Collections.Generic;

namespace lfmachadodasilva.MyExpenses.Core.Models
{
    public class LabelModel : ModelBase
    {
        public string Name { get; set; }

        public IEnumerable<ExpenseModel> Expenses { get; set; }

        public GroupModel Group { get; set; }
    }
}
