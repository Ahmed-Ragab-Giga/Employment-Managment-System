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
    public partial class Employee : UserControl
    {
        public Employee()
        {
            InitializeComponent();
        }
        // Login Button
        private void button4_Click(object sender, EventArgs e)
        {
            string mycon = "Data Source = AHMED\\AHMED; Initial Catalog = job portal system; Integrated Security = True";

            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cod = new SqlCommand("Select * from Employee where username='" + this.textBox1.Text + "' and password ='" + this.textBox2.Text + "';", con);
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
        // Show Edit Information Panel
        private void button9_Click(object sender, EventArgs e)
        {
            employee_edit_information ee = new employee_edit_information();
            ee.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            see_available_job ee = new see_available_job();
            ee.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            showallcompany ee = new showallcompany();
            ee.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            signupinnewjop ee = new signupinnewjop();
            ee.Show();
        }
    }
}
