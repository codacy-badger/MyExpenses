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
        protected IService<TDto> _service;

        [TestMethod]
        public void ServiceBase_GetAll_ShouldReturnData()
        {
            // arrange

            // act
            var actual = _service.GetAll();

            // assert
            actual.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task ServiceBase_GetByIdAsync_WithInvalidId_ShouldReturnNull()
        {
            // arrange

            // act
            var actual = await _service.GetByIdAsync(Guid.NewGuid());

            // assert
            actual.Should().BeNull();
        }

        [TestMethod]
        public async Task ServiceBase_GetByIdAsync_WithValidId_ShouldReturnData()
        {
            // arrange
            var id = _service.GetAll().Select(x => x.Id).FirstOrDefault();

            // act
            var actual = await _service.GetByIdAsync(id);

            // assert
            actual
                .Should().NotBeNull().Should();
            actual.Id.Should().Be(id);
        }
    }

    [TestClass]
    public class ExpenseServiceTests : ServiceBaseTests<ExpenseDto>
    {
        private Mock<IExpenseRepository> _expenseRepositoryMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private IMapper _mapper;

        private Fixture _fixture;

        [TestInitialize]
        public void TestInitialize()
        {
            _fixture = new Fixture();

            // client has a circular reference from AutoFixture point of view
            _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            _expenseRepositoryMock = new Mock<IExpenseRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<MyExpensesProfile>()).CreateMapper();

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
            
            _service = new ExpenseService(_expenseRepositoryMock.Object, _unitOfWorkMock.Object, _mapper);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _expenseRepositoryMock = null;
            _unitOfWorkMock = null;
            _mapper = null;
        }
    }
}
