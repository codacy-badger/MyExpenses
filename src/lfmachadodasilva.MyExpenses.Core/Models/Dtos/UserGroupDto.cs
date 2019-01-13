using System;

namespace lfmachadodasilva.MyExpenses.Core.Models.Dtos
{
    public class UserGroupDto : DtoBase
    {
        public GroupDto Group { get; set; }

        public Guid User { get; set; }
    }
}
