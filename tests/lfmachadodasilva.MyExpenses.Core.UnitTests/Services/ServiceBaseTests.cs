using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using AutoMapper;
using FluentAssertions;
using lfmachadodasilva.MyExpenses.Core.Models;
using lfmachadodasilva.MyExpenses.Core.Models.Dtos;
using lfmachadodasilva.MyExpenses.Core.Repositories;
using lfmachadodasilva.MyExpenses.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace lfmachadodasilva.MyExpenses.Core.UnitTest.Services
{
    public class ServiceBaseTests<TDto> where TDto : IDto
    {
        protected IService<TDto> Service;
        protected Mock<IUnitOfWork> UnitOfWorkMock;
        protected IMapper Mapper;

        [TestInitialize]
        public void ServiceBaseTests_TestInitialize()
        {
            UnitOfWorkMock = new Mock<IUnitOfWork>();
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<MyExpensesProfile>()).CreateMapper();
        }

        [TestCleanup]
        public void ServiceBaseTests_TestCleanup()
        {
            UnitOfWorkMock = null;
            Mapper = null;
        }

        [TestMethod]
        public void ServiceBase_GetAll_ShouldReturnData()
        {
            // arrange

            // act
            var actual = Service.GetAll();

            // assert
            actual.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task ServiceBase_GetByIdAsync_WithInvalidId_ShouldReturnNull()
        {
            // arrange

            // act
            var actual = await Service.GetByIdAsync(Guid.NewGuid());

            // assert
            actual.Should().BeNull();
        }

        [TestMethod]
        public async Task ServiceBase_GetByIdAsync_WithValidId_ShouldReturnData()
        {
            // arrange
            var id = Service.GetAll().Select(x => x.Id).FirstOrDefault();

            // act
            var actual = await Service.GetByIdAsync(id);

            // assert
            actual
                .Should().NotBeNull();
            actual.Id.Should().Be(id);
        }
    }

    [TestClass]
    public class ExpenseServiceTests : ServiceBaseTests<ExpenseDto>
    {
        private Mock<IExpenseRepository> _expenseRepositoryMock;

        private Fixture _fixture;

        [TestInitialize]
        public void ExpenseServiceTests_TestInitialize()
        {
            _fixture = new Fixture();

            // client has a circular reference from AutoFixture point of view
            _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            _expenseRepositoryMock = new Mock<IExpenseRepository>();

            var objs = _fixture.CreateMany<ExpenseModel>();

            _expenseRepositoryMock
                .Setup(x => x.GetAll())
                .Returns(objs);

            foreach (var obj in objs)
            {
                _expenseRepositoryMock
                    .Setup(x => x.GetByIdAsync(obj.Id))
                    .ReturnsAsync(obj);
            }
            
            Service = new ExpenseService(_expenseRepositoryMock.Object, UnitOfWorkMock.Object, Mapper);
        }

        [TestCleanup]
        public void ExpenseServiceTests_TestCleanup()
        {
            _expenseRepositoryMock = null;
        }
    }
}
