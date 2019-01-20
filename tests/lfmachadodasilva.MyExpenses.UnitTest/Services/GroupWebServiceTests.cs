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
                .Setup(x => x.GetAll(userId))
                .Returns(new List<GroupDto>());

            // act
            var actual = await _groupWebService.GetAllByUser(userId);

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
                .Setup(x => x.GetAll(It.IsAny<Guid>()))
                .Returns(groups);

            // act
            var actual = await _groupWebService.GetAllByUser(userId);

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
    }
}
