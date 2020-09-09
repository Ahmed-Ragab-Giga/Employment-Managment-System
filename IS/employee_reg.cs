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
    public partial class employee_reg : UserControl
    {
        public employee_reg()
        {
            InitializeComponent();
        }
        // Register Button
        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string mycon = "Data Source = AHMED\\AHMED; Initial Catalog = job portal system; Integrated Security = True";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select username from [Employee]", con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader re = cmd.ExecuteReader();
            while (re.Read())
            {
                // Check If The Username Is Already Exist
                if (re["username"].ToString() == textBox1.Text)
                {
                    flag = true;
                    break;
                }
            }

            re.Close();
            if (flag == true)
                MessageBox.Show(this, "The Username is already Exist ");
            else
            {

                string query = "insert into Employee (username ,password, gender,phone,address,email,current_position,Dept_ID,name) Values ('" + this.textBox1.Text + "','" + this.textBox4.Text + "','" + this.textBox10.Text + "','" + this.textBox8.Text + "','" + this.textBox9.Text + "','" + this.textBox6.Text + "','" + this.textBox3.Text + "','" + this.textBox7.Text + "','" + this.textBox2.Text + "') ";
                SqlCommand cmd1 = new SqlCommand(query, con);
                SqlDataReader reader;


                reader = cmd1.ExecuteReader();
                MessageBox.Show(this, "Register Complete");
                while (reader.Read())
                {

                }

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
