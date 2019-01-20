using System;
using System.Collections.Generic;
using AutoMapper;
using FluentAssertions;
using lfmachadodasilva.MyExpenses.Core;
using lfmachadodasilva.MyExpenses.Core.Models;
using lfmachadodasilva.MyExpenses.Core.Models.Dtos;
using lfmachadodasilva.MyExpenses.Core.Repositories;
using lfmachadodasilva.MyExpenses.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace lfmachadodasilva.MyExpenses.UnitTest.Services
{
    [TestClass]
    public class GroupServiceTests
    {
        private readonly IGroupService _groupService;

        private readonly Mock<IGroupRepository> _groupRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public GroupServiceTests()
        {
            _groupRepositoryMock = new Mock<IGroupRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<MyExpensesProfile>()).CreateMapper();

            _groupService = new GroupService(
                _groupRepositoryMock.Object,
                _unitOfWorkMock.Object,
                mapper);
        }

        [TestMethod]
        public void GroupService_GetAll_Empty()
        {
            // arrange
            var userId = Guid.NewGuid();
            _groupRepositoryMock
                .Setup(x => x.GetAll(y => y.Users))
                .Returns(new List<GroupModel>());

            // act
            var actual = _groupService.GetAllByUser(userId);

            // assert
            actual.Should().BeEmpty();
        }

        [TestMethod]
        public void GroupService_GetAll_ShouldReturn()
        {
            // arrange
            var userId = Guid.NewGuid();
            var userName = "UserName";
            var groupId = Guid.NewGuid();
            var groupName = "GroupName";

            var group = new GroupModel
            {
                Id = groupId,
                Name = groupName,
            };

            var userGroup = new UserGroupModel
            {
                Group = group,
                User = new UserModel
                {
                    Id = userId.ToString(),
                    UserName = userName
                }
            };

            group.Users = new List<UserGroupModel> { userGroup };

            _groupRepositoryMock
                .Setup(x => x.GetAll(y => y.Users))
                .Returns(new List<GroupModel> { group });

            // act
            var actual = _groupService.GetAllByUser(userId);

            // assert
            var expected = new List<GroupDto>
            {
                new GroupDto
                {
                    Id = groupId,
                    Name = groupName,
                    Users = new List<UserDto>
                    {
                        new UserDto
                        {
                            Id = userId,
                            Name = userName
                        }
                    }
                }
            };
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
