using System;
using AutoFixture;

namespace ProjectY.Backend.Tests.IntegrationTests.DiTestBase
{
    public class DiCustomization : ICustomization
    {
        private readonly IServiceProvider _provider;

        public DiCustomization(IServiceProvider provider)
        {
            _provider = provider;
        }

        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new DiFixtureSpecimenBuilder(_provider));
        }
    }
}
