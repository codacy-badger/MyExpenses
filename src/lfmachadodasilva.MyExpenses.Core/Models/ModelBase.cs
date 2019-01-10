using System;
    
namespace lfmachadodasilva.MyExpenses.Core.Models
{
    internal abstract class ModelBase : IModel
    {
        public Guid Id { get; set; }
    }
}
