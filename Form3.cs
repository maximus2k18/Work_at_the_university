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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button5.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = false;
            textBox3.Visible = false;
            kolvo_qwest.Visible = false;
            label4.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label8.Visible = true;
            DoAllDirtJob();
        }
        Random rand = new Random();
        int PrOtv = 0;
        int schPO = 0;
        int schNO = 0;
        int z = 0;
        public int KolPrim()
        {
            int k_p = Convert.ToInt32(textBox3.Text);
            return k_p;
        }
        public string Virazenie()
        {
            string Primer;
            do
            {
                int Kol_Operacs = rand.Next(1, 4); 
                int Kol_Operands = Kol_Operacs + 1; 
                string[] operacs = new string[Kol_Operacs];
                int[] PlusOrMinus = new int[Kol_Operacs];
                for (int i = 0; i < Kol_Operacs; i++)
                {
                    PlusOrMinus[i] = rand.Next(0, 2);
                    if (PlusOrMinus[i] == 0)
                    {
                        operacs[i] = "+";
                    }
                    else
                    {
                        operacs[i] = "-";
                    }
                }
                int[] chisla = new int[Kol_Operands];
                for (int i = 0; i < Kol_Operands; i++)
                {
                    chisla[i] = rand.Next(1, 100);
                }
                Primer = Convert.ToString(chisla[0]);
                PrOtv = chisla[0];
                for (int i = 0; i < Kol_Operacs; i++)
                {
                    Primer += operacs[i] + chisla[i + 1];
                    if (operacs[i] == "+")
                    {
                        PrOtv += chisla[i + 1];
                    }
                    else
                    {
                        PrOtv -= chisla[i + 1];
                    }
                }
            } while (PrOtv < 0);

            return Primer;
        }
        public void DoAllDirtJob()
        {
            z = schPO + schNO + 2;
            int PozPrOt = rand.Next(1, 5);  // получаем случайную позицию правильного ответа от 1 до 4
            label8.Text = Virazenie();
            for (int i = 1; i < 5; i++)
            {
                if (PozPrOt == i)
                {
                    if (i == 1)
                    {
                        button1.Text = Convert.ToString(PrOtv);
                    }
                    else if (i == 2)
                    {
                        button2.Text = Convert.ToString(PrOtv);
                    }
                    else if (i == 3)
                    {
                        button3.Text = Convert.ToString(PrOtv);
                    }
                    else
                    {
                        button4.Text = Convert.ToString(PrOtv);
                    }
                }
                else
                {
                    if (i == 1)
                    {
                        button1.Text = Convert.ToString(PrOtv + rand.Next(1, 3));
                    }
                    else if (i == 2)
                    {
                        button2.Text = Convert.ToString(PrOtv + rand.Next(3, 5));
                    }
                    else if (i == 3)
                    {
                        button3.Text = Convert.ToString(PrOtv + rand.Next(5, 7));
                    }
                    else
                    {
                        button4.Text = Convert.ToString(PrOtv + rand.Next(7, 9));
                    }
                }
            }
            label1.Text = Convert.ToString(z-1);
            label2.Text = Convert.ToString(schPO);
            label6.Text = Convert.ToString(schNO);
        }

        public string Ocenka()
        {
            double ball;
            ball = Convert.ToDouble(schPO) / Convert.ToDouble(KolPrim()) * 100;
            if (ball > 55 & ball < 70)
            {
                return "Ваша оценка: 3 ";
            }
            else if (ball >= 70 & ball < 85)
            {
                return "Ваша оценка: 4 ";
            }
            else if (ball >= 85)
            {
                return "Ваша оценка: 5 ";
            }
            else
            {
                return "Ваша оценка: 2 ";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == Convert.ToString(PrOtv))
            {
                MessageBox.Show("Правильно");
                schPO++;
                if (z <= KolPrim())
                {
                    DoAllDirtJob();
                }
                else
                {
                    MessageBox.Show(Ocenka());
                    Close();
                }
            }
            else
            {
                schNO++;
                MessageBox.Show("Неправильно");
                if (z <= KolPrim())
                {
                    DoAllDirtJob();
                }
                else
                {
                    MessageBox.Show(Ocenka());
                    Close();
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == Convert.ToString(PrOtv))
            {
                MessageBox.Show("Правильно");
                schPO++;
                if (z <= KolPrim())
                {
                    DoAllDirtJob();
                }
                else
                {
                    MessageBox.Show(Ocenka());
                    Close();
                }
            }
            else
            {
                schNO++;
                MessageBox.Show("Неправильно");
                if (z <= KolPrim())
                {
                    DoAllDirtJob();
                }
                else
                {
                    MessageBox.Show(Ocenka());
                    Close();
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
                if (button3.Text == Convert.ToString(PrOtv))
                {
                    MessageBox.Show("Правильно");
                    schPO++;
                    if (z <= KolPrim())
                    {
                        DoAllDirtJob();
                    }
                    else
                    {
                        MessageBox.Show(Ocenka());
                        Close();
                    }
                }
                else
                {
                    schNO++;
                    MessageBox.Show("Неправильно");
                    if (z <= KolPrim())
                    {
                        DoAllDirtJob();
                    }
                    else
                    {
                        MessageBox.Show(Ocenka());
                        Close();
                    }

                }
            }

        private void button4_Click(object sender, EventArgs e)
        {
                if (button4.Text == Convert.ToString(PrOtv))
                {
                    MessageBox.Show("Правильно");
                    schPO++;
                    if (z <= KolPrim())
                    {
                        DoAllDirtJob();
                    }
                    else
                    {
                        MessageBox.Show(Ocenka());
                        Close();
                    }
                }
                else
                {
                    schNO++;
                    MessageBox.Show("Неправильно");
                    if (z <= KolPrim())
                    {
                        DoAllDirtJob();
                    }
                    else
                    {
                        MessageBox.Show(Ocenka());
                        Close();
                    }

                }
            }
        }
}
    
