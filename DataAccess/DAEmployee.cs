using Cassandra;
using Cassandra.Data;
using Microsoft.Build.BuildEngine;
using Microsoft.JScript;
using OpenXmlPowerTools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Row = Cassandra.Row;


namespace DataAccess
{
    public class DAEmployee
    {
       

        public DAEmployee()
        {

        }
        public void CreateEmpTable()
        {
            try
            {
                
                Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
                ISession session = cluster.Connect();
                session.Execute("CREATE KEYSPACE Employee WITH REPLICATION = { 'class' : 'NetworkTopologyStrategy', 'datacenter1' : 1 };");
                session.Execute("Use Employee");

                session.Execute("CREATE TABLE IF NOT EXISTS Employee.emp (EmpFirstName text PRIMARY KEY, EmpLastName text, Salary text, City text, PhoneNo text)");
              

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void DeleteEmpTable()
        {
            Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            ISession session = cluster.Connect();
            session.Execute("drop table Employee.emp");
            session.Execute("drop keyspace Employee");
          
        }

        public void InsertEmpTable()
        {
            Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            ISession session = cluster.Connect();

            //string name = i.ToString();
            session.Execute("insert into Employee.emp (empfirstname, emplastname, salary, city, phoneno) VALUES ('Joe', 'Jonas', '1500', 'Bucharest', '0722122123')");
            
        }

        public RowSet DisplayEmpTable()
        {
                           
                Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
                ISession session = cluster.Connect();
         

            RowSet data = new RowSet();
            data = session.Execute("Select * from Employee.emp");
           
            return data;
        }

   
        public void UpdateEmpTable()
        {
            Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            ISession session = cluster.Connect();

            session.Execute("UPDATE Employee.emp SET city='San Fransisco' WHERE EmpFirstName = 'Joe'");

        }


    }
}
