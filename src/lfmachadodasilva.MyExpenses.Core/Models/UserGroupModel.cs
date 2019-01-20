using System.ComponentModel.DataAnnotations.Schema;

namespace lfmachadodasilva.MyExpenses.Core.Models
{
    [Table(ModelUtility.UserGroupTable)]
    public class UserGroupModel : ModelBase
    {
        public GroupModel Group { get; set; }

        public UserModel User { get; set; }
    }
}
