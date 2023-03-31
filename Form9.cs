using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OTKRbITKA
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }   
        void Table()
        {
            int schet = 0;
            string[,] SquarePolib = new string[6, 6];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    SquarePolib[i, j] = Playfair()[schet].ToString(); //заполнили квадрат введенными и оставшимися символами из алфавита
                    schet++;
                }
            }
            dataGridView1.ColumnCount = 6;//количество столбцов
            dataGridView1.RowCount = 6; //количество строк
            dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 18); //шрифт, размер шрифта
            dataGridView1.DefaultCellStyle.ForeColor = Color.Blue; //цвет
            for (int i = 0; i < 6; i++)
            {
                dataGridView1.Columns[i].Width = 37; //задана ширина для каждого из столбцов
            }
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = SquarePolib[i, j]; //Заполнили таблицу квадратом полибия
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Shifr();
            Deshifr_index_to_Frase();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Deshifr_index();
            Deshifr_text();
        }
        public string Key()
        {
            string Key = Convert.ToString(textBox6.Text).ToLower();
            return Key;
        }
        string Alfavit = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя ,.";
        public char[] Playfair()
        {
            string Playfair = Key() + Alfavit;
            return Playfair.Distinct().ToArray();
        }

        private void button4_Click(object sender, EventArgs e)
        {
              textBox1.Text = "";
              textBox2.Text = "";
              textBox3.Text = "";
              textBox4.Text = "";
              textBox5.Text = "";
              textBox6.Text = "";
              textBox7.Text = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Table();
        }
        void Shifr()
        {
            string Input = textBox1.Text.ToLower();
            int t = Input.Length;
            if (t % 2 == 1)
            {
                Input += 'я';
            }
            string Playfair = Key() + Alfavit;
            Playfair = new string(Playfair.Distinct().ToArray());
            for (int i = 0; i < Input.Length; i++)
            {
                if (Playfair.IndexOf(Input[i]) == -1)
                {
                    MessageBox.Show("Некоторые символы введены некорректно, зашифровать можно символы только из таблицы", "Warning!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }

            int schet = 0;
            string[,] SquarePolib = new string[6, 6];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    SquarePolib[i, j] = Playfair[schet].ToString(); //заполнили таблицу введенными и оставшимися символами из алфавита
                    schet++;
                }
            }

            string mssg = "";

            for (int c = 0; c < Input.Count(); c++) //проходим по всем буквам
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (Input[c].ToString() == SquarePolib[i, j]) //если символ из сообщения = символу квадрата, то...
                        {
                            mssg += i.ToString() + j.ToString(); //...получаем индексы(координаты) для этого сообщения
                            break;
                        }
                    }
                }
            }
            textBox2.Text = mssg;

            string s = "";
            int swap_index = 0;
            for (int i = 0, x = 1, y = 2, z = 3; i < mssg.Length; i += 4, x += 4, y += 4, z += 4)
            {
                int one = Convert.ToInt32(mssg.Substring(i, 1));
                int two = Convert.ToInt32(mssg.Substring(x, 1));
                int three = Convert.ToInt32(mssg.Substring(y, 1));
                int four = Convert.ToInt32(mssg.Substring(z, 1));
                if (one == three && two == four)
                {
                    three = 5;
                    four = 2;
                }
                if (one == three && two < four) // строки равны
                {
                    two += 1;
                    if (four == 5)
                    {
                        four = 0;
                    }
                    else
                        four += 1;
                    s += Convert.ToString(one) + Convert.ToString(two) + Convert.ToString(three) + Convert.ToString(four);
                }
                else if (one == three && two > four)
                {
                    two -= 1;
                    if (four == 0)
                    {
                        four = 5;
                    }
                    else
                        two += 1;
                    s += Convert.ToString(one) + Convert.ToString(two) + Convert.ToString(three) + Convert.ToString(four);
                }
                if (two == four && one < three) //на одном столбце
                {
                    one += 1;
                    if (three == 5)
                    {
                        three = 0;
                    }
                    else
                        three += 1;
                    s += Convert.ToString(one) + Convert.ToString(two) + Convert.ToString(three) + Convert.ToString(four);
                }
                else if (two == four && one > three)
                {
                    one -= 1;
                    if (three == 0)
                    {
                        three = 5;
                    }
                    else
                        three -= 1;
                    s += Convert.ToString(one) + Convert.ToString(two) + Convert.ToString(three) + Convert.ToString(four);
                }
                if (one > three && two != four)
                {
                    swap_index = two;
                    two = four;
                    four = swap_index;
                    s += Convert.ToString(one) + Convert.ToString(two) + Convert.ToString(three) + Convert.ToString(four);
                }
                else if (one < three && two != four)
                {
                    swap_index = two;
                    two = four;
                    four = swap_index;
                    s += Convert.ToString(one) + Convert.ToString(two) + Convert.ToString(three) + Convert.ToString(four);
                }
            }
            textBox3.Text = s;
        }
        void Deshifr_index_to_Frase()
        {
            string s = textBox3.Text;
            string index_polib = "";
            for (int i = 0; i < 6;)
            {
                for (int j = 0; j < 6; j++) // Создаем индексы для каждого символа таблицы
                {
                    index_polib += i;
                    index_polib += j + " ";
                    if (j % 5 == 0 && j != 0)
                    {
                        i++;
                    }
                }
            }

            string stroka_simbols = "";
            string Playfair = Key() + Alfavit;
            Playfair = new string(Playfair.Distinct().ToArray());
            for (int i = 0; i < s.Length; i += 2) //проходим по индексам 
            {
                for (int j = 0; j < index_polib.Length; j += 3)//проходим по индексам символов
                {
                    if (index_polib.Substring(j, 2) == s.Substring(i, 2))// если индексы совпали, то...
                    {
                        stroka_simbols += s.Substring(i, 2).Replace(s.Substring(i, 2), Convert.ToString(Playfair[j / 3]));
                        break;                                      //...записываем буквы, соответствующие их индексам из ключа с алфавитом
                    }
                }
            }
            textBox4.Text = stroka_simbols;
        }
        void Deshifr_index()
        {
            string mssg = textBox3.Text;
            string s = "";
            int swap_index = 0;
            for (int i = 0, x = 1, y = 2, z = 3; i < mssg.Length; i += 4, x += 4, y += 4, z += 4)
            {
                int one = Convert.ToInt32(mssg.Substring(i, 1));
                int two = Convert.ToInt32(mssg.Substring(x, 1));
                int three = Convert.ToInt32(mssg.Substring(y, 1));
                int four = Convert.ToInt32(mssg.Substring(z, 1));
                if (one == three && two == four)
                {
                    three = 5;
                    four = 2;
                }
                if (one == three && two < four) // строки равны
                    {
                    two -= 1;
                    if (four == 0)
                    {
                        four = 5;
                    }
                    else
                    four -= 1;
                    s += Convert.ToString(one) + Convert.ToString(two) + Convert.ToString(three) + Convert.ToString(four);
                }
                else if (one == three && two > four)
                {
                    two -= 1;
                    if (four == 0)
                    {
                        four = 5;
                    }
                    else
                        two += 1;
                    s += Convert.ToString(one) + Convert.ToString(two) + Convert.ToString(three) + Convert.ToString(four);
                }
                if (two == four && one < three) //на одном столбце //менял
                {
                    one += 1;   //менял
                    if (three == 5)
                    {
                        three = 0;
                    }
                    else
                        three -= 1;
                    s += Convert.ToString(one) + Convert.ToString(two) + Convert.ToString(three) + Convert.ToString(four);
                }
                else if (two == four && one > three)
                {
                    one -= 1;
                    if (three == 0)
                    {
                        three = 5;
                    }
                    else
                        three -= 1;
                   
                    s += Convert.ToString(one) + Convert.ToString(two) + Convert.ToString(three) + Convert.ToString(four);
                }
                if (one > three && two != four)
                {
                    swap_index = two;
                    two = four;
                    four = swap_index;
                    s += Convert.ToString(one) + Convert.ToString(two) + Convert.ToString(three) + Convert.ToString(four);
                }
                else if (one < three && two != four)
                {
                    swap_index = two;
                    two = four;
                    four = swap_index;
                    s += Convert.ToString(one) + Convert.ToString(two) + Convert.ToString(three) + Convert.ToString(four);
                }
            }
            textBox7.Text = s;
        }
        void Deshifr_text()
        {
            string Polib = Key() + Alfavit;
            Polib = new string(Polib.Distinct().ToArray());
            string msg = textBox7.Text;
           
          
            string index_polib = "";
            for (int i = 0; i < 6;)
            {
                for (int j = 0; j < 6; j++) // Создаем индексы для каждого символа таблицы
                {
                    index_polib += i;
                    index_polib += j + " ";
                    if (j % 5 == 0 && j != 0)
                    {
                        i++;
                    }
                }
            }
            msg = msg.Replace(" ", ""); //убираем пробелы
            string stroka_simbols = "";
            for (int i = 0; i < msg.Length; i += 2) //проходим по индексам 
            {
                for (int j = 0; j < index_polib.Length; j += 3)//проходим по индексам символов
                {
                    if (index_polib.Substring(j, 2) == msg.Substring(i, 2))// если индексы совпали, то...
                    {
                        stroka_simbols += msg.Substring(i, 2).Replace(msg.Substring(i, 2), Convert.ToString(Polib[j / 3]));
                        break;                                      //...записываем буквы, соответствующие их индексам из ключа с алфавитом
                    }
                }
            }

            textBox5.Text = stroka_simbols;
        }

    }
}
