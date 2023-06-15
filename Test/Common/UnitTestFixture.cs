using Mc2.CrudTest.Presentation.Server.Data;

namespace Test.Common
{
    using AutoMapper;
    using Xunit;

    [CollectionDefinition(nameof(UnitTestFixture))]
    public class FixtureCollection : ICollectionFixture<UnitTestFixture> { }

    public class UnitTestFixture : IDisposable
    {
        public UnitTestFixture()
        {
            Mapper = MapperFactory.Create();
            DbContext = DbContextFactory.Create();
        }

        public IMapper Mapper { get; }
        public CustomerDbContext DbContext { get; }

        public void Dispose()
        {
            DbContextFactory.Destroy(DbContext);
        }
    }
}
