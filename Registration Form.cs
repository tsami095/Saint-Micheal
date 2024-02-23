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
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Contexts;

namespace Sain_Micheal_DataBase
{
    public partial class Registration_Form : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\DELL\source\repos\Sain Micheal DataBase\Sain Micheal DataBase\Employee.mdf"";Integrated Security=True;Connect Timeout=30");

        public Registration_Form()
        {
            InitializeComponent();
        }

        private void Registration_Form_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void signup_loginBtn_Click(object sender, EventArgs e)
        {
            Form1 loginform = new Form1();
            loginform.Show();
            this.Hide();
        }

        private void signup_Btn_Click(object sender, EventArgs e)
        {
            if(signup_username.Text ==""||  signup_password.Text==" ")
            {
                MessageBox.Show("Please fill the Empty Blank", "Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if (signup_password.Text.Trim() != signup_confirm.Text.Trim())
                {
                    MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            

            else 

            {
                if (conn.State != ConnectionState.Open)
                {
                    try
                    {

                        conn.Open();
                        //To check if the user is registered
                        String selectname = "Select count(id) from users where username=@username";
                        using (SqlCommand checkuser = new SqlCommand(selectname, conn))
                        {
                            checkuser.Parameters.AddWithValue("@username", signup_username.Text.Trim());
                            int count = (int)checkuser.ExecuteScalar();

                            if (count >= 1)
                            {
                                MessageBox.Show(signup_username.Text.Trim() + " is already taken", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                DateTime today = DateTime.Today;
                                string insertData = "insert into users(username,password,date_register) values(@username,@password,@datereg)";
                                using (SqlCommand cmd = new SqlCommand(insertData, conn))
                                { 
                                    cmd.Parameters.AddWithValue("@username", signup_username.Text.Trim());
                                    cmd.Parameters.AddWithValue("@password", signup_password.Text.Trim());
                                    cmd.Parameters.AddWithValue("@datereg", today);
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Registered Successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Form1 f = new Form1();
                                    f.Show();
                                    this.Hide();
                                }
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show( "Error " + ex, "Error Message",MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        conn.Close();                    }
                }
            }
        }

        private void signup_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            signup_password.PasswordChar = signup_checkbox.Checked ? '\0' : '*';
            signup_confirm.PasswordChar = signup_checkbox.Checked ? '\0' : '*';
        }

        private void signup_password_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
