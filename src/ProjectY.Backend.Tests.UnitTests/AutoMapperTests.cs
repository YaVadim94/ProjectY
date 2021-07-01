using System.Reflection;
using AutoMapper;
using ProjectY.Backend.Application.Logic.Profiles;
using Xunit;

namespace ProjectY.Backend.Tests.UnitTests
{
    public class AutoMapperTests
    {
        [Fact]
        public void Automapper_Profiles_Test()
        {
            var type = typeof(ShoesDtoProfile);
            var config = new MapperConfiguration(cfg =>
                cfg.AddMaps(Assembly.GetAssembly(type)));

            config.AssertConfigurationIsValid();
        }
    }
}
