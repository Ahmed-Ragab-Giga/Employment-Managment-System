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
    public partial class admin_employee : Form
    {
        public admin_employee()
        {
            InitializeComponent();
        }
        // Add Employee Button
        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string mycon = "Data Source = AHMED\\AHMED; Initial Catalog = job portal system; Integrated Security = True";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select username from [Employee]", con);
            bool dep = false;
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
           SqlCommand cmd2 = new SqlCommand("Select Dept_ID from Department", con);
            cmd2.CommandType = CommandType.Text;
            SqlDataReader r = cmd2.ExecuteReader();
            int id = Convert.ToInt32(txtdep.Text);
            while (r.Read())
            {
                int x = (int)r["Dept_ID"];
                if (x == id) 
                {
                    dep = true;
                    break;
                }
            }
            r.Close();
            if (flag == true)
                MessageBox.Show(this, "The Username is already Exist   ");
            else if(dep==false)
            {
                MessageBox.Show(" Dep id not exist");
            }
            else
            {

                string query = "insert into Employee (username ,password, gender,phone,address,email,current_position,Dept_ID,name) Values ('" + this.textBox1.Text + "','" + this.textBox4.Text + "','" + this.textBox10.Text + "','" + this.textBox8.Text + "','" + this.textBox9.Text + "','" + this.textBox6.Text + "','" + this.textBox3.Text + "','" + this.txtdep.Text + "','" + this.textBox2.Text + "') ";
                SqlCommand cmd1 = new SqlCommand(query, con);
                SqlDataReader reader;


                reader = cmd1.ExecuteReader();
                MessageBox.Show(this, "\n\n\tNew Employee Add Succefully");
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
            string q1 = "select Emp_ID from Employee where username = '" + this.textBox1.Text + "';";
            SqlCommand cmd0 = new SqlCommand(q1, con);
            SqlDataReader d = cmd0.ExecuteReader();
            int index = 0;
            while (d.Read())
            {
                index = int.Parse(d[0].ToString());
            }
            d.Close();
            string query = "Delete from Employee where Emp_ID='" + index + "' ;";
            SqlCommand cmd1 = new SqlCommand(query, con);
            cmd1.CommandText = query;
            cmd1.Connection = con;
            cmd1.ExecuteNonQuery();
            MessageBox.Show("Employee Delete Sucecfully");
            con.Close();

        }
        // upadate Button
        private void button3_Click(object sender, EventArgs e)
        {

            string mycon = "Data Source = AHMED\\AHMED; Initial Catalog = job portal system; Integrated Security = True";
            SqlConnection conn = new SqlConnection(mycon);
            string query = "Update Employee set password='" + this.textBox4.Text + "',name='" + this.textBox2.Text + "',email='" + this.textBox6.Text +"',gender='" + this.textBox10.Text + "',address='" + this.textBox9.Text + "',dept_id='" + this.txtdep.Text + "',current_position='" + this.textBox3.Text + "',phone='" + this.textBox4.Text + "'  Where username='" + this.textBox1.Text + "';";
            SqlCommand cmd1 = new SqlCommand(query, conn);
            conn.Open();
  
                cmd1.ExecuteNonQuery();

            MessageBox.Show("Employee edit Sucecfully");
            conn.Close();
        }
    }
}
