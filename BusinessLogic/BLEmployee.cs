using Cassandra;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Row = Cassandra.Row;

namespace BusinessLogic
{
   public class BLEmployee
    {
        public BLEmployee()
        {

        }

        public void CreateEmpTable()
        {
            DAEmployee dae = new DAEmployee();
            dae.CreateEmpTable();

        }

        public void DeleteEmpTable()
        {
            DAEmployee dae = new DAEmployee();
            dae.DeleteEmpTable();
        }
        public void InsertEmpTable()
        {
            DAEmployee dae = new DAEmployee();
           
            dae.InsertEmpTable();
            
        }

        public RowSet DisplayEmpTable()
        {
            DAEmployee dae = new DAEmployee();
            RowSet data = dae.DisplayEmpTable();
            return data;

        }

        public void UpdateEmpTable()
        {
            DAEmployee dae = new DAEmployee();
            dae.UpdateEmpTable();
        }


    }
}
