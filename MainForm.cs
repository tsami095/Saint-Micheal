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
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Contexts;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;



namespace Sain_Micheal_DataBase
{
    public partial class MainForm : Form
    {
       
        public MainForm()
        {
            InitializeComponent();
            
        }
       

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            DialogResult dt = MessageBox.Show("Are you sure you want to log out?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dt == DialogResult.Yes)
            {
                Form1 login = new Form1();
                login.Show();
                this.Hide();
            }
        }

       

        private void Dashboard_btn_Click(object sender, EventArgs e)
        {




        }

        private void AddEmployee_btn_Click(object sender, EventArgs e)
        {




        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dashboard1_Load(object sender, EventArgs e)
        {

        }

        private void addEmployee1_Load(object sender, EventArgs e)
        {

        }

        private void dashboard11_Load(object sender, EventArgs e)
        {

        }



        private void button2_Click(object sender, EventArgs e)
        {
            dashboard11.Visible = true;
            members11.Visible = false;
        
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dashboard11.Visible = false;
            members11.Visible = true;
            dashboard11.displayActive();
            dashboard11.displayInActive();
            dashboard11.displayTotal();
        }

        private void members11_Load(object sender, EventArgs e)
        {


        }

        private void members11_Load_1(object sender, EventArgs e)
        {

        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; 
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to Close the Window?","Close",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                this.Hide();
            }
            else 
            {
                e.Cancel = true;
            }
        }
    }
}