using System;

namespace lfmachadodasilva.MyExpenses.Core.Models
{
    public class UserGroupModel : ModelBase
    {
        public GroupModel Group { get; set; }

        public Guid User { get; set; }
    }
}
