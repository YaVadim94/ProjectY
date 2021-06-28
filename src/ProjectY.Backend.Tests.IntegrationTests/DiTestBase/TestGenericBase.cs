using Microsoft.Extensions.DependencyInjection;
using ProjectY.Backend.Data;

namespace ProjectY.Backend.Tests.IntegrationTests.DiTestBase
{
    public abstract class TestGenericBase<TService, TImpl> : TestBase where TService : class
        where TImpl : class, TService
    {
        protected TService Sut;
        protected DataContext Context;

        protected TestGenericBase()
        {
            Register<TService, TImpl>();
            Sut = GetServiceProvider().GetRequiredService<TService>();
            Context = GetDbContext().Result;
        }
    }
}
