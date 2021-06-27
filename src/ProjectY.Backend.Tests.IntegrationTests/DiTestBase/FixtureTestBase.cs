using AutoFixture;
using AutoFixture.AutoMoq;

namespace ProjectY.Backend.Tests.IntegrationTests.DiTestBase
{
    public abstract class FixtureTestBase
    {
        protected Fixture Fixture;

        protected FixtureTestBase()
        {
            Fixture = new Fixture();
            Fixture.Customize(new AutoMoqCustomization()
            {
                ConfigureMembers = true
            });
        }
    }

}
