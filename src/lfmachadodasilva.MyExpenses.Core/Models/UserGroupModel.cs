using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace lfmachadodasilva.MyExpenses.Core.Models
{
    [Table(ModelUtility.UserGroupTable)]
    public class UserGroupModel : ModelBase
    {
        public Guid GroupId { get; set; }

        public Guid UserId { get; set; }
    }
}
