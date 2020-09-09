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
    public partial class employer_reg : UserControl
    {
        public employer_reg()
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
            SqlCommand cmd = new SqlCommand("Select username from [Employer]", con);
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

                string query = "insert into Employer (username ,password, gender,phone,address,name) Values ('" + this.textBox1.Text + "','" + this.textBox4.Text + "','" + this.textBox10.Text + "','" + this.textBox8.Text + "','" + this.textBox9.Text + "','" + this.textBox2.Text + "') ";
                SqlCommand cmd1 = new SqlCommand(query, con);
                SqlDataReader reader;


                reader = cmd1.ExecuteReader();
                MessageBox.Show(this, "Register Complete");
                while (reader.Read())
                {

                }

            }
        }
    }
}
