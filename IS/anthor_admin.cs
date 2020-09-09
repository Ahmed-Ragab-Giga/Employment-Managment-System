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
    public partial class anthor_admin : Form
    {
        public anthor_admin()
        {
            InitializeComponent();
        }
        // ADD NEW ADMIN
        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string mycon = "Data Source = AHMED\\AHMED; Initial Catalog = job portal system; Integrated Security = True";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select username from admin", con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader re = cmd.ExecuteReader();
            while (re.Read())
            {
                if (re["username"].ToString() == textBox1.Text)
                {
                    flag = true;
                    break;
                }
            }

            re.Close();
            if (flag == true)
                MessageBox.Show( "User Name Is Already Exist");
            else
            {
                string query = "insert into admin (username,password) Values ('" + this.textBox1.Text + "','" + this.textBox2.Text + "') ";
                SqlCommand cmd1 = new SqlCommand(query, con);
                    cmd1.ExecuteNonQuery();

                MessageBox.Show("New Admin Add Succefully");
            }
    }
    }
}
