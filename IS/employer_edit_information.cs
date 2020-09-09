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
    public partial class employer_edit_information : Form
    {
        public employer_edit_information()
        {
            InitializeComponent();
        }
        // Edit Information
        private void button3_Click(object sender, EventArgs e)
        {
            string mycon = "Data Source =.; Initial Catalog = job portal system; Integrated Security = True";
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
