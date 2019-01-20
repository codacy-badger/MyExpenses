using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using lfmachadodasilva.MyExpenses.Core;
using lfmachadodasilva.MyExpenses.Core.Models.Dtos;
using lfmachadodasilva.MyExpenses.Core.Services;
using lfmachadodasilva.MyExpenses.WebApplication;
using lfmachadodasilva.MyExpenses.WebApplication.Models.ViewModels;
using lfmachadodasilva.MyExpenses.WebApplication.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace lfmachadodasilva.MyExpenses.UnitTest.Services
{
    [TestClass]
    public class GroupWebServiceTests
    {
        private readonly IGroupWebService _groupWebService;
        private readonly Mock<IGroupService> _groupService;

        public GroupWebServiceTests()
        {
            _groupService = new Mock<IGroupService>();
            var mapper = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddProfile<MyExpensesProfile>();
                    cfg.AddProfile<WebAppMyExpensesProfile>();
                }
                ).CreateMapper();

            _groupWebService = new GroupWebService(_groupService.Object, mapper);
        }

        [TestMethod]
        public async Task GroupWebService_GetAllByUser_Empty()
        {
            // arrange
            Guid userId = Guid.NewGuid();
            _groupService
                .Setup(x => x.GetAllByUser(userId))
                .Returns(new List<GroupDto>());

            // act
            var actual = await _groupWebService.GetAllByUserAsync(userId);

            // assert
            var expected = new GroupsViewModel();
            actual.Should().Equals(expected);
        }

        [TestMethod]
        public async Task GroupWebService_GetAllByUser_ShouldReturnViewModel()
        {
            // arrange
            var userId = Guid.NewGuid();
            var userName = "UserName";
            var groupId = Guid.NewGuid();
            var groupName = "GroupName";
            var groups = new List<GroupDto>
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
            _groupService
                .Setup(x => x.GetAllByUser(It.IsAny<Guid>()))
                .Returns(groups);

            // act
            var actual = await _groupWebService.GetAllByUserAsync(userId);

            // assert
            var expected = new GroupsViewModel
            {
                Items = new List<GroupViewModel>
                {
                    new GroupViewModel
                    {
                        Id = groupId,
                        Name = groupName,
                        Users = new List<UserViewModel>
                        {
                            new UserViewModel
                            {
                                Id = userId,
                                Name = userName
                            }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task GroupWebService_GetByIdAsync_WithInvalidId_ShouldBeNull()
        {
            // arrange
            Guid groupId = Guid.NewGuid();
            _groupService
                .Setup(x => x.GetByIdAsync(groupId))
                .ReturnsAsync(default(GroupDto));

            // act
            var actual = await _groupWebService.GetByIdAsync(groupId);

            // assert
            actual.Should().BeNull();
        }

        [TestMethod]
        public async Task GroupWebService_GetByIdAsync_WithValidId_ShouldReturnViewModel()
        {
            // arrange
            Guid groupId = Guid.NewGuid();
            var groupName = "GroupName";
            var user1Id = Guid.NewGuid();
            var user1Name = "UserName1";
            var user2Id = Guid.NewGuid();
            var user2Name = "UserName2";

            _groupService
                .Setup(x => x.GetByIdAsync(groupId))
                .ReturnsAsync(new GroupDto
                {
                    Id = groupId,
                    Name = groupName,
                    Users = new List<UserDto>
                    {
                        new UserDto
                        {
                            Id = user1Id,
                            Name = user1Name
                        }
                    }
                });

            // act
            var actual = await _groupWebService.GetByIdAsync(groupId);

            // assert
            var expected = new GroupViewModel
            {
                Id = groupId,
                Name = groupName,
                Users = new List<UserViewModel>
                {
                    new UserViewModel
                    {
                        Id = user1Id,
                        Name = user1Name
                    }
                },

                AllUsers = new List<UserViewModel>
                {
                    new UserViewModel
                    {
                        Id = user1Id,
                        Name = user1Name
                    },
                    new UserViewModel
                    {
                        Id = user2Id,
                        Name = user2Name
                    }
                }
            };
            actual.Should().Equals(expected);
        }
    }
}
