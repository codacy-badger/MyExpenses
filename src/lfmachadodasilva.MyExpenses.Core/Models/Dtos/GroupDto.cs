using System.Collections.Generic;

namespace lfmachadodasilva.MyExpenses.Core.Models.Dtos
{
    public class GroupDto : DtoBase
    {
        public string Name { get; set; }

        public IEnumerable<UserDto> Users { get; set; }
    }
}
