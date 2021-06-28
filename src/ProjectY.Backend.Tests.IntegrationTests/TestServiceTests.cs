using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectY.Backend.Application.Logic.Interfaces;
using ProjectY.Backend.Application.Logic.Models.Home;
using ProjectY.Backend.Application.Logic.Services;
using ProjectY.Backend.Tests.IntegrationTests.DiTestBase;
using Xunit;

namespace ProjectY.Backend.Tests.IntegrationTests
{
    public class TestServiceTests : TestGenericBase<ITestService, TestService>
    {
        [Fact]
        public async Task Test1()
        {
            // Arrange
            var createHomeDto = new CreateHomeDto { Number = 4 };

            // Act
            await Sut.CreateAsync(createHomeDto);
            var result = Context.Homes;

            // Arrange
            Assert.True(await result.CountAsync() == 1);
        }
    }
}
