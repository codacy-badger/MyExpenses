using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lfmachadodasilva.MyExpenses.Core.Models;
using lfmachadodasilva.MyExpenses.Core.Models.Dtos;
using lfmachadodasilva.MyExpenses.Core.Repositories;

namespace lfmachadodasilva.MyExpenses.Core.Services
{
    public class GroupService : ServiceBase<GroupDto, GroupModel>, IGroupService
    {
        private readonly IGroupRepository _repository;
        //private readonly IExpenseService _expenseService;
        //private readonly ILabelService _labelService;
        //private readonly IPaymentService _paymentService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GroupService(
            IGroupRepository repository,
            //IExpenseService expenseService,
            //ILabelService labelService,
            //IPaymentService paymentService,
            IUnitOfWork unitOfWork,
            IMapper mapper) :
            base(repository, unitOfWork, mapper)
        {
            _repository = repository;
            //_expenseService = expenseService;
            //_labelService = labelService;
            //_paymentService = paymentService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<GroupDto> GetAllByUser(Guid userId)
        {
            // get all groups that have userId
            var models = _repository
                .GetAll(x => x.Users)
                .Where(x => x.Users.Any(y => y.User.Id.Equals(userId)));

            return _mapper.Map<IEnumerable<GroupModel>, IEnumerable<GroupDto>>(models);
        }

        public override async Task<GroupDto> AddAsync(GroupDto dto)
        {
            var model = _mapper.Map<GroupDto, GroupModel>(dto);
            model.Users = dto.Users.Select(x => new UserGroupModel { Id = x.Id, Group = model });

            return _mapper.Map<GroupModel, GroupDto>(await _repository.AddAsync(model));
        }

        public override async Task<GroupDto> GetByIdAsync(Guid userId)
        {
            var model = await _repository.GetByIdAsync(userId, x => x.Users);
            var dto = _mapper.Map<GroupModel, GroupDto>(model);
            return dto;
        }

        public override async Task<bool> RemoveAsync(Guid groupId)
        {
            _unitOfWork.BeginTransaction();

            if (!await _repository.RemoveAsync(groupId))
            {
                return false;
            }

            // TODO lfmachadodasilva - remove all expenses may belong to this group

            // TODO lfmachadodasilva - remove all labels may belong to this group

            // TODO lfmachadodasilva - remove all payments may belong to this group

            var amount = await _unitOfWork.CommitAsync();

            return amount.Equals(1);
        }
    }
}
