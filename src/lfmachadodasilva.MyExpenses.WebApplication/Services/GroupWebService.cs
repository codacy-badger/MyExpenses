using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using lfmachadodasilva.MyExpenses.Core.Models.Dtos;
using lfmachadodasilva.MyExpenses.Core.Services;
using lfmachadodasilva.MyExpenses.WebApplication.Models.ViewModels;

namespace lfmachadodasilva.MyExpenses.WebApplication.Services
{
    public interface IGroupWebService
    {
        Task<GroupsViewModel> GetAllByUser(Guid userId);
    }

    public class GroupWebService : IGroupWebService
    {
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;

        public GroupWebService(IGroupService groupService, IMapper mapper)
        {
            _groupService = groupService;
            _mapper = mapper;
        }

        public Task<GroupsViewModel> GetAllByUser(Guid userId)
        {
            return Task.Run(() => {

                var dtos = _groupService.GetAll(userId);
                var groups = new GroupsViewModel
                {
                    Items = _mapper.Map<IEnumerable<GroupDto>, IEnumerable<GroupViewModel>>(dtos)
                };

                return groups;
            });
        }
    }
}
