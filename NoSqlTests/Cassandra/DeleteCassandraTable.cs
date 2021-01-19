using BenchmarkDotNet.Attributes;
using BusinessLogic;
using System.Threading.Tasks;

namespace NoSqlTests.Cassandra
{
    public class DeleteCassandraTable
    {
        static BLEmployee ble = new BLEmployee();
        [Benchmark]
        public void Delete()
        {
            //BLEmployee ble = new BLEmployee();
            ble.CreateEmpTable();
            ble.DeleteEmpTable();
            // Task.Delay(100);
        }
    }
}
