using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace OTKRbITKA
{
    public partial class My_sql : Form
    {
        private SqlConnection sqlConnection = null;
        public My_sql()
        {
            InitializeComponent();
        }
        private void My_sql_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testDBDataSet.Bydjet". При необходимости она может быть перемещена или удалена.
            this.bydjetTableAdapter.Fill(this.testDBDataSet.Bydjet);
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            sqlConnection.Open();
            if (sqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("Подключение успешно!");
            }
        }
    }
}
