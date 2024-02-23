using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sain_Micheal_DataBase
{
    internal class ChurchMembers
    {
        public int id { set; get; } // 2
        public string FirstName { set; get; } // 2
        public string MiddleName { set; get; } // 2
        public string LastName { set; get; } // 2
        public string Gender { set; get; } // 3
        public string PhoneNumber { set; get; } // 4
       
       public DateTime RegisteredDate { set; get; } // 6
        
        public string Status { set; get; }

        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\DELL\source\repos\Sain Micheal DataBase\Sain Micheal DataBase\Employee.mdf"";Integrated Security=True;Connect Timeout=30");

        public List<ChurchMembers> ChurchMember()
        {
            List<ChurchMembers> listdata = new List<ChurchMembers>();

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT * FROM Members";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            ChurchMembers ed = new ChurchMembers();
                            ed.id = (int)reader["id"];
                            ed.FirstName = reader["FirstName"].ToString();
                            ed.MiddleName = reader["MiddleName"].ToString();
                            ed.LastName = reader["LastName"].ToString();
                            ed.Gender = reader["Gender"].ToString();
                            ed.RegisteredDate = (DateTime)reader["RegisteredDate"];
                            ed.PhoneNumber = reader["PhoneNumber"].ToString();
                            ed.Status = reader["Status"].ToString();

                            listdata.Add(ed);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                }
                finally
                {
                    connect.Close();
                }
            }
            return listdata;
        }



    }
}
