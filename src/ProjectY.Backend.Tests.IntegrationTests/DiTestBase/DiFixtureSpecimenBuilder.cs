using System;
using AutoFixture.Kernel;

namespace ProjectY.Backend.Tests.IntegrationTests.DiTestBase
{
    public class DiFixtureSpecimenBuilder : ISpecimenBuilder
    {
        private readonly IServiceProvider _provider;

        public DiFixtureSpecimenBuilder(IServiceProvider provider)
        {
            _provider = provider;
        }

        public object Create(object request, ISpecimenContext context)
        {
            var noSpecimen = new NoSpecimen();

            if (!(request is SeededRequest seed)
                || !(seed.Request is Type type))
                return noSpecimen;

            return _provider.GetService(type) ?? noSpecimen;
        }
    }

}
