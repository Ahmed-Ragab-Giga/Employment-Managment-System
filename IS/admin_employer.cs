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
    public partial class admin_employer : Form
    {
        public admin_employer()
        {
            InitializeComponent();
        }
        // aDD BUTTON
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
                MessageBox.Show(this, "\n\n\tNew Employer Add Succefully");
                while (reader.Read())
                {

                }


            }
        }
        // Delete Button
        private void button2_Click(object sender, EventArgs e)
        {
            string mycon = "Data Source = AHMED\\AHMED; Initial Catalog = job portal system; Integrated Security = True";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            string q1 = "select Employer_ID from Employer where username = '" + this.textBox1.Text + "';";
            SqlCommand cmd0 = new SqlCommand(q1, con);
            SqlDataReader d = cmd0.ExecuteReader();
            int index = 0;
            while (d.Read())
            {
                index = int.Parse(d[0].ToString());
            }
            d.Close();
            string query = "Delete from Employer where Employer_ID='" + index + "' ;";
            SqlCommand cmd1 = new SqlCommand(query, con);
            cmd1.CommandText = query;
            cmd1.Connection = con;
            cmd1.ExecuteNonQuery();
            MessageBox.Show("Employer Delete Sucecfully");
            con.Close();
        }
        // Update Button
        private void button3_Click(object sender, EventArgs e)
        {
            string mycon = "Data Source = AHMED\\AHMED; Initial Catalog = job portal system; Integrated Security = True";
            SqlConnection conn = new SqlConnection(mycon);
            string query = "Update Employer set password='" + this.textBox4.Text + "',name='" + this.textBox2.Text + "',gender='" + this.textBox10.Text + "',address='" + this.textBox9.Text + "',phone='" + this.textBox8.Text + "'  Where username='" + this.textBox1.Text + "';";
            SqlCommand cmd1 = new SqlCommand(query, conn);
            conn.Open();
            try
            {

                cmd1.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
            MessageBox.Show("Employer edit Sucecfully");
            conn.Close();
        }
    }
}
