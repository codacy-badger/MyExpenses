﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using lfmachadodasilva.MyExpenses.Core.Models;
using lfmachadodasilva.MyExpenses.Core.Models.Dtos;
using lfmachadodasilva.MyExpenses.Core.Repositories;

namespace lfmachadodasilva.MyExpenses.Core.Services
{
    internal class GroupService : ServiceBase<GroupDto, GroupModel>, IGroupService
    {
        private readonly IGroupRepository _repository;
        private readonly IMapper _mapper;

        public GroupService(IGroupRepository repository, IUnitOfWork unitOfWork, IMapper mapper) :
            base(repository, unitOfWork, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<GroupDto> GetAll(Guid userId)
        {
            var models = _repository
                .GetAll(x => x.Users)
                .Where(x => x.Users
                    .Any(y => y.UserId.Equals(userId)));
            return _mapper.Map<IEnumerable<GroupModel>, IEnumerable<GroupDto>>(models);
        }
    }
}
