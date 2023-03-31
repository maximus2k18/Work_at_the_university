using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTKRbITKA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void номер2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form F2 = new Form2();
            F2.Show();
        }
        private void номер1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form F1 = new Otkritka();
            F1.Show();
        }

        private void Form1_Load(object sender, MouseEventArgs e)
        {
            if ((WindowState == FormWindowState.Maximized) & (e.Button == MouseButtons.Left))
            // если форма развернута и нажата левая клавиша мыши
            {
                WindowState = FormWindowState.Normal; // сделать нормальную форму
            }
            else if (e.Button == MouseButtons.Left)
                WindowState = FormWindowState.Maximized; // развернуть форму
        }

        private void номер3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 F3 = new Form3();
            F3.Show();
        }

        private void номер4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 F4 = new Form4();
            F4.Show();
        }

        private void оПЗ2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 F6 = new Form6();
            F6.Show();
        }

        private void квадратПолибияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 F8 = new Form8();
            F8.Show();
        }

        public void бДToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            My_sql F9 = new My_sql();
            F9.Show();
        }

        private void курсоваяToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void плейфераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 F9 = new Form9();
            F9.Show();
        }
    }








    class OPZ
    {
        public int operand;  // число
        public string operacia; // операция 
        public int rang;        // ранг операции

        public void Add(string simbol)
        {
            if ("+-*/()".IndexOf(simbol) != -1)
            {
                operacia = simbol;
                rang = FindRang(simbol);
            }
            else if ("0123456789".IndexOf(simbol) != -1)
            {
                operand = Convert.ToInt32(simbol);
                operacia = "ch";
            }


        }
        private int FindRang(string simbol)
        {
            if ((simbol == ")") || (simbol == "("))
            {
                return 1;
            }
            else if ((simbol == "+") || (simbol == "-"))
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
    }
}