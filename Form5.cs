using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTKRbITKA
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testDBDataSet.Bydjet". При необходимости она может быть перемещена или удалена.
            this.bydjetTableAdapter.Fill(this.testDBDataSet.Bydjet);

        }

        /*void My_meth(string[,] SquarePolib)
        {
            SqlConnection sqlConnection = null;
            SqlDataAdapter adapter = null;
            DataTable table = null;

            dataGridView1.ColumnCount = 6;//количество столбцов попытаться сделать в форме таблицу дата грид вью
            dataGridView1.RowCount = 6; //количество строк
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = SquarePolib[i, j]; //Заполнили dataGridView1 квадратом полибия
                }
            }
            adapter.Fill(table);
            dataGridView1.DataSource = table;*/
    }

}

