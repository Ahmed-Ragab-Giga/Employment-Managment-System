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
    public partial class Add_New_Job : Form
    {
        public Add_New_Job()
        {
            InitializeComponent();
        }
        // add button
        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string mycon = "Data Source = AHMED\\AHMED; Initial Catalog = job portal system; Integrated Security = True";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select name from [Vacant job]", con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader re = cmd.ExecuteReader();
            while (re.Read())
            {
                // Check If The name Is Already Exist
                if (re["name"].ToString() == textBox1.Text)
                {
                    flag = true;
                    break;
                }
            }

            re.Close();
            if (flag == true)
                MessageBox.Show(this, "The name is already Exist ");
            else
            {

                string query = "insert into [Vacant job] (name ,number_of_avaible_jop) Values ('" + this.textBox2.Text + "','" + this.textBox1.Text + "') ";
                SqlCommand cmd1 = new SqlCommand(query, con);
                SqlDataReader reader;


                reader = cmd1.ExecuteReader();
                MessageBox.Show(this, "\n\n\tNew Vacant job Add Succefully");
                while (reader.Read())
                {

                }


            }
        }
    }
}
