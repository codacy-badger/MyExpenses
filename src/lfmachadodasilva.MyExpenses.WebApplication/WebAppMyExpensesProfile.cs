using AutoMapper;
using lfmachadodasilva.MyExpenses.Core.Models.Dtos;
using lfmachadodasilva.MyExpenses.WebApplication.Models.ViewModels;

namespace lfmachadodasilva.MyExpenses.WebApplication
{
    public class WebAppMyExpensesProfile : Profile
    {
        public WebAppMyExpensesProfile()
        {
            CreateMap<GroupViewModel, GroupDto>().ReverseMap();
        }
    }
}
