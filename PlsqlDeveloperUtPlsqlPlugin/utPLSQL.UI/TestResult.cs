using System;
using System.ComponentModel;
using System.Drawing;

namespace utPLSQL
{
    internal class TestResult
    {
        public Bitmap Icon { get; set; }

        public string Package { get; set; }
        public string Procedure { get; set; }
        public decimal Time { get; set; }
        internal string Id { get; set; }

        internal DateTime Start { get; set; }
        internal DateTime End { get; set; }

        internal string Owner { get; set; }
        internal string Name { get; set; }
        internal string Description { get; set; }

        internal string Error { get; set; }

        internal BindingList<Expectation> failedExpectations = new BindingList<Expectation>();
    }
    internal class Expectation
    {
        internal Expectation(string message, string caller)
        {
            this.Message = message;
            this.Caller = caller;
        }
        public string Message { get; set; }
        public string Caller { get; set; }
    }
}
