using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;
namespace Sain_Micheal_DataBase
{
    public partial class dashboard1 : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\DELL\source\repos\Sain Micheal DataBase\Sain Micheal DataBase\Employee.mdf"";Integrated Security=True;Connect Timeout=30");

        public dashboard1()
        {
            InitializeComponent();
            displayTotal();
            displayActive();
            displayInActive();

        }


        public void displayTotal()
        {
            if (conn.State != ConnectionState.Open)
            {
                try
                {
                    conn.Open();

                    string selectData = "SELECT COUNT(id) FROM Members";

                    using (SqlCommand cmd = new SqlCommand(selectData, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            Total.Text = count.ToString();
                        }
                        reader.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex, "Error Message"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public void displayActive()
        {
            if (conn.State != ConnectionState.Open)
            {
                try
                {
                    conn.Open();

                    string selectData = "SELECT COUNT(id) FROM Members WHERE status = @status ";
                        

                    using (SqlCommand cmd = new SqlCommand(selectData, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", "Active");
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            Active.Text = count.ToString();
                        }
                        reader.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex, "Error Message"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void displayInActive()
        {
            if (conn.State != ConnectionState.Open)
            {
                try
                {
                    conn.Open();

                    string selectData = "SELECT COUNT(id) FROM Members WHERE status = @status ";
                        

                    using (SqlCommand cmd = new SqlCommand(selectData, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", "InActive");
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            InActive.Text = count.ToString();
                        }
                        reader.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex, "Error Message"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

    


private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
