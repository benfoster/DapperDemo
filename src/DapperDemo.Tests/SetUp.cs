using DapperDemo.Scripts;
using DbUp;
using NUnit.Framework;
using System.Configuration;

namespace DapperDemo.Tests
{
    [SetUpFixture]
    public class SetUp
    {       
        [SetUp]
        public void RunBeforeAnyTests()
        {
            var connectionString = ConfigurationManager
                .ConnectionStrings[Constants.ConnectionStringName].ConnectionString;

            var upgrader = DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(typeof(IContainScripts).Assembly)
                .LogToTrace()
                .Build();

            var result = upgrader.PerformUpgrade();
        }

        [TearDown]
        public void RunAfterAnyTests()
        {

        }
    }
}
