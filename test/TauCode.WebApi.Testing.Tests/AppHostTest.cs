using NUnit.Framework;
using System;
using System.Globalization;
using TauCode.Db;

// todo clean up
namespace TauCode.WebApi.Testing.Tests
{
    [TestFixture]
    public abstract class AppHostTest : AppHostTestBase
    {
        //private TestFactory _factory;
        //private string _connectionString;
        //private string _tempDbFilePath;
        //private ILifetimeScope _container;

        [OneTimeSetUp]
        public void OneTimeSetUpBase()
        {
            this.OneTimeSetUpImpl();
        }

        [OneTimeTearDown]
        public void OneTimeTearDownBase()
        {
            this.OneTimeTearDownImpl();
        }

        [SetUp]
        public void SetUpBase()
        {
            this.SetUpImpl();
        }

        [TearDown]
        public void TearDownBase()
        {
            this.TearDownImpl();
        }

        protected override ITestFactory CreateTestFactory() => new TestFactory();

        protected override void OneTimeSetUpImpl()
        {
            Inflector.Inflector.SetDefaultCultureFunc = () => new CultureInfo("en-US");
            //_factory = new TestFactory();

            base.OneTimeSetUpImpl();
        }

        protected override void OneTimeTearDownImpl()
        {
            base.OneTimeTearDownImpl();
            //try
            //{
            //    File.Delete(_tempDbFilePath);
            //}
            //catch
            //{
            //    // dismiss
            //}
        }

        //protected override string GetDbProviderName() => DbProviderNames.SQLite;

        protected override string GetConnectionString() =>
            //((Startup)this.TestFactory.GetService<IAutofacStartup>()).SQLiteTestConfigurationBuilder.ConnectionString;
            throw new NotImplementedException();

        //protected override HttpClient CreateHttpClient()
        //{
        //    var httpClient = _factory
        //        .WithWebHostBuilder(builder => builder.UseSolutionRelativeContentRoot(@"test\TauCode.WebApi.Testing.Tests"))
        //        .CreateClient();

        //    var testServer = _factory.Factories.Single().Server;

        //    var startup = (Startup)testServer.Services.GetService<IAutofacStartup>();
        //    _container = startup.AutofacContainer;

        //    _connectionString = startup.SQLiteTestConfigurationBuilder.ConnectionString;
        //    _tempDbFilePath = startup.SQLiteTestConfigurationBuilder.TempDbFilePath;

        //    return httpClient;
        //}

        //protected override ILifetimeScope GetContainer() => _container;

        //protected override void DisposeFactory()
        //{
        //    _factory.Dispose();
        //    _factory = null;
        //}

        protected override IDbUtilityFactory GetDbUtilityFactory()
        {
            throw new System.NotImplementedException();
        }
    }
}
