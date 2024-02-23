using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Sain_Micheal_DataBase
{
    internal class EmployeeData
    {
        public int ID {  get; set; }
      
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string gender { get; set; }

        public string contactNumber { get; set; }
        public int payment {  get; set; }

        public string status { get; set; }

       

        SqlConnection conn=new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=Mezgeb;Integrated Security=True");
        
        public List<EmployeeData> EmployeeListData()
        {
            List < EmployeeData > list = new List<EmployeeData>();
            if (conn.State == ConnectionState.Open)
            {
                try
                {
                conn.Open();
                }catch(Exception ex)
                {
                   Console.WriteLine("Error",ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            return list;
        }
            
    
    }
}
