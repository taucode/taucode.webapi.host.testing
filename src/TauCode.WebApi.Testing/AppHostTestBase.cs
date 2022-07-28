using Autofac;
using NHibernate;
using System.Globalization;
using System.Net.Http;
using TauCode.Db.Testing;
using TauCode.WebApi.Server;

namespace TauCode.WebApi.Testing
{
    public abstract class AppHostTestBase : DbTestBase
    {
        protected abstract ITestFactory CreateTestFactory();

        protected ITestFactory TestFactory { get; private set; }

        protected HttpClient HttpClient { get; private set; }
        protected ILifetimeScope Container { get; private set; }

        protected ILifetimeScope SetupLifetimeScope { get; private set; }
        protected ILifetimeScope TestLifetimeScope { get; private set; }
        protected ILifetimeScope AssertLifetimeScope { get; private set; }

        protected ISession SetupSession { get; set; }
        protected ISession TestSession { get; set; }
        protected ISession AssertSession { get; set; }

        protected override void OneTimeSetUpImpl()
        {
            Inflector.Inflector.SetDefaultCultureFunc = () => new CultureInfo("en-US");

            this.TestFactory = this.CreateTestFactory();
            this.HttpClient = this.TestFactory.CreateClient();

            var startup = this.TestFactory.GetService<IAutofacStartup>();

            this.Container = startup.AutofacContainer;

            base.OneTimeSetUpImpl();
        }

        protected override void OneTimeTearDownImpl()
        {
            base.OneTimeTearDownImpl();

            this.HttpClient.Dispose();
            this.TestFactory.Dispose();

            this.HttpClient = null;
            this.TestFactory = null;
        }

        protected override void SetUpImpl()
        {
            base.SetUpImpl();

            this.SetupLifetimeScope = this.Container.BeginLifetimeScope();
            this.TestLifetimeScope = this.Container.BeginLifetimeScope();
            this.AssertLifetimeScope = this.Container.BeginLifetimeScope();

            // nhibernate stuff
            this.SetupSession = this.SetupLifetimeScope.Resolve<ISession>();
            this.TestSession = this.TestLifetimeScope.Resolve<ISession>();
            this.AssertSession = this.AssertLifetimeScope.Resolve<ISession>();
        }

        protected override void TearDownImpl()
        {
            base.TearDownImpl();

            this.SetupSession.Dispose();
            this.TestSession.Dispose();
            this.AssertSession.Dispose();

            this.SetupLifetimeScope.Dispose();
            this.TestLifetimeScope.Dispose();
            this.AssertLifetimeScope.Dispose();
        }
    }
}
