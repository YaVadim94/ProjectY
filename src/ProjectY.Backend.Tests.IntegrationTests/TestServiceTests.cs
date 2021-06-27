using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Kernel;
using Microsoft.EntityFrameworkCore;
using ProjectY.Backend.Application.Logic.Models.Home;
using ProjectY.Backend.Application.Logic.Services;
using ProjectY.Backend.Data;
using Xunit;

namespace ProjectY.Backend.Tests.IntegrationTests
{
    public class TestServiceTests
    {
        private DataContext _context;

        [Fact]
        public async Task Test()
        {
            var fixture = new Fixture();
            var sf = new SpecimenFactory<DataContext>(CreateDbContext);
            fixture.Customize(new AutoMoqCustomization() { ConfigureMembers = true });
            fixture.Customize<DataContext>(composer => composer.FromFactory(sf));

            _context = fixture.Create<DataContext>();
            fixture.Inject<DataContext>(_context);

            var sut = fixture.Create<TestService>();
            var homeDto = fixture.Create<CreateHomeDto>();

            var result = await sut.CreateAsync(homeDto);
            var q = _context.Homes;
        }

        private DataContext CreateDbContext()
        {
            var dbContextOptions = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            return new DataContext(dbContextOptions);
        }
    }
}
