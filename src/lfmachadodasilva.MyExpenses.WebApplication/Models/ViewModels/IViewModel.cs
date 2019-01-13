using System;
using System.ComponentModel.DataAnnotations;

namespace lfmachadodasilva.MyExpenses.WebApplication.Models.ViewModels
{
    public interface IViewModel
    {
        [Key]
        Guid Id { get; set; }
    }
}
