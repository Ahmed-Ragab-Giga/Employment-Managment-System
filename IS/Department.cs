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
    public partial class Department : Form
    {
        public Department()
        {
            InitializeComponent();
        }
        // Add new Department button
        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string mycon = "Data Source = AHMED\\AHMED; Initial Catalog = job portal system; Integrated Security = True";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select name from [Department]", con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader re = cmd.ExecuteReader();
            while (re.Read())
            {
                // Check If The Username Is Already Exist
                if (re["name"].ToString() == textBox2.Text)
                {
                    flag = true;
                    break;
                }
            }

            re.Close();
            if (flag == true)
                MessageBox.Show(this, "The Department Name is already Exist ");
            else
            {

                string query = "insert into Department (name ,Comp_ID) Values ('" + this.textBox2.Text + "','" + this.textBox1.Text + "') ";
                SqlCommand cmd1 = new SqlCommand(query, con);
                SqlDataReader reader;


                reader = cmd1.ExecuteReader();
                MessageBox.Show(this, "\n\n\tNew Department Add Succefully");
                while (reader.Read())
                {

                }


            }
        }
        // Delete Department button
        private void button2_Click(object sender, EventArgs e)
        {
            string mycon = "Data Source = AHMED\\AHMED; Initial Catalog = job portal system; Integrated Security = True";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            string q1 = "select Dept_ID from Department where name = '" + this.textBox2.Text + "';";
            SqlCommand cmd0 = new SqlCommand(q1, con);
            SqlDataReader d = cmd0.ExecuteReader();
            int index = 0;
            while (d.Read())
            {
                index = int.Parse(d[0].ToString());
            }
            d.Close();
            string query = "Delete from Department where Dept_ID='" + index + "' ;";
            SqlCommand cmd1 = new SqlCommand(query, con);
            cmd1.CommandText = query;
            cmd1.Connection = con;
            cmd1.ExecuteNonQuery();
            MessageBox.Show("Department Delete Sucecfully");
            con.Close();
        }
        // Update Department Button
        private void button3_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string mycon = "Data Source = AHMED\\AHMED; Initial Catalog = job portal system; Integrated Security = True";
            SqlConnection conn = new SqlConnection(mycon);
            conn.Open(); 
            SqlCommand cmd = new SqlCommand("Select name from [Department]", conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader re = cmd.ExecuteReader();
            while (re.Read())
            {
                // Check If The name of department Is Already Exist
                if (re["name"].ToString() == textBox2.Text)
                {
                    flag = true;
                    break;
                }
            }

            re.Close();
        /**/    conn.Close();
            if (flag == true)
                MessageBox.Show(this, "The Department Name is already Exist ");
            else
            {
                string query = "Update Employer set name='" + this.textBox2.Text + "',comp_id='" + this.textBox1.Text + "' Where name='" + this.textBox2.Text + "';";
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
                MessageBox.Show("Department Edit Sucecfully");
            }
            conn.Close();
            
        }
    }
}
