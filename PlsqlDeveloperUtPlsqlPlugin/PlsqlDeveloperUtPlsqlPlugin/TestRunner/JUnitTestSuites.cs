using System.Collections.Generic;
using System.Xml.Serialization;

namespace PlsqlDeveloperUtPlsqlPlugin
{
    [XmlRoot("testsuites")]
    public class JUnitTestSuites
    {
        [XmlAttribute("tests")]
        public int Tests { get; set; }

        [XmlAttribute("disabled")]
        public int Disabled { get; set; }

        [XmlAttribute("errors")]
        public int Errros { get; set; }

        [XmlAttribute("failures")]
        public int Failures { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("time")]
        public string Time { get; set; }

        [XmlElement("testsuite")]
        public TestSuite TestSuite { get; set; }
    }

    public class TestSuite
    {
        [XmlAttribute("tests")]
        public int Tests { get; set; }

        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("package")]
        public string Package { get; set; }

        [XmlAttribute("disabled")]
        public int Disabled { get; set; }

        [XmlAttribute("errors")]
        public int Errors { get; set; }

        [XmlAttribute("failures")]
        public int Failures { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("time")]
        public string Time { get; set; }

        [XmlElement("testsuite")]
        public List<TestSuite> TestSuites { get; set; }

        [XmlElement("testcase")]
        public List<TestCase> TestCases { get; set; }
    }
    public class TestCase
    {
        [XmlAttribute("classname")]
        public string ClassName { get; set; }

        [XmlAttribute("assertions")]
        public string Assertions { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("time")]
        public string Time { get; set; }
        
        [XmlAttribute("status")]
        public string Status { get; set; }

        [XmlElement("error")]
        public string Error { get; set; }
    }
}
