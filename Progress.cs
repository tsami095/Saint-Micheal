﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sain_Micheal_DataBase
{
    public partial class Progress : Form
    {
        public Progress()
        {
            InitializeComponent();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
          
        }

        private void Progress_Load(object sender, EventArgs e)
        {
            this.timer1.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Increment(1);
            if (progressBar1.Value >= progressBar1.Maximum)
            {
                timer1.Stop();
                this.Hide();
                
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
