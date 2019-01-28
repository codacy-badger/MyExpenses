using System.Collections.Generic;

namespace lfmachadodasilva.MyExpenses.WebApplication.Models
{
    public interface IViewModels<T> where T : IViewModel
    {
        T Empty { get; }

        IEnumerable<T> Items { get; set; }
    }
}