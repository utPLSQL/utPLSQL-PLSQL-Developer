using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Text;

namespace utPLSQL
{
    public abstract class TestRunner<T>
    {
        public const string USER = "USER";
        public const string PACKAGE = "PACKAGE";
        public const string PROCEDURE = "PROCEDURE";
        public const string ALL = "_ALL";

        internal OracleConnection produceConnection;
        internal OracleConnection consumeConnection;
        internal OracleConnection coverageConnection;

        protected string realtimeReporterId;
        protected string coverageReporterId;

        public void Connect(string username, string password, string database)
        {
            string connectionString = $"User Id={username};Password={password};Data Source={database}";

            produceConnection = new OracleConnection(connectionString);
            produceConnection.Open();

            consumeConnection = new OracleConnection(connectionString);
            consumeConnection.Open();

            coverageConnection = new OracleConnection(connectionString);
            coverageConnection.Open();
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
            if (coverageConnection != null)
            {
                coverageConnection.Close();
            }
        }

        public abstract void RunTests(string type, string owner, string name, string procedure);

        public abstract void RunTestsWithCoverage(string type, string owner, string name, string procedure, string coverageSchemas, string includeObjects, string excludeObjects);

        public abstract void ConsumeResult(Action<T> consumer);

        public string GetCoverageReport()
        {
            StringBuilder sb = new StringBuilder();

            string proc = @"DECLARE
                              l_reporter ut_coverage_html_reporter := ut_coverage_html_reporter();
                            BEGIN
                              l_reporter.set_reporter_id(:id);
                              :lines_cursor := l_reporter.get_lines_cursor();
                            END;";

            OracleCommand cmd = new OracleCommand(proc, coverageConnection);
            cmd.Parameters.Add("id", OracleDbType.Varchar2, ParameterDirection.Input).Value = coverageReporterId;
            cmd.Parameters.Add("lines_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
            cmd.FetchSize = 10000;

            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string line = reader.GetString(0);
                sb.Append(line);
            }
            reader.Close();

            return sb.ToString();
        }
    }

}