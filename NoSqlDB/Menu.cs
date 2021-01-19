using Amazon.DynamoDBv2.Model;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BusinessLogic;
using Cassandra;
using Entities;
using MongoDB.Bson;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NoSqlDB
{
    //[ClrJob, CoreJob, MonoJob, CoreRtJob]
    //[RPlotExporter, RankColumn]
    //[MemoryDiagnoser]


    //[Obsolete]
    public partial class Menu : Form
    {

        public Menu()
        {
            InitializeComponent();


        }

        //---------------------------CASSANDRA DB-----------------------------
        public void ClearTB()
        {


        }

        private void btn_CreateTableCassandra_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            BLEmployee ble = new BLEmployee();
            ble.CreateEmpTable();

            stopwatch.Stop();
            lbl_CreateCassandraTable.Text = stopwatch.ElapsedMilliseconds.ToString();


            MessageBox.Show("Tabela Employee.emp a fost creata");

          
        }

        private void btn_DeleteCassandraTable_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            BLEmployee ble = new BLEmployee();
            ble.DeleteEmpTable();
            stopwatch.Stop();
            lbl_DeleteCassandraTable.Text = stopwatch.ElapsedMilliseconds.ToString();
            MessageBox.Show("Tabela Employee.emp a fost stearsa");

           
        }

        private void btn_InsertTableCassandra_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            BLEmployee ble = new BLEmployee();
            ble.InsertEmpTable();
            stopwatch.Stop();
            lbl_InsertCassandraTable.Text = stopwatch.ElapsedMilliseconds.ToString();
            MessageBox.Show("Angajatul a fost inserat in tabela Employee.emp");
        }

        private void btn_DisplayCassandraTable_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            BLEmployee ble = new BLEmployee();


            RowSet employeeList = new RowSet();
            employeeList = ble.DisplayEmpTable();



            var list = new List<Employee>();
            foreach (var row in employeeList.GetRows())
            {
                var employee = new Employee();
                employee.City = row["city"] as string;
                employee.EmpFirstName = row["empfirstname"] as string;
                employee.EmpLastName = row["emplastname"] as string;
                employee.PhoneNo = row["phoneno"] as string;
                employee.Salary = row["salary"] as string;
                list.Add(employee);
            }
            gridview.DataSource = list;

            // DataGridViewColumn column = new DataGridViewTextBoxColumn();


            stopwatch.Stop();
            lbl_DisplayCassandraTable.Text = stopwatch.ElapsedMilliseconds.ToString();


        }

        private void btn_UpdateCassandraTable_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            BLEmployee ble = new BLEmployee();
            ble.UpdateEmpTable();

            stopwatch.Stop();
            lbl_UpdateCassandraTable.Text = stopwatch.ElapsedMilliseconds.ToString();
            MessageBox.Show("Detaliile angajatului au fost modificate cu succes");

        }

        //---------------------------MONGO DB-------------------------------

        private void btn_CreateMongoClollection_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            BLEmployeeMongo blm = new BLEmployeeMongo();
            blm.CreateEmpCollection();
            stopwatch.Stop();

            MessageBox.Show("Colectia Employee a fost creata");
            lbl_CreateMongo.Text = stopwatch.ElapsedMilliseconds.ToString();
        }

        private void btn_InsertMongoCollection_Click(string[] args, object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            BLEmployeeMongo blm = new BLEmployeeMongo();
            blm.InsertEmpCollection(args);
            stopwatch.Stop();
            MessageBox.Show("Angajatul a fost introdus in colectia de date");
            lbl_InsertMongo.Text = stopwatch.ElapsedMilliseconds.ToString();
        }
        public IEnumerable<BsonValue> GetValues { get; set; }
        private void btn_DisplayMongoCollection_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            BLEmployeeMongo blm = new BLEmployeeMongo();
            BsonDocument employeelist = new BsonDocument();
            BsonElement doc = new BsonElement();
            employeelist = blm.DisplayEmpCollection();

            var list = new List<BsonElement>();
            foreach (var row in employeelist)
            {
                doc = row;


                list.Add(doc);
            }
            gridview.DataSource = list;

            stopwatch.Stop();
            lbl_DisplayMongo.Text = stopwatch.ElapsedMilliseconds.ToString();


        }

        private void btn_UpdateMongoCollection_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            BLEmployeeMongo ble = new BLEmployeeMongo();
            ble.UpdateEmpCollection();
            stopwatch.Stop();

            MessageBox.Show("Detaliile angajatului au fost actualizate");
            lbl_UpdateMongo.Text = stopwatch.ElapsedMilliseconds.ToString();

        }

        private void btn_DeleteMongoCollection_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            BLEmployeeMongo ble = new BLEmployeeMongo();
            ble.DeleteEmpCollection();
            stopwatch.Stop();
            MessageBox.Show("Colectia Employee a fost stearsa");
            lbl_DeleteMongo.Text = stopwatch.ElapsedMilliseconds.ToString();
        }


        /* mySQL */

        private void btn_DisplaySQL_Click(object sender, EventArgs e)
        {

            SQLserver blc = new SQLserver();

            gridview.DataSource = blc.DisplayEmpsOnGrid();


            gridview.Columns["EmpFirstName"].HeaderText = "Prenume";
            gridview.Columns["EmpLastName"].HeaderText = "Nume";
            gridview.Columns["Salary"].HeaderText = "Salariu";
            gridview.Columns["City"].HeaderText = "Oras";
            gridview.Columns["PhoneNo"].HeaderText = "Numar Telefon";

        }


        private void btn_InsertSQL_Click(object sender, EventArgs e)
        {


            SQLserver blcl = new SQLserver();
            if (string.IsNullOrWhiteSpace(txt_FirstName.Text))
            {
                MessageBox.Show("Prenumele nu este completat", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            if (string.IsNullOrWhiteSpace(txt_LastName.Text))
            {
                MessageBox.Show("Numele nu este completat", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            if (string.IsNullOrWhiteSpace(txt_Salary.Text))
            {
                MessageBox.Show("Salariul nu este completat", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            if (string.IsNullOrWhiteSpace(txt_City.Text))
            {
                MessageBox.Show("Orasul nu este completat", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            if (string.IsNullOrWhiteSpace(txt_PhoneNo.Text))
            {
                MessageBox.Show("Numarul de telefon nu este completat", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            blcl.InsertEmpsIntoDB(txt_FirstName.Text, txt_LastName.Text, txt_Salary.Text, txt_City.Text, txt_PhoneNo.Text, out bool status);
            MessageBox.Show("Angajatul a fost adaugat");

        }

        private void btn_CreateTableSQL_Click(object sender, EventArgs e)
        {
            SQLserver blcl = new SQLserver();
            blcl.CreateSQLDB();

        }


        private void btn_DeleteRecordSQL_Click(object sender, EventArgs e)
        {
            SQLserver blcl = new SQLserver();
            blcl.DropSQLDB();
        }


        public class Employee
        {
            //public ObjectId Id { get; set; }
            public String EmpFirstName { get; set; }
            public String EmpLastName { get; set; }
            public String Salary { get; set; }
            public String City { get; set; }
            public String PhoneNo { get; set; }

        }
        public class CasandraTests
        {
            [Benchmark]
            public void TestCasandra()
            {
                Task.Delay(100);
            }
        }

        private void lbl_MongoTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
