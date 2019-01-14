﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lfmachadodasilva.MyExpenses.Core.Models
{
    [Table(ModelUtility.GroupTable)]
    internal class GroupModel : ModelBase
    {
        public string Name { get; set; }

        public IEnumerable<UserGroupModel> Users { get; set; }
    }
}
