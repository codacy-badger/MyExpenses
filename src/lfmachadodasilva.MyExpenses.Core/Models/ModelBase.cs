using System;
using System.ComponentModel.DataAnnotations;

namespace lfmachadodasilva.MyExpenses.Core.Models
{
    public abstract class ModelBase : IModel
    {
        [Key]
        public Guid Id { get; set; }
    }
}
