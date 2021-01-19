using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
   public class SQLserver
    {

        public SQLserver()
        {

        }

        public void CreateSQLDB()
        {


            DASQLserver dac = new DASQLserver();
            dac.CreateSQLDB();

                      
        }

        public DataTable DisplayEmpsOnGrid()
        {
           

            DASQLserver dac = new DASQLserver();
            DataTable tableEmp = dac.DisplayEmpsOnGrid();
          
            return tableEmp;

        }


        public void InsertEmpsIntoDB(string EmpFirstName, string EmpLastName, string Salary, string City, string PhoneNo, out bool status)
        {
            Employee client = new Employee();
            status = false;
            DASQLserver dac = new DASQLserver();
            DataTable dmc = dac.InsertEmpsIntoDB(EmpFirstName, EmpLastName, Salary, City, PhoneNo);

            
            if (dmc.Rows.Count == 0)
            {
                status = false;



                for (int i = 0; i < dmc.Rows.Count; i++)
                {
                    if (PhoneNo != dmc.Rows[i]["PhoneNo"].ToString())
                    {
                        status = true;
                       
                        client.EmpFirstName = dmc.Rows[i]["EmpFirstName"].ToString();
                        client.EmpLastName = dmc.Rows[i]["EmpLastName"].ToString();
                        client.Salary = dmc.Rows[i]["Salary"].ToString();
                        client.City = dmc.Rows[i]["City"].ToString();
                        client.PhoneNo = dmc.Rows[i]["PhoneNo"].ToString();

                    }
                    else
                        status = false;


                }
            }




        }
        public void DropSQLDB()
        {


            DASQLserver dac = new DASQLserver();
            dac.DropSQLDB();
            
        }

        

    }
}
