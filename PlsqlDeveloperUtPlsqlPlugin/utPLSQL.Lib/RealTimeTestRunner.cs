using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.IO;
using System.Xml.Serialization;

namespace utPLSQL
{
    public class RealTimeTestRunner : TestRunner<@event>
    {
        private string id;

        public override void RunTests(string type, string owner, string name, string subType)
        {
            string testsToRun = null;

            if (type.Equals("USER"))
            {
                testsToRun = name;
            }
            else if (type.Equals("PACKAGE"))
            {
                testsToRun = $"{owner}.{name}";
            }
            else if (type.Equals("_ALL"))
            {
                testsToRun = owner;
            }

            if (testsToRun != null)
            {
                id = Guid.NewGuid().ToString().Replace("-", "");

                string procedure = @"DECLARE
                                           l_reporter ut_realtime_reporter := ut_realtime_reporter();
                                         BEGIN
                                           l_reporter.set_reporter_id(:id);
                                           l_reporter.output_buffer.init();
                                           ut_runner.run(a_paths     => ut_varchar2_list(:test),
                                                         a_reporters => ut_reporters(l_reporter));
                                         END;";

                OracleCommand cmd = new OracleCommand(procedure, produceConnection);
                cmd.Parameters.Add("id", OracleDbType.Varchar2, ParameterDirection.Input).Value = id;
                cmd.Parameters.Add("test", OracleDbType.Varchar2, ParameterDirection.Input).Value = testsToRun;
                cmd.ExecuteNonQuery();
            }
        }

        public override void ConsumeResult(Action<@event> action)
        {
            string procedure = @"DECLARE
                                       l_reporter ut_realtime_reporter := ut_realtime_reporter();
                                     BEGIN
                                       l_reporter.set_reporter_id(:id);
                                       :lines_cursor := l_reporter.get_lines_cursor();
                                     END;";

            OracleCommand cmd = new OracleCommand(procedure, consumeConnection);
            cmd.Parameters.Add("id", OracleDbType.Varchar2, ParameterDirection.Input).Value = id;
            cmd.Parameters.Add("lines_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string xml = reader.GetString(0);

                var serializer = new XmlSerializer(typeof(@event));
                var @event = (@event)serializer.Deserialize(new StringReader(xml));

                action.Invoke(@event);
            }
            reader.Close();
        }
    }
}
