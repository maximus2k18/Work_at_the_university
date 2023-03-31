using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OTKRbITKA
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {         
            Polibiy_Shifrovanie();
            TextToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DeShifrovanie();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            DeShifrovanieToText();
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }
        private void button6_Click_1(object sender, EventArgs e)
        {
            Shifrovanie_2();
            Text_ToString_2();
        }
        private void button8_Click(object sender, EventArgs e)
        {
           
        }
        private void button7_Click(object sender, EventArgs e)
        {
            DeShifrovanie_2();
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            Table();
        }
        public string Key()
        {
            string Key = Convert.ToString(textBox6.Text).ToLower();
            return Key;
        }
        string Alfavit = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя ,.";
        public char[] Polib()
        {
            string Polib = Key() + Alfavit;
            return Polib.Distinct().ToArray();
        }
        void Table()
        {
            int schet = 0;
            string[,] SquarePolib = new string[6, 6];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    SquarePolib[i, j] = Polib()[schet].ToString(); //заполнили квадрат введенными и оставшимися символами из алфавита
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
        void Polibiy_Shifrovanie()
        {
            string Polib = Key() + Alfavit;
            Polib = new string(Polib.Distinct().ToArray());
            string message = textBox1.Text.ToLower();
            string mssg = "";
            // Проверяем, все ли символы во входной строке есть в списке
            for (int i = 0; i < message.Length; i++)
            {
                if (Polib.IndexOf(message[i]) == -1)
                {
                    MessageBox.Show("Некоторые символы введены некорректно, зашифровать можно символы только из Квадрата Полибия", "Warning!",
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
                    SquarePolib[i, j] = Polib[schet].ToString(); //заполнили квадрат введенными и оставшимися символами из алфавита
                    schet++;
                }
            }
            for (int c = 0; c < message.Count(); c++) //проходим по всем буквам
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (message[c].ToString() == SquarePolib[i, j]) //если символ из сообщения = символу квадрата, то...
                        {
                            mssg += i.ToString() + j.ToString(); //...получаем индексы(координаты) для этого сообщения
                            break;
                        }
                    }
                }
            }
            textBox2.Text = mssg;
            string shifr_messg = "";
            for (int i = 0; i < mssg.Length; i++) //распределяем индексы букв сначала по строкам, после столбцам 
            {
                shifr_messg += mssg[i];
                i++;
            }
            for (int i = 1; i < mssg.Length; i++)
            {
                shifr_messg += mssg[i];
                i++;
            }
            textBox3.Text = shifr_messg;
        }
        void DeShifrovanie()
        {
            string Polib = Key() + Alfavit;
            Polib = new string(Polib.Distinct().ToArray());
            string msg = textBox3.Text;
            string deshifrovka = "";
            //добавление пробела после каждого второго символа, чтобы не было совпадений с ненужными подстроками
            for (int i = 0, j = msg.Length / 2; i < msg.Length / 2; i++, j++)
            {
                deshifrovka += msg[i].ToString();
                deshifrovka += msg[j].ToString() + " ";
            }
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
            deshifrovka = deshifrovka.Replace(" ", ""); //убираем пробелы
            string stroka_simbols = "";
            for (int i = 0; i < deshifrovka.Length; i += 2) //проходим по индексам 
            {
                for (int j = 0; j < index_polib.Length; j += 3)//проходим по индексам символов
                {
                    if (index_polib.Substring(j, 2) == deshifrovka.Substring(i, 2))// если индексы совпали, то...
                    {
                        stroka_simbols += deshifrovka.Substring(i, 2).Replace(deshifrovka.Substring(i, 2), Convert.ToString(Polib[j / 3]));
                        break;                                      //...записываем буквы, соответствующие их индексам из ключа с алфавитом
                    }
                }
            }
            textBox5.Text = stroka_simbols;
        }
        void DeShifrovanieToText()
        {
            string Polib = Key() + Alfavit;
            Polib = new string(Polib.Distinct().ToArray());
            string m = textBox7.Text.ToLower();
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
            int schet = 0;
            string[,] SquarePolib = new string[6, 6];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    SquarePolib[i, j] = Polib[schet].ToString(); //заполнили квадрат введенными и оставшимися символами из алфавита
                    schet++;
                }
            }
            string mesaage = "";
            for (int c = 0; c < m.Count(); c++) //проходим по всем буквам
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (m[c].ToString() == SquarePolib[i, j]) //если символ из сообщения = символу квадрата, то...
                        {
                            mesaage += i.ToString() + j.ToString(); //...получаем индексы(координаты) для этого сообщения
                            break;
                        }
                    }
                }
            }                                        // все ок
            string deshifrovannyi = "";
            for (int i = 0, j = mesaage.Length / 2; i < mesaage.Length / 2; i++, j++)
            {
                deshifrovannyi += mesaage[i].ToString();
                deshifrovannyi += mesaage[j].ToString();
            }
            for (int i = 0; i < deshifrovannyi.Length; i += 2) //проходим по индексам 
            {
                for (int j = 0; j < index_polib.Length; j += 3)//проходим по индексам символов
                {
                    if (index_polib.Substring(j, 2) == deshifrovannyi.Substring(i, 2))// если индексы совпали, то...  
                    {
                        stroka_simbols += deshifrovannyi.Substring(i, 2).Replace(deshifrovannyi.Substring(i, 2), Convert.ToString(Polib[j / 3]));
                        break;                                      //...записываем буквы, соответствующие их индексам из ключа с алфавитом
                    }
                }
            }
            textBox8.Text = stroka_simbols;
        }
        void TextToString()
        {
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
            string Polib = Key() + Alfavit;
            Polib = new string(Polib.Distinct().ToArray());
            string stroka_simbols = "";
            string m = textBox3.Text;
            for (int i = 0; i < m.Length; i += 2) //проходим по индексам 
            {
                for (int j = 0; j < index_polib.Length; j += 3)//проходим по индексам символов 
                {
                    if (index_polib.Substring(j, 2) == m.Substring(i, 2))// если индексы совпали, то...
                    {
                        stroka_simbols += m.Substring(i, 2).Replace(m.Substring(i, 2), Convert.ToString(Polib[j / 3]));
                        break;                                      //...записываем буквы, соответствующие их индексам из ключа с алфавитом
                    }
                }
            }
            textBox7.Text = stroka_simbols;
        }
        void Shifrovanie_2()
        {
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
            string Polib = Key() + Alfavit;
            Polib = new string(Polib.Distinct().ToArray());
            string message = textBox1.Text.ToLower();
            string mssg = "";
            string[,] SquarePolib = new string[6, 6];
            int schet = 0;

            // Проверяем, все ли символы во входной строке есть в списке
            for (int i = 0; i < message.Length; i++)
            {
                if (Polib.IndexOf(message[i]) == -1)
                {
                    MessageBox.Show("Некоторые символы введены некорректно, зашифровать можно символы только из Квадрата Полибия", "Warning!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    SquarePolib[i, j] = Polib[schet].ToString(); //заполнили квадрат введенными и оставшимися символами из алфавита
                    schet++;
                }
            }
            for (int c = 0; c < message.Count(); c++) //проходим по всем буквам
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (message[c].ToString() == SquarePolib[i, j]) //если символ из сообщения = символу квадрата, то...
                        {
                            mssg += i.ToString() + j.ToString(); //...получаем индексы(координаты) для этого сообщения
                            break;
                        }
                    }
                }
            }
            string ch = ""; 
            string codir = "";
            for (int i = 0, j = 1; i < mssg.Length; i+=2, j+=2)
            {
                ch = mssg.Substring(i, 1);
                if (ch == "5")
                {
                    codir += ch.Replace(ch, "0");
                }
                else if(ch == "4")
                {
                    codir += ch.Replace(ch, "5");
                }
                else if (ch == "3")
                {
                    codir += ch.Replace(ch, "4");
                }
                else if (ch == "2")
                {
                    codir += ch.Replace(ch, "3");
                }
                else if (ch == "1")
                {
                    codir += ch.Replace(ch, "2");
                }
                else
                {
                    codir += ch.Replace(ch, "1");
                }
                codir+=mssg.Substring(j, 1);
            }
            textBox9.Text = codir;
        }
        void Text_ToString_2()
        {
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

            string Polib = Key() + Alfavit;
            Polib = new string(Polib.Distinct().ToArray());

            string stroka_simbols = "";
            string m = textBox9.Text;
            for (int i = 0; i < m.Length; i += 2) //проходим по индексам 
            {
                for (int j = 0; j < index_polib.Length; j += 3)//проходим по индексам символов 
                {
                    if (index_polib.Substring(j, 2) == m.Substring(i, 2))// если индексы совпали, то...
                    {
                        stroka_simbols += m.Substring(i, 2).Replace(m.Substring(i, 2), Convert.ToString(Polib[j / 3]));
                        break;                                      //...записываем буквы, соответствующие их индексам из ключа с алфавитом
                    } 
                     
                }
            }
            textBox4.Text = stroka_simbols;
        }
        void DeShifrovanie_2()
        {
            string Polib = Key() + Alfavit;
            Polib = new string(Polib.Distinct().ToArray());
            string msg = textBox9.Text;
           
            string ch = "";
            string codir = "";
            for (int i = 0, j = 1; i < msg.Length; i += 2, j += 2)
            {
                ch = msg.Substring(i, 1);
                if (ch == "0")
                {
                    codir += ch.Replace(ch, "5");
                }
                else if (ch == "5")
                {
                    codir += ch.Replace(ch, "4");
                }
                else if (ch == "4")
                {
                    codir += ch.Replace(ch, "3");
                }
                else if (ch == "3")
                {
                    codir += ch.Replace(ch, "2");
                }
                else if (ch == "2")
                {
                    codir += ch.Replace(ch, "1");
                }
                else
                {
                    codir += ch.Replace(ch, "0");
                }
                codir += msg.Substring(j, 1);
            }

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
            codir = codir.Replace(" ", ""); //убираем пробелы
            string stroka_simbols = "";
            for (int i = 0; i < codir.Length; i += 2) //проходим по индексам 
            {
                for (int j = 0; j < index_polib.Length; j += 3)//проходим по индексам символов
                {
                    if (index_polib.Substring(j, 2) == codir.Substring(i, 2))// если индексы совпали, то...
                    {
                        stroka_simbols += codir.Substring(i, 2).Replace(codir.Substring(i, 2), Convert.ToString(Polib[j / 3]));
                        break;                                      //...записываем буквы, соответствующие их индексам из ключа с алфавитом
                    }
                }
            }
            textBox10.Text = stroka_simbols;
        } 
    }
}