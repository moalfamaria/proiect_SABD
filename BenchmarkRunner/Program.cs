using BenchmarkDotNet.Running;
using NoSqlTests.Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TestsRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            //var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
            //Console.ReadLine();
            var summary = BenchmarkRunner.Run<DeleteCassandraTable>();
            Console.ReadLine();

        }
    }
}
