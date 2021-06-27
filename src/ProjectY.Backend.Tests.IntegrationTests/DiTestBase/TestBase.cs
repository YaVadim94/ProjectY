using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoFixture;
using AutoMapper.EquivalencyExpression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using ProjectY.Backend.Data;

namespace ProjectY.Backend.Tests.IntegrationTests.DiTestBase
{
    public abstract class TestBase : FixtureTestBase, IDisposable
    {
        protected IServiceCollection ServiceCollection;

        private IServiceProvider _provider;

        private DataContext _dbContext;

        protected TestBase()
        {
            _provider = null;
            _dbContext = null;

            ServiceCollection = new ServiceCollection();

            UseInMemoryDb();
            AddAutoMapper();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
            _dbContext = null;
        }

        public void AddAutoMapper()
        {
            var assemblies = new[]
            {
                Assembly.LoadFrom(Path.Combine(AppContext.BaseDirectory, "ProjectY.Backend.Web.Api.dll")),
                Assembly.LoadFrom(Path.Combine(AppContext.BaseDirectory, "ProjectY.Backend.Application.Logic.dll")),
            };

            ServiceCollection.AddAutoMapper(cfg => cfg.AddCollectionMappers(), assemblies);
        }

        protected void Register<TService, TImpl>(ServiceLifetime lifetime = ServiceLifetime.Transient)
            where TService : class
            where TImpl : class, TService
        {
            var desc = new ServiceDescriptor(typeof(TService), typeof(TImpl), lifetime);
            AddOrReplace(desc);
        }

        /// <summary>
        ///    Регистрирует экзепляр сервиса в DI контейнере 
        /// </summary>
        protected void Register<TService>(ServiceLifetime lifetime = ServiceLifetime.Transient)
            where TService : class
        {
            var desc = new ServiceDescriptor(typeof(TService), typeof(TService), lifetime);
            AddOrReplace(desc);
        }

        /// <summary>
        ///    Регистрирует экзепляр сервиса в DI контейнере 
        /// </summary>
        protected void Register<TService>(TService instance)
            where TService : class
        {
            var desc = new ServiceDescriptor(typeof(TService), instance);
            AddOrReplace(desc);
        }

        /// <summary>
        ///    Регистрирует mock сервис в DI контейнере с использованием AutoFixtures 
        /// </summary>
        protected void RegisterFixture<TService>(Action<Mock<TService>> setup)
            where TService : class
        {
            var mock = Fixture.Freeze<Mock<TService>>();
            setup(mock);
            RegisterMock(mock);
        }

        /// <summary>
        ///    Регистрирует экземпляр mock сервиса в DI контейнере 
        /// </summary>
        protected void RegisterMock<TService>(Mock<TService> instance)
            where TService : class
        {
            var desc = new ServiceDescriptor(typeof(TService), instance.Object);
            AddOrReplace(desc);
        }

        /// <summary>
        ///    Регистрирует mock сервис в DI контейнере 
        /// </summary>
        protected void RegisterMock<TService>(Action<Mock<TService>> setupCallback,
            ServiceLifetime lifetime = ServiceLifetime.Transient)
            where TService : class
        {
            var desc = new ServiceDescriptor(typeof(TService), provider =>
            {
                var mock = new Mock<TService>();
                setupCallback?.Invoke(mock);
                return mock.Object;
            }, lifetime);

            AddOrReplace(desc);
        }

        /// <summary>
        /// Производит действией в транзакции
        /// </summary>
        protected async Task InTransaction(Func<Task> func)
        {
            var dbContext = await GetDbContext();
            await func();
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Получает экземпляр DI контейнера
        /// </summary>
        protected IServiceProvider GetServiceProvider()
        {
            if (_provider != null)
                return _provider;

            _provider = ServiceCollection.BuildServiceProvider();
            Fixture.Customize(new DiCustomization(_provider));
            return _provider;
        }

        /// <summary>
        /// Получает контекст БД
        /// </summary>
        protected async Task<DataContext> GetDbContext()
        {
            if (_dbContext != null)
                return _dbContext;

            _dbContext = ServiceProviderServiceExtensions
                .GetRequiredService<DataContext>(GetServiceProvider());

            await InitDbContext(_dbContext);

            if (_dbContext.ChangeTracker.HasChanges())
                await _dbContext.SaveChangesAsync();

            return _dbContext;
        }

        /// <summary>
        /// Инициализирует контекст БД и делает сидинг в него
        /// </summary>
        protected virtual async Task InitDbContext(DataContext dbContext)
        {
            await _dbContext.Database.EnsureDeletedAsync();
            await _dbContext.Database.EnsureCreatedAsync();
        }


        /// <summary>
        /// Использовать InMemory БД
        /// </summary>
        protected void UseInMemoryDb()
        {
            ServiceCollection.AddEntityFrameworkInMemoryDatabase();
            ServiceCollection.AddDbContext<DataContext>((provider, builder) =>
            {
                builder
                    .UseInMemoryDatabase("TestDb")
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging();
            });
        }


        private void AddOrReplace(ServiceDescriptor desc)
        {
            if (_provider != null)
                throw new Exception("Service provider already initialized");

            var oldDesc = ServiceCollection.FirstOrDefault(x => x.ServiceType == desc.ServiceType);
            if (oldDesc != null)
                ServiceCollection.Remove(oldDesc);

            ServiceCollection.Add(desc);
        }
    }
    public abstract class TestBase<TService> : TestBase
    {
        /// <summary>
        /// Получает тестируемый сервис
        /// </summary>
        protected TService GetTestingService()
            => ServiceProviderServiceExtensions.GetRequiredService<TService>(GetServiceProvider());
    }
}
