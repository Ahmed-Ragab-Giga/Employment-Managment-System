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
    public partial class admin_company : Form
    {
        public admin_company()
        {
            InitializeComponent();
            cfillchecked();
        }
        // Fill Checkbox for course from Database
        void cfillchecked()
        {

            string mycon = "Data Source = AHMED\\AHMED; Initial Catalog = job portal system; Integrated Security = True";
            
            string queryy = "select * from Department;";
            SqlConnection con = new SqlConnection(mycon);
            SqlCommand cmd = new SqlCommand(queryy, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string u = (string)reader["name"].ToString();
                    checkedListBox1.Items.Add(u);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }
        // ADD Button
        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string r1 = null;
            string r2 = null;
            string r3 = null;
            string r4 = null;
            string r5 = null;
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                if (i == 0)
                    r1 = checkedListBox1.CheckedItems[i].ToString();
                if (i == 1)
                    r2 = checkedListBox1.CheckedItems[i].ToString();
                if (i == 2)
                    r3 = checkedListBox1.CheckedItems[i].ToString();
                if (i == 3)
                    r4 = checkedListBox1.CheckedItems[i].ToString();
                if (i == 4)
                    r5 = checkedListBox1.CheckedItems[i].ToString();
            }
            string mycon = "Data Source = AHMED\\AHMED; Initial Catalog = job portal system; Integrated Security = True";
            SqlConnection conn = new SqlConnection(mycon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select name from [Company]", conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader re = cmd.ExecuteReader();
            while (re.Read())
            {
                if (re["name"].ToString() == textBox2.Text)
                {
                    flag = true;
                    break;
                }
            }

            re.Close();
            if (flag == true)
                MessageBox.Show(this, "\n\n\tThe Company Name is already Exist ");
            else
            {
                string query = "insert into Company (name,address) Values ('" + this.textBox2.Text + "','" + this.textBox9.Text + "') ";
                SqlCommand cmd1 = new SqlCommand(query, conn);
                try
                {
                    //conn.Open();
                    cmd1.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message);
                }
                string q1 = "select Comp_ID from Company where name = '" + this.textBox2.Text + "'";
                SqlCommand cmd0 = new SqlCommand(q1, conn);
                SqlDataReader d = cmd0.ExecuteReader();
                int index = 0;
                while (d.Read())
                {
                    index = int.Parse(d[0].ToString());
                }
                d.Close();
                string Q = "Insert into Company_Dept (company_id,dep1,dep2,dep3,dep4,dep5) Values ('" + index + "','" + r1 + "','" + r2 + "','" + r3 + "','" + r4 + "','" + r5 + "') ";
                SqlCommand cmd2 = new SqlCommand(Q, conn);
                try
                {
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show(this, "\n\n\tNew Company Add Succefully ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message);
                }
            }
            conn.Close();

        
        }
        // Delete Button
        private void button2_Click(object sender, EventArgs e)
        {

            string mycon = "Data Source = AHMED\\AHMED; Initial Catalog = job portal system; Integrated Security = True";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            
            string q1 = "select Comp_ID from Company where name = '" + this.textBox2.Text + "';";
            SqlCommand cmd0 = new SqlCommand(q1, con);
            SqlDataReader d = cmd0.ExecuteReader();
            int index = 0;
            while (d.Read())
            {
                index = int.Parse(d[0].ToString());
            }
            d.Close();
            string query = "Delete from Company_Dept where company_id='" + index + "' ;";
            SqlCommand cmd1 = new SqlCommand(query, con);
            cmd1.CommandText = query;
            cmd1.Connection = con;
            cmd1.ExecuteNonQuery();
            con.Close();
            con.Open();
            string Q = "Delete from Company where Comp_ID ='" + index + "';";
            SqlCommand cmd2 = new SqlCommand(Q, con);
            cmd2.CommandText = Q;
            cmd2.Connection = con;
            cmd2.ExecuteNonQuery();
            MessageBox.Show(this, "\n\n\t Company " + textBox2.Text + " Delete Succefully ");

        }
        // update Button
        private void button3_Click(object sender, EventArgs e)
        {

            string r1 = null;
            string r2 = null;
            string r3 = null;
            string r4 = null;
            string r5 = null;
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                if (i == 0)
                    r1 = checkedListBox1.CheckedItems[i].ToString();
                if (i == 1)
                    r2 = checkedListBox1.CheckedItems[i].ToString();
                if (i == 2)
                    r3 = checkedListBox1.CheckedItems[i].ToString();
                if (i == 3)
                    r4 = checkedListBox1.CheckedItems[i].ToString();
                if (i == 4)
                    r5 = checkedListBox1.CheckedItems[i].ToString();


            }

            string mycon = "Data Source = AHMED\\AHMED; Initial Catalog = job portal system; Integrated Security = True";
            SqlConnection conn = new SqlConnection(mycon);
            string query = "Update Company set address='" + this.textBox9.Text + "' Where name='" + this.textBox2.Text + "';";
            SqlCommand cmd1 = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                cmd1.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
            string q1 = "select Comp_ID from Company where name = '" + this.textBox2.Text + "'";
            SqlCommand cmd0 = new SqlCommand(q1, conn);
            SqlDataReader d = cmd0.ExecuteReader();
            int index = 0;
            while (d.Read())
            {
                index = int.Parse(d[0].ToString());
            }
            d.Close();
            string Q = "update Company_Dept set dep1='" + r1 + "',dep2='" + r2 + "',dep3='" + r3 + "',dep4='" + r4 + "',dep5='" + r5 + "' where company_id='" + index + "';";
            SqlCommand cmd2 = new SqlCommand(Q, conn);
            try
            {
                cmd2.ExecuteNonQuery();
                MessageBox.Show(this, "\n\n\t Company Edit Succefully ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
            conn.Close();
        }

    }
}
