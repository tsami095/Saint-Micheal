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


namespace Sain_Micheal_DataBase
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\DELL\source\repos\Sain Micheal DataBase\Sain Micheal DataBase\Employee.mdf"";Integrated Security=True;Connect Timeout=30");


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = login_checkbox.Checked ? '\0' : '*';
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void login_button_Click(object sender, EventArgs e)
        {
            
         
            if (login_username.Text == "" || login_password.Text == "")
            {
                MessageBox.Show("Please Fill the Blank", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (con.State == ConnectionState.Closed)
                {
                    try
                    {
                      
                       con.Open();

                      

                        string selectname = "select * from users where username=@username and " +
                            " password=@password";
                        using (SqlCommand cmd = new SqlCommand(selectname, con))
                        {
                            cmd.Parameters.AddWithValue("@username", login_username.Text.Trim());
                            cmd.Parameters.AddWithValue("@password", login_password.Text.Trim());
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            if (table.Rows.Count > 0)
                            {
                               
                                MessageBox.Show("Login Successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                MainForm mf = new MainForm();
                                mf.Show();
                                this.Hide();

                            }
                            else
                            {
                                MessageBox.Show("Incorrect UserName or Password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Show();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error", "Error Message" + "" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        con.Close();
                    }

                }

            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_signupBtn_Click(object sender, EventArgs e)
        {
            Registration_Form regform = new Registration_Form();
            regform.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void login_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void login_Btn_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void login_Btn_KeyDown(object sender, KeyEventArgs e)
        {
           
            

            if (login_username.Text == "" || login_password.Text == "")
            {
              
                MessageBox.Show("Please Fill the Blank", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                
            }
            else
            {
                if (con.State == ConnectionState.Closed)
                {
                    try
                    {
                        con.Open();

                        string selectname = "select * from users where username=@username and " +
                            " password=@password";
                        using (SqlCommand cmd = new SqlCommand(selectname, con))
                        {
                            cmd.Parameters.AddWithValue("@username", login_username.Text.Trim());
                            cmd.Parameters.AddWithValue("@password", login_password.Text.Trim());
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            if (table.Rows.Count > 0)
                            {
                                MessageBox.Show("Login Successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                MainForm mf = new MainForm();
                                mf.Show();
                                this.Hide();



                            }
                            else
                            {
                                MessageBox.Show("Incorrect UserName or Password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Show();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error", "Error Message" + "" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        con.Close();
                    }

                }


            }


        }
    }
}

