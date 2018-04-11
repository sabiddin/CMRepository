using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CM.Data
{
    public interface ITransactionFactory
    {
        IDbTransaction GetTransaction();
    }

    public class TransactionFactory : ITransactionFactory
    {
        private IDbConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["WoundExpert"].ConnectionString);
        }

        public IDbTransaction GetTransaction()
        {
            var dbConnection = GetConnection();
            dbConnection.Open();
            return dbConnection.BeginTransaction();
        }
    }
}
