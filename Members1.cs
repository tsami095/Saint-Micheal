using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Contexts;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace Sain_Micheal_DataBase
{
    public partial class Members1 : UserControl
    {
        int id;
        public const string motif = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\DELL\source\repos\Sain Micheal DataBase\Sain Micheal DataBase\Employee.mdf"";Integrated Security=True;Connect Timeout=30");
      
        public Members1()
        {
            InitializeComponent();
            displayMembers();
        }
        public void displayMembers()
        {
            ChurchMembers ed = new ChurchMembers();
            List<ChurchMembers> listData = ed.ChurchMember();
            
            dataGridView1.DataSource= listData;
            dataGridView1.Columns["id"].Visible = false;

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
                clearFields();
            
        }
        //Add Button
        private void Add_btn_Click(object sender, EventArgs e)
        {
            if (First_txt.Text == ""
              || Middle_txt.Text == ""
              || Last_txt.Text == ""
              || Phone_txt.Text == ""
              || Gender_txt.Text == ""
              || Status_txt.Text == ""
             )

            {
                MessageBox.Show("Please fill all blank fields"
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (! Regex.IsMatch(Phone_txt.Text.Trim(), motif)) { 


            
                    MessageBox.Show("Please Enter Valid Phone Number XXX-XXX-XXXX or XXXXXXXXXX", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (conn.State != ConnectionState.Open)
                {
                    try
                    {

                        conn.Open();



                        //To check if the user is registered
                        String selectname = "Select count(id) from members where PhoneNumber=@PhoneNumber and FirstName=@FirstName";
                        using (SqlCommand checkuser = new SqlCommand(selectname, conn))
                        {
                            checkuser.Parameters.AddWithValue("@FirstName", First_txt.Text.Trim());
                            checkuser.Parameters.AddWithValue("@PhoneNumber", Phone_txt.Text.Trim());
                            int count = (int)checkuser.ExecuteScalar();

                            if (count >= 1)
                            {
                                MessageBox.Show(First_txt.Text.Trim() + " is already Registered", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                clearFields();
                            }
                            else
                            {
                                DateTime today = DateTime.Today;
                                string insertData = "insert into Members(FirstName,MiddleName,LastName,PhoneNumber,Gender,Status,RegisteredDate) values(@FirstName,@MiddleName,@LastName,@PhoneNumber,@Gender,@Status,@Date)";
                                using (SqlCommand cmd = new SqlCommand(insertData, conn))
                                {
                                    cmd.Parameters.AddWithValue("@FirstName", First_txt.Text.Trim());
                                    cmd.Parameters.AddWithValue("@MiddleName", Middle_txt.Text.Trim());
                                    cmd.Parameters.AddWithValue("@LastName", Last_txt.Text.Trim());
                                    cmd.Parameters.AddWithValue("@PhoneNumber", Phone_txt.Text.Trim());
                                    cmd.Parameters.AddWithValue("@Gender", Gender_txt.Text.Trim());
                                    cmd.Parameters.AddWithValue("@Status", Status_txt.Text.Trim());
                                    cmd.Parameters.AddWithValue("@Date", today);
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Added Successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    displayMembers();
                                    clearFields();
                                    dashboard1 d=new dashboard1();
                                    d.displayTotal();
                                    

                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void clearFields()
        {
            First_txt.Text = "";
            Middle_txt.Text = "";
            Last_txt.Text = "";
            Gender_txt.SelectedIndex = -1;
            Phone_txt.Text = "";
            Status_txt.SelectedIndex = -1;
          
        }
        //To check if the user is Updated
        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (First_txt.Text == ""
               || Middle_txt.Text == ""
               || Last_txt.Text == ""
               || Phone_txt.Text == ""
               || Gender_txt.Text == ""
               || Status_txt.Text == ""
              )

            {
                MessageBox.Show("Please Select from the table"
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!Regex.IsMatch(Phone_txt.Text.Trim(), motif))
            {



                MessageBox.Show("Please Enter Valid Phone Number XXX-XXX-XXXX or XXXXXXXXXX", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            { 
            DialogResult check = MessageBox.Show("Are you sure you want to UPDATE " +
                          "?", "Confirmation Message"
                        , MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (check == DialogResult.Yes)
                    {
                        try
                        {
                            conn.Open();
                            DateTime today = DateTime.Today;

                            string updateData = "UPDATE Members SET FirstName = @FirstName,MiddleName = @MiddleName,LastName = @LastName " +
                                ", Gender= @Gender, PhoneNumber = @PhoneNumber" +
                                ", Status = @Status  WHERE id = @id";

                            using (SqlCommand cmd = new SqlCommand(updateData, conn))
                            {
                                cmd.Parameters.AddWithValue("@FirstName", First_txt.Text.Trim());
                                cmd.Parameters.AddWithValue("@MiddleName", Middle_txt.Text.Trim());
                                cmd.Parameters.AddWithValue("@LastName", Last_txt.Text.Trim());
                                cmd.Parameters.AddWithValue("@PhoneNumber", Phone_txt.Text.Trim());
                                cmd.Parameters.AddWithValue("@Gender", Gender_txt.Text.Trim());
                                cmd.Parameters.AddWithValue("@Status", Status_txt.Text.Trim());
                                cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();

                                

                                MessageBox.Show("Update successfully!"
                                    , "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        displayMembers();
                        clearFields();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex
                            , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cancelled."
                            , "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            

       }

       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                id = (int)row.Cells[0].Value;
                First_txt.Text = row.Cells[1].Value.ToString();
                Middle_txt.Text = row.Cells[2].Value.ToString();
                Last_txt.Text = row.Cells[3].Value.ToString();
                Gender_txt.Text = row.Cells[4].Value.ToString();
                Phone_txt.Text = row.Cells[5].Value.ToString();
                Status_txt.Text = row.Cells[7].Value.ToString();
            }
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {

            if (First_txt.Text == ""
              || Middle_txt.Text == ""
              || Last_txt.Text == ""
              || Phone_txt.Text == ""
              || Gender_txt.Text == ""
              || Status_txt.Text == ""
             )

            {
                MessageBox.Show("Please Select from the Table"
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Are you sure you want to Delete " +
                        "?", "Confirmation Message"
                      , MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (check == DialogResult.Yes)
                {
                    try
                    {
                        conn.Open();


                        string DeleteData = "Delete from Members  WHERE id = @id";

                        using (SqlCommand cmd = new SqlCommand(DeleteData, conn))
                        {

                            cmd.Parameters.AddWithValue("@id", id);

                            cmd.ExecuteNonQuery();



                            MessageBox.Show("Deleted successfully!"
                                , "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            displayMembers();
                            clearFields();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex
                        , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Cancelled."
                        , "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Members1_Load(object sender, EventArgs e)
        {

        }

      




    }
}
    

      
