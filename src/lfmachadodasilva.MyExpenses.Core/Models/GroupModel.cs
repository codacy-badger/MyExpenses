using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace lfmachadodasilva.MyExpenses.Core.Models
{
    [Table(ModelUtility.GroupTable)]
    public class GroupModel : ModelBase
    {
        [Required]
        public string Name { get; set; }

        public IEnumerable<UserGroupModel> Users { get; set; }

        //[NotMapped]
        //public IEnumerable<UserModel> GetUsers => Users.Select(x => x.User);
    }
}
