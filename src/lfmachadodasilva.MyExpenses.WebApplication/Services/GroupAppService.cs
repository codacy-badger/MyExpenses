﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lfmachadodasilva.MyExpenses.Core.Models.Dtos;
using lfmachadodasilva.MyExpenses.Core.Services;
using lfmachadodasilva.MyExpenses.WebApplication.Models;

namespace lfmachadodasilva.MyExpenses.WebApplication.Services
{
    public class GroupAppService : IGroupAppService
    {
        private readonly IGroupService _groupService;
        private readonly IUserAppService _userAppService;
        private readonly IMapper _mapper;

        public GroupAppService(
            IGroupService groupService,
            IUserAppService userAppService,
            IMapper mapper)
        {
            _groupService = groupService;
            _userAppService = userAppService;
            _mapper = mapper;
        }

        public Task<GroupsViewModel> GetAllAsync()
        {
            return Task.Run(
                () => 
                {
                    var groupsDto = _groupService.GetAll();
                    var groupViewModel = _mapper.Map<IEnumerable<GroupDto>, IEnumerable<GroupViewModel>>(groupsDto);

                    // fill user names
                    foreach (var vm in groupViewModel)
                    {
                        vm.Users = _userAppService.GetAll(vm.Users.Select(x => x.Id));
                    }

                    return new GroupsViewModel { Items = groupViewModel };
                });
        }

        public Task<GroupViewModel> GetEmpty()
        {
            return Task.Run(
                () =>
                {
                    var viewModel = new GroupViewModel(_userAppService.GetAll(), new List<Guid>());
                    return viewModel;
                });
        }

        public async Task<GroupViewModel> AddAsync(GroupViewModel groupViewModel)
        {
            groupViewModel.Users = _userAppService.GetAll(groupViewModel.SelectedUsersId);

            var groupDto = _mapper.Map<GroupViewModel, GroupDto>(groupViewModel);
            return _mapper.Map<GroupDto, GroupViewModel>(await _groupService.AddAsync(groupDto));
        }

        public GroupViewModel GetByIdAsync(Guid groupId)
        {
            return new GroupViewModel();
        }

        public GroupViewModel UpdateAsync(GroupViewModel groupViewModel)
        {
            return new GroupViewModel();
        }

        public GroupViewModel RemoveAsync(Guid groupId)
        {
            return new GroupViewModel();
        }
    }
}
