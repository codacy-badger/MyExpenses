using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    [TestClass]
    public class LabelServiceTests
    {
        private readonly ILabelService _labelService;
        private readonly Mock<ILabelRepository> _labelRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly IMapper _mapper;

        public LabelServiceTests()
        {
            _labelRepositoryMock = new Mock<ILabelRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();

            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<MyExpensesProfile>()).CreateMapper();

            _labelService = new LabelService(
                _labelRepositoryMock.Object,
                _unitOfWorkMock.Object,
                _mapper);
        }

        [TestMethod]
        public async Task GetAllByGroupMonthYear_ShouldReturnData()
        {
            // arrange
            var groupId = Guid.NewGuid();
            var month = 5;
            var year = 2000;

            _labelRepositoryMock
                .Setup(x => x.GetAll(y => y.Expenses, y => y.Group))
                .Returns(new List<LabelModel>
                {
                    new LabelModel
                    {
                        Id = Guid.NewGuid(),
                        Group = new GroupModel { Id = groupId },
                        Expenses = new List<ExpenseModel>
                        {
                            new ExpenseModel
                            {
                                Id = Guid.NewGuid(),
                                Date = new DateTime(year, month, 1)
                            },
                            new ExpenseModel
                            {
                                Id = Guid.NewGuid(),
                                Date = new DateTime(year, month + 1, 2)
                            }
                        }
                    },
                    new LabelModel
                    {
                        Id = Guid.NewGuid(),
                        Group = new GroupModel { Id = groupId },
                        Expenses = new List<ExpenseModel>
                        {
                            new ExpenseModel
                            {
                                Id = Guid.NewGuid(),
                                Date = new DateTime(year, month - 1, 3)
                            }
                        }
                    },
                    new LabelModel
                    {
                        Id = Guid.NewGuid(),
                        Group = new GroupModel { Id = Guid.NewGuid() }
                    }
                });

            // act
            var actual = await _labelService.Get(groupId, month, year);

            // assert
            actual
                .Should().NotBeNullOrEmpty();
            actual
                .Should().OnlyContain(
                    x => x.Group.Id.Equals(groupId), 
                    $"Should not have any label with group different from {groupId}.");
            actual
                .Should().OnlyContain(
                    l => l.Expenses.All(e => e.Date.Month.Equals(month) && e.Date.Year.Equals(year)),
                    $"Should not have any expenses out of the range {month}/{year}.");
        }
    }
}
