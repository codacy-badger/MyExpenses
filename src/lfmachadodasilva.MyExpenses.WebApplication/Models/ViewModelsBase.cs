using System.Collections.Generic;

namespace lfmachadodasilva.MyExpenses.WebApplication.Models
{
    public class ViewModelsBase<T> : IViewModels<T> where T : IViewModel
    {
        public T Empty => default(T);

        public IEnumerable<T> Items { get; set; }
    }
}