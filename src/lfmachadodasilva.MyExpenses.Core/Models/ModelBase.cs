using System;
    
namespace lfmachadodasilva.MyExpenses.Core.Models
{
    public abstract class ModelBase : IModel
    {
        public Guid Id { get; set; }
    }
}
