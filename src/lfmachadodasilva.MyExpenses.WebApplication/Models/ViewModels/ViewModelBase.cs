using System;
using System.Collections.Generic;

namespace lfmachadodasilva.MyExpenses.WebApplication.Models.ViewModels
{
    public class ViewModelBase<TViewModel> where TViewModel : IViewModel
    {
        public virtual TViewModel Empty { get; } = default(TViewModel);

        public IEnumerable<TViewModel> Items { get; set; }
    }

    public class ViewModelBase : IViewModel
    {
        public Guid Id { get; set; }
    }
}
