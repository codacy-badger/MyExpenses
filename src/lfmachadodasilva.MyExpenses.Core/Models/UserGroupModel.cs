using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace lfmachadodasilva.MyExpenses.Core.Models
{
    [Table(ModelUtility.UserGroupTable)]
    internal class UserGroupModel : ModelBase
    {
        public GroupModel Group { get; set; }

        public Guid UserId { get; set; }
    }
}
