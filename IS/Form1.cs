using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; 

namespace IS
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
       
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        // ADMIN bUTTON
        private void button1_Click(object sender, EventArgs e)
        {
            
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new admin());
        }
        // Employee Register
        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new employee_reg());
        }
        // employee Button
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new Employee());
        }
        // Employer Button
        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new Employerr());
        }
        // Employer Register
        private void button5_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new employer_reg());
        }
    }
}
