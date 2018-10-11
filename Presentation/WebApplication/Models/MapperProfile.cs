/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace WebApplication.Models
{
    using AutoMapper;

    using MyExpenses.Application.Dtos;

    using WebApplication.Models.Groups;

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<GroupDto, GroupViewModel>().ReverseMap();
        }
    }
}
