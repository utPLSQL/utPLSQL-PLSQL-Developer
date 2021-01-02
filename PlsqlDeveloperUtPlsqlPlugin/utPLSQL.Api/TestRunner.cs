using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Text;

namespace utPLSQL
{
    public abstract class TestRunner<T>
    {
        public const string User = "USER";
        public const string Package = "PACKAGE";
        public const string Procedure = "PROCEDURE";
        public const string All = "_ALL";

        internal OracleConnection produceConnection;
        internal OracleConnection consumeConnection;

        protected string realtimeReporterId;
        protected string coverageReporterId;

        public void Connect(string username, string password, string database)
        {
            var connectionString = $"User Id={username};Password={password};Data Source={database}";

            produceConnection = new OracleConnection(connectionString);
            produceConnection.Open();

            consumeConnection = new OracleConnection(connectionString);
            consumeConnection.Open();
        }

        public void Close()
        {
            produceConnection?.Close();
            consumeConnection?.Close();
        }

        public String GetVersion()
        {
            var cmd = new OracleCommand("select ut.version() from dual", produceConnection);
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            var version = reader.GetString(0);
            reader.Close();
            return version;
        }

        public abstract void RunTests(string type, string owner, string name, string procedure);

        public abstract void RunTestsWithCoverage(string type, string owner, string name, string procedure, string coverageSchemas,
            string includeObjects, string excludeObjects);

        public abstract void ConsumeResult(Action<T> consumer);

        public string GetCoverageReport()
        {
            var sb = new StringBuilder();

            var proc = @"DECLARE
                           l_reporter ut_coverage_html_reporter := ut_coverage_html_reporter();
                         BEGIN
                           l_reporter.set_reporter_id(:id);
                           :lines_cursor := l_reporter.get_lines_cursor();
                         END;";

            var cmd = new OracleCommand(proc, consumeConnection);
            cmd.Parameters.Add("id", OracleDbType.Varchar2, ParameterDirection.Input).Value = coverageReporterId;
            cmd.Parameters.Add("lines_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

            // https://stackoverflow.com/questions/2226769/bad-performance-with-oracledatareader
            cmd.InitialLOBFetchSize = -1;

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var line = reader.GetString(0);
                sb.Append(line);
            }

            reader.Close();

            return sb.ToString();
        }
    }
}