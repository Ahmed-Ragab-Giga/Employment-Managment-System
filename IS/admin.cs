using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace IS
{
    public partial class admin : UserControl
    {
        public admin()
        {
            InitializeComponent();
        }

       // lOGIN BUTTON
        private void button1_Click(object sender, EventArgs e)
        {
            string mycon = "Data Source = AHMED\\AHMED; Initial Catalog = job portal system; Integrated Security = True";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cod = new SqlCommand("Select * from ADMIN where username='" + this.textBox1.Text + "' and password ='" + this.textBox2.Text + "';", con);
            SqlDataReader myreader;
            myreader = cod.ExecuteReader();
            int count = 0;
            while (myreader.Read())
            {
                count = count + 1;
            }
            if (count == 1)
            {
                panel1.Visible = true;
            }
            else
            {
                MessageBox.Show("Username Or Password Is not Correct ... Try Again");
            }
        }
        // Add Admin Button
        private void button2_Click(object sender, EventArgs e)
        {
            anthor_admin s = new anthor_admin();
            s.Show();
        }
        // Employee Button
        private void button3_Click(object sender, EventArgs e)
        {
            admin_employee d = new admin_employee();
            d.Show();
        }
        // employer button
        private void button4_Click(object sender, EventArgs e)
        {
            admin_employer f = new admin_employer();
            f.Show();
        }
        // company button
        private void button5_Click(object sender, EventArgs e)
        {
            admin_company a = new admin_company();
            a.Show();
        }
        // Department
        private void button6_Click(object sender, EventArgs e)
        {
            Department d = new Department();
            d.Show();
        }
    }
}
