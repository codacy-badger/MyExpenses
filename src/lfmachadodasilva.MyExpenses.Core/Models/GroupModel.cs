using System.Collections.Generic;

namespace lfmachadodasilva.MyExpenses.Core.Models
{
    public class GroupModel : ModelBase
    {
        public string Name { get; set; }

        public IEnumerable<UserGroupModel> Users { get; set; }
    }
}
