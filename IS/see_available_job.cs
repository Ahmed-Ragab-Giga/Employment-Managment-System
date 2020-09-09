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
    public partial class see_available_job : Form
    {
        public see_available_job()
        {
            InitializeComponent();
            string mycon = "Data Source = AHMED\\AHMED; Initial Catalog = job portal system; Integrated Security = True";
            string sql = "SELECT * FROM [Vacant job]";
            SqlConnection connection = new SqlConnection(mycon);
            connection.Open();
            SqlCommand s = new SqlCommand(sql, connection);
            // Read All DATA FROM SQL IN Same Time
            SqlDataAdapter sa = new SqlDataAdapter(s);
            // جدول وهمى بخزن فيه المعلومات الى بخدها من الـ sql adapter
            DataTable da = new DataTable();
            sa.Fill(da);
             // بخزن الحاجات الى فى الdata table و بنظمها و بعمل عليها عمليات
            BindingSource bsource = new BindingSource();
            bsource.DataSource = da;
            // بنفذ الadapter و بنفذ ال biniding source
            SqlCommandBuilder sb = new SqlCommandBuilder(sa);
            dataGridView1.DataSource = bsource;
            sa.Update(da);
            connection.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void see_available_job_Load(object sender, EventArgs e)
        {

        }
    }
}
