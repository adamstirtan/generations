using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using Generations.Data.Contracts;
using Generations.ObjectModel;
using Generations.Tests.Helpers;

namespace Generations.Services.Tests
{
    [TestClass]
    public class PersonServiceTests
    {
        private static readonly int EntityCount = 150;

        private readonly List<Person> _dataSet;

        public PersonServiceTests()
        {
            _dataSet = new List<Person>();

            for (var i = 0; i < EntityCount; i++)
            {
                _dataSet.Add(ModelFactory.NewPerson());
            }
        }

        [TestMethod]
        public async Task GetAll()
        {
            var mock = new Mock<IPersonService>();

            mock
                .Setup(x => x.AllAsync(
                    It.IsAny<string>(),
                    It.IsAny<bool>()))
                .Returns(Task.FromResult(_dataSet.OrderBy(x => x.Id).AsEnumerable()));

            var service = mock.Object;

            var entities = await service.AllAsync("id", true);

            Assert.AreEqual(EntityCount, entities.Count());
        }

        [TestMethod]
        public async Task GetAllWithPaging()
        {
            var mock = new Mock<IPersonService>();

            mock
                .Setup(x => x.AllAsync(
                    It.IsAny<string>(),
                    It.IsAny<bool>(),
                    It.IsAny<int>(),
                    It.IsAny<int>()))
                .Returns(Task.FromResult(_dataSet.Skip(2).Take(20).AsEnumerable()));

            var service = mock.Object;

            var entities = await service.AllAsync("id", true, 2, 20);

            Assert.AreEqual(20, entities.Count());
        }

        [TestMethod]
        public async Task Count()
        {
            var mock = new Mock<IPersonService>();

            mock
                .Setup(x => x.CountAsync())
                .Returns(Task.FromResult(EntityCount));

            var service = mock.Object;

            var count = await service.CountAsync();

            Assert.AreEqual(EntityCount, count);
        }
    }
}