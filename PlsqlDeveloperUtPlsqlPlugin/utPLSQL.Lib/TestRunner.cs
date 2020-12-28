using Oracle.ManagedDataAccess.Client;
using System;

namespace utPLSQL
{
    public abstract class TestRunner<T>
    {
        internal OracleConnection produceConnection;
        internal OracleConnection consumeConnection;

        public void Connect(string username, string password, string database)
        {
            string connectionString = $"User Id={username};Password={password};Data Source={database}";

            produceConnection = new OracleConnection(connectionString);
            produceConnection.Open();

            consumeConnection = new OracleConnection(connectionString);
            consumeConnection.Open();
        }

        public void Close()
        {
            if (produceConnection != null)
            {
                produceConnection.Close();
            }
            if (consumeConnection != null)
            {
                consumeConnection.Close();
            }
        }

        public abstract void RunTests(string type, string owner, string name, string subType);

        public abstract void ConsumeResult(Action<T> consumer);
    }

}