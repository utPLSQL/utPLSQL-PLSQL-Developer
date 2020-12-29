using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace PlsqlDeveloperUtPlsqlPlugin
{
    class TestResult
    {
        internal string Id { get; set; }
        
        public Bitmap Icon { get; set; }
        public string Name { get; set; }
        public decimal Time { get; set; }

        internal DateTime Start { get; set; }
        internal DateTime End { get; set; }

        internal string Owner { get; set; }
        internal string Package { get; set; }
        internal string Procedure { get; set; }
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
