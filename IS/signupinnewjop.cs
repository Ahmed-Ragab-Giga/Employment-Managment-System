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
    public partial class signupinnewjop : Form
    {
        public signupinnewjop()
        {
            InitializeComponent();
            fillcombo();
        }
        void fillcombo()
        {

            string mycon = "Data Source = AHMED\\AHMED; Initial Catalog = job portal system; Integrated Security = True";
            string queryy = "select * from [Vacant job];";
            SqlConnection con = new SqlConnection(mycon);
            SqlCommand cmd = new SqlCommand(queryy, con);
            SqlDataReader reader;
              con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string u = (string)reader["name"].ToString();
                    comboBox1.Items.Add(u);
                }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

         
            string mycon = "Data Source = AHMED\\AHMED; Initial Catalog = job portal system; Integrated Security = True";
            string queryy = "select * from [Vacant job] where name='" + comboBox1.Text + "';";
            SqlConnection con = new SqlConnection(mycon);
            SqlCommand cmd = new SqlCommand(queryy, con);
            SqlDataReader reader;
            con.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string av = (string)reader["V_ID"].ToString();
                label4.Visible = true;
                string id = (string)reader["number_of_avaible_jop"].ToString();
                label2.Visible = true;

                label4.Text = id;
                label2.Text = av;
                
            }

            reader.Close();
        }
        // Sign up Button
        private void button1_Click(object sender, EventArgs e)
        {
            string mycon = "Data Source = AHMED\\AHMED; Initial Catalog = job portal system; Integrated Security = True";

            string q1 = "select number_of_avaible_jop from [Vacant job] where name = '" + this.comboBox1.Text + "'";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd0 = new SqlCommand(q1, con);
            SqlDataReader d = cmd0.ExecuteReader();
            int index = 0;
            while (d.Read())
            {
                index = int.Parse(d["number_of_avaible_jop"].ToString());
            }
            d.Read();
            con.Close();
            if(index>0)
            {
               
                string myconn = "Data Source = AHMED\\AHMED; Initial Catalog = job portal system; Integrated Security = True";

               
                SqlConnection conn = new SqlConnection(myconn);
                conn.Open();
                index--;
                string query = "update [Vacant job] set number_of_avaible_jop ='" + index + "'";
                SqlCommand cmd1 = new SqlCommand(query, conn);
                SqlDataReader reader2;
                reader2 = cmd1.ExecuteReader();
                reader2.Close();
                conn.Close();
                //==================================
                string myconnn = "Data Source = AHMED\\AHMED; Initial Catalog = job portal system; Integrated Security = True";
                SqlConnection connn = new SqlConnection(myconnn);
                connn.Open();
                string queryr = "insert into Vacant_Employee (Emp_ID ,V_ID) Values ('" + this.textBox1.Text + "','" + this.label2.Text + "') ";
                SqlCommand cmd15 = new SqlCommand(queryr, connn);
                SqlDataReader reader15;
                reader15 = cmd15.ExecuteReader();
                MessageBox.Show(this, "Sign Up Done Succefully");
                while (reader15.Read())
                {

                }

            }
            else
            {
                MessageBox.Show("No Enough Jop");
            }



        }

        private void signupinnewjop_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
