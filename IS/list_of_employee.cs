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
    public partial class list_of_employee : Form
    {
        public list_of_employee()
        {
            InitializeComponent();
            string mycon = "Data Source =.; Initial Catalog = job portal system; Integrated Security = True";
            string sql = "SELECT * FROM Employee";
            SqlConnection connection = new SqlConnection(mycon);
            connection.Open();
            SqlCommand s = new SqlCommand(sql, connection);
            SqlDataAdapter sa = new SqlDataAdapter(s);
            DataTable da = new DataTable();
            sa.Fill(da);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = da;
            SqlCommandBuilder sb = new SqlCommandBuilder(sa);
            dataGridView1.DataSource = bsource;
            sa.Update(da);
            connection.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
