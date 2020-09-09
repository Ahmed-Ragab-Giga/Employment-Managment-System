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
    public partial class Employerr : UserControl
    {
        public Employerr()
        {
            InitializeComponent();
        }
        // login Button
        private void button4_Click(object sender, EventArgs e)
        {
            string mycon = "Data Source = AHMED\\AHMED; Initial Catalog = job portal system; Integrated Security = True";

            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cod = new SqlCommand("Select * from Employer where username='" + this.textBox1.Text + "' and password ='" + this.textBox2.Text + "';", con);
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
        // show Edit Information panel
        private void button9_Click(object sender, EventArgs e)
        {
            employer_edit_information ee = new employer_edit_information();
            ee.Show();
        }
        // show list of employee panel
        private void button8_Click(object sender, EventArgs e)
        {
            list_of_employee ee = new list_of_employee();
            ee.Show();
        }
        // add new job panel
        private void button7_Click(object sender, EventArgs e)
        {
            Add_New_Job ee = new Add_New_Job();
            ee.Show();
        }
    }
}
