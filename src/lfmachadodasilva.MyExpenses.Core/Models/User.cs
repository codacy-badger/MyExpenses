using System;
using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.AspNetCore.Identity;

namespace lfmachadodasilva.MyExpenses.Core.Models
{
    public class UserModel : ModelBase// : IdentityUser
    {
        public string Name { get; set; }
        //[NotMapped]
        //public Guid IdGuid
        //{
        //    get => Guid.Parse(Id);
        //    set => Id = this.ToString();
        //}
    }
}
