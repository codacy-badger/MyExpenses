﻿using AutoMapper;
using lfmachadodasilva.MyExpenses.Core.Models;
using lfmachadodasilva.MyExpenses.Core.Models.Dtos;

namespace lfmachadodasilva.MyExpenses.Core
{
    public class MyExpensesProfile : Profile
    {
        public MyExpensesProfile()
        {
            CreateMap<ExpenseModel, ExpenseDto>().ReverseMap();
            CreateMap<GroupModel, GroupDto>().ReverseMap();
            CreateMap<LabelModel, LabelDto>().ReverseMap();
            CreateMap<PaymentModel, PaymentDto>().ReverseMap();
            //CreateMap<UserModel, UserDto>().ReverseMap();
        }
    }
}