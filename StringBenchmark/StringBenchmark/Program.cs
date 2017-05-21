using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Text;

namespace StringBenchmark
{
    public class Stringoperations
    {
        private readonly DateTime _now = DateTime.Now;

        [Benchmark]
        public string TrivialStringFormat()
        {
            return string.Format("Today's date is {0:D} and the time is {1:T}", _now, _now); ;
        }

        [Benchmark]
        public string TRivialStringInterpolate()
        {
            return $"Today's date is {_now:D} and the time is {_now:T}";
        }

        [Benchmark]
        public string TrivialStringConcat()
        {
            return "Today's date is " + _now.ToString("D") + " and the time is " + _now.ToString("T");
        }

        [Benchmark]
        public string TrivialStringBuilder()
        {
            var sb = new StringBuilder();

            sb.Append("Today's date is ");
            sb.Append(_now.ToString("D"));
            sb.Append(" and the time is ");
            sb.Append(_now.ToString("T"));

            return sb.ToString();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Stringoperations>();
        }
    }
}