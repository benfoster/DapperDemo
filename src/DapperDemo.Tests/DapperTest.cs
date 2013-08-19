using NUnit.Framework;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DapperDemo.Tests
{
    public abstract class DapperTest
    {
        protected IDbConnection connection;

        [SetUp]
        public void SetUpDbConnection()
        {
            var connectionString = ConfigurationManager
                .ConnectionStrings[Constants.ConnectionStringName].ConnectionString;

            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        [TearDown]
        public void CloseDbConnection()
        {
            if (connection != null)
            {
                connection.Dispose();
            }
        }
    }
}
