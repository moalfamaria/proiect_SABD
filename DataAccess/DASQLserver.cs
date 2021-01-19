using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   public class DASQLserver
    {
        public DASQLserver()
        {

        }

        public void CreateSQLDB()
        {
            DataTable datat = new DataTable();
            try
            {



                SqlConnection conn = new SqlConnection(Properties.Resources.ConnectionString);
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "CREATE TABLE Employee (EmpFirstName varchar(20), EmpLastName varchar(20), Salary float, City varchar(20), PhoneNo int)";

   

                SqlDataAdapter adapt = new SqlDataAdapter(comm);


                SqlDataReader reader = comm.ExecuteReader();
                datat.Load(reader);

                conn.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable DisplayEmpsOnGrid()
        {
            DataTable datat = new DataTable();
            try
            {



                SqlConnection conn = new SqlConnection(Properties.Resources.ConnectionString);
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "Select EmpFirstName, EmpLastName, Salary, City, PhoneNo from Employee";

           

                SqlDataAdapter adapt = new SqlDataAdapter(comm);


                SqlDataReader reader = comm.ExecuteReader();
                datat.Load(reader);

                conn.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datat;
        }

        public DataTable InsertEmpsIntoDB(string EmpFirstName, string EmpLastName, string Salary, string City, string PhoneNo)
        {
            DataTable addc = new DataTable();


            try
            {
                SqlConnection conne = new SqlConnection(Properties.Resources.ConnectionString);
                conne.Open();
                SqlCommand commd = new SqlCommand();
                commd.Connection = conne;
                commd.CommandType = CommandType.Text;
                commd.CommandText = "Insert into Employee(EmpFirstName, EmpLastName, Salary, City, PhoneNo) values( @EmpFirstName, @EmpLastName, @Salary, @City, @PhoneNo)";

         




                SqlParameter name = new SqlParameter();
                name.ParameterName = "@EmpFirstName";
                name.DbType = System.Data.DbType.String;
                name.Size = 256;
                name.Direction = System.Data.ParameterDirection.Input;
                name.Value = EmpFirstName;

                SqlParameter surname = new SqlParameter();
                surname.ParameterName = "@EmpLastName";
                surname.DbType = System.Data.DbType.String;
                surname.Size = 256;
                surname.Direction = System.Data.ParameterDirection.Input;
                surname.Value = EmpLastName;

                SqlParameter salary = new SqlParameter();
                salary.ParameterName = "@Salary";
                salary.DbType = System.Data.DbType.String;
                salary.Size = 256;
                salary.Direction = System.Data.ParameterDirection.Input;
                salary.Value = Salary;

                SqlParameter city = new SqlParameter();
                city.ParameterName = "@City";
                city.DbType = System.Data.DbType.String;
                city.Size = 256;
                city.Direction = System.Data.ParameterDirection.Input;
                city.Value = City;

                SqlParameter phoneno = new SqlParameter();
                phoneno.ParameterName = "@PhoneNo";
                phoneno.DbType = System.Data.DbType.String;
                phoneno.Size = 256;
                phoneno.Direction = System.Data.ParameterDirection.Input;
                phoneno.Value = PhoneNo;

                commd.Parameters.Add(name);
                commd.Parameters.Add(surname);
                commd.Parameters.Add(salary);
                commd.Parameters.Add(city);
                commd.Parameters.Add(phoneno);

                SqlDataAdapter adapte = new SqlDataAdapter(commd);
                adapte.SelectCommand = commd;

                adapte.Fill(addc);

              

                conne.Close();


            }

            catch (Exception ex)
            {
                throw ex;
            }

            return addc;


        }

        public void DropSQLDB()
        {
            DataTable datat = new DataTable();
            try
            {



                SqlConnection conn = new SqlConnection(Properties.Resources.ConnectionString);
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "DROP TABLE Employee";



                SqlDataAdapter adapt = new SqlDataAdapter(comm);


                SqlDataReader reader = comm.ExecuteReader();
                datat.Load(reader);

                conn.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



    }
}
