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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Chisla = "0123456789";
            OPZ [] masOPZ = new OPZ[100];

            string VhStr = textBox1.Text;
            int Kol_el = VhStr.Length;
           
            Stack <string> Stck = new Stack<string>(Kol_el);
            for (int i = 0; i < Kol_el; i++)
            {
                if (Chisla.IndexOf(VhStr[i]) !=-1 || "+-/*".IndexOf(VhStr[i]) !=-1 )
                {
                    if (((i + 1) == Kol_el) || Chisla.IndexOf(VhStr[i + 1]) == -1) // кончилась строка или следующий элемент не число
                    {
                        Stck.Push(VhStr[i].ToString())/*добавляем элемент*/;
                    }
                    else
                    {
                        if (((i + 2) == Kol_el) || Chisla.IndexOf(VhStr[i + 2]) == -1 ) //кончилась строка или элемент (i + 2)  - не число
                        {
                            Stck.Push(VhStr[i].ToString());
                            Stck.Push(VhStr[i + 1].ToString());
                            i++;
                        }
                        else
                        {
                            Stck.Push(VhStr[i].ToString() + VhStr[i + 1].ToString() + VhStr[i + 2].ToString());
                            i += 2;
                        }
                    }
                }
                else
                {
                    Stck.Push(VhStr[i].ToString());
                }
            }
            for (int i = 0; i < Kol_el; i++)
            {
                masOPZ[i] = new OPZ();
                masOPZ[i].Add(Stck.Pop()); // заполняет свойства объекта masOPZ[i] 
            }

            // Создаем ОПЗ    
            CreateOPZ(masOPZ);
        }
        private void CreateOPZ(OPZ[] mas_EL)
        {
            Stack<OPZ> stck = new Stack<OPZ>();
            OPZ[] VihodStr = new OPZ[20];  //вых. строка
            int schetchik = 0;
            for (int i = 0; i < mas_EL.Length; i++)
            {
                if (mas_EL[i] == null)
                {
                    continue;
                }
                if (mas_EL[i].operacia == "ch")  //если число, в выходную строку
                {
                    VihodStr[schetchik] = new OPZ();
                    VihodStr[schetchik] = mas_EL[i];
                    schetchik++;
                }
                else
                {
                    if (stck.Count == 0)
                    {
                        stck.Push(mas_EL[i]);
                    }
                    // 3 правило - извлекаем из стека все операции до "("
                    else if (mas_EL[i].operacia == "(") //если скобка, то в стек
                    {
                        stck.Push(mas_EL[i]);
                    }
                    else if (mas_EL[i].rang > stck.Peek().rang) //если ранг операции > опер. стека, добавляем в вых строку
                    {
                        stck.Push(mas_EL[i]);
                    }
                    else if (stck.Peek().operacia == ")")
                    {
                        while (stck.Peek().operacia != "(") //извлекаем из стека все операции до встречи "("
                        {
                            VihodStr[schetchik] = new OPZ();
                            mas_EL[i] = stck.Pop();
                            schetchik++;
                        }
                        stck.Pop(); //удаляю скобку
                    }
                    else if (mas_EL[i].rang <= stck.Peek().rang)
                    {
                        while (stck.Count != 0 &&  mas_EL[i].rang <= stck.Peek().rang)   /////////////////////////BUG Swap ^&&^
                                                                                         //выталкиваю эл-ты из стека, пока входящий эл-т по рангу будет не ниже стека.
                        {
                            VihodStr[schetchik] = new OPZ();
                            VihodStr[schetchik] = stck.Pop();
                            schetchik++;
                        }
                        stck.Push(mas_EL[i]); //добавляю в стек входящий эл-т
                    }
                }
            }
            while (stck.Count != 0) //оставшиеся эл-ты выталкиваю
            {
                VihodStr[schetchik] = new OPZ();
                VihodStr[schetchik] = stck.Pop();
                schetchik++;
            }
            textBox2.Text = "";
            for (int i = 0; i < schetchik; i++) //нужна еще 1 переменная чтобы вывести опз
            {
                textBox2.Text += (VihodStr[i].operacia == "ch" ? VihodStr[i].operand.ToString() : VihodStr[i].operacia) + " "; 
            }
            Rezult(VihodStr);
        }
        private void Rezult(OPZ[] MasOpz)
        {
            Stack<string> stck = new Stack<string>();
            double a, b;
            
            for (int i = 0; i < MasOpz.Length; i++)
            {
                if (MasOpz[i] == null)                ////
                {
                    continue;
                }
                if ("+-*/".IndexOf(MasOpz[i].operacia) != -1 )  // если есть +-*/, то вычисляем
                {
                    switch (MasOpz[i].operacia)
                    {
                        case "+":
                            a = Convert.ToDouble(stck.Pop());
                            b = Convert.ToDouble(stck.Pop());
                            stck.Push(Convert.ToString(b + a));
                            break;
                        case "-":
                            a = Convert.ToDouble(stck.Pop());
                            b = Convert.ToDouble(stck.Pop());
                            stck.Push(Convert.ToString(b - a));
                            break;
                        case "*":
                            a = Convert.ToDouble(stck.Pop());
                            b = Convert.ToDouble(stck.Pop());
                            stck.Push(Convert.ToString(b * a));
                            break;
                        case "/":
                            a = Convert.ToDouble(stck.Pop());
                            b = Convert.ToDouble(stck.Pop());
                            stck.Push(Convert.ToString(b / a));
                            break;
                    }
                }
                else
                {
                    stck.Push(MasOpz[i].operand.ToString());
                }
            }
        textBox3.Text = stck.Pop();
        }
    }
}
