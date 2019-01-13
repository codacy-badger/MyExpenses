using System;
using System.Collections.Generic;

namespace lfmachadodasilva.MyExpenses.Core.Models.Dtos
{
    public class GroupDto : DtoBase
    {
        public string Name { get; set; }

        public IEnumerable<Guid> Users { get; set; }
    }
}
