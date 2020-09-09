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
    public partial class employee_edit_information : Form
    {
        public employee_edit_information()
        {
            InitializeComponent();
        }
        // Update Button
        private void button3_Click(object sender, EventArgs e)
        {
            string mycon = "Data Source = AHMED\\AHMED; Initial Catalog = job portal system; Integrated Security = True";
            SqlConnection conn = new SqlConnection(mycon);
            string query = "Update Employee set password='" + this.textBox4.Text + "',name='" + this.textBox2.Text + "',email='" + this.textBox6.Text + "',gender='" + this.textBox10.Text + "',address='" + this.textBox9.Text + "',dept_id='" + this.textBox7.Text + "',current_position='" + this.textBox3.Text + "',phone='" + this.textBox4.Text + "'  Where username='" + this.textBox1.Text + "';";
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
            MessageBox.Show("Employee edit Sucecfully");
            conn.Close();
        }
    }
}
