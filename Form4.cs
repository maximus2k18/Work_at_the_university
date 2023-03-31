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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // сформировать обратную польскую запись
            // 1) Представим инфиксную запись в виде массива элементов           

            List<String> VS = new List<string>();/*List, потому что в стеке нельзя обратиться к определенному элементу */
            OPZ[] masOPZ = new OPZ[100];
            // заполним массив на основе анализа строки
            string VhStr = textBox1.Text;
            for (int i = 0; i < VhStr.Length; i++)
            {
                string Chisla = "0123456789";
                if (Chisla.IndexOf(VhStr[i]) >= 0)
                {
                    if (((i + 1) == VhStr.Length)/*кончилась строка?*/ || Chisla.IndexOf(VhStr[i + 1]) <= 0/*элемент(i + 1) - не число?*/)
                    {
                        VS.Add(VhStr[i].ToString())/*добавляем элемент*/;
                    }
                    else
                    {
                        if (((i + 2) == VhStr.Length/*кончилась строка?*/) || Chisla.IndexOf(VhStr[i + 2]) <= 0/*элемент (i + 2)  - не число?*/)
                        {
                            VS.Add(VhStr[i].ToString() + VhStr[i + 1].ToString());
                            i++/*перескакиваем элементы, которые уже добавлены*/;
                        }
                        else
                        {
                            VS.Add(VhStr[i].ToString() + VhStr[i + 1].ToString() + VhStr[i + 2].ToString());
                            i += 2;
                        }
                    }
                }
                else
                {
                    VS.Add(VhStr[i].ToString());
                }
            }
            for (int i = 0; i < VS.Count; i++) /*VS.Count - число элементов в листе*/
            {
                masOPZ[i] = new OPZ();
                masOPZ[i].Add(VS[i].ToString()); // заполняет свойства объекта masOPZ[i] //////////////////////////////
            }

            // 2) Представиим ОПЗ    
            CreateOPZ(masOPZ);
        }
        private void CreateOPZ(OPZ[] mas_EL)
        {
            OPZ[] mas_EL_OPZ = new OPZ[100]; // выходная строка
            int schELOPZ = 0;
            Stack<OPZ> Stek = new Stack<OPZ>();
            for (int i = 0; i < mas_EL.Length; i++)
            {
                if (mas_EL[i] == null)
                {
                    continue;
                }
                if (mas_EL[i].operacia == "ch")
                {
                    // Правило 4 - добавляем в выходную строку
                    mas_EL_OPZ[schELOPZ] = new OPZ();
                    mas_EL_OPZ[schELOPZ] = mas_EL[i];
                    schELOPZ++;
                }
                else // если не число
                {
                    if (Stek.Count == 0)
                    {// если стек пустой, то добавляем опреацию в стек
                        Stek.Push(mas_EL[i]);
                    }
                    else if (mas_EL[i].operacia == "(")
                    { // правило 2
                        Stek.Push(mas_EL[i]);
                    }
                    else if (mas_EL[i].operacia == ")")
                    {
                        // 3 правило - извлекаем из стека все операции до "("
                        while (Stek.Peek().operacia != "(")                         
                        {
                            mas_EL_OPZ[schELOPZ] = new OPZ();
                            mas_EL_OPZ[schELOPZ] = Stek.Pop();
                            schELOPZ++;
                        }
                        Stek.Pop();
                    }

                    else if (mas_EL[i].rang > Stek.Peek().rang)
                    {// правило 5.1
                        Stek.Push(mas_EL[i]);
                    }
                    else
                    { // если ранг текущии операции меньше чем ранг операции в стеке
                      // правило 5.2 - извлекаем из стека все операции до тех пор, пока не встретим
                      // операцию в стеке ранг которой < ранга текущей опреации mas_EL[i]

                        while ((Stek.Count != 0) && (mas_EL[i].rang <= Stek.Peek().rang))
                        {
                            mas_EL_OPZ[schELOPZ] = new OPZ();
                            mas_EL_OPZ[schELOPZ] = Stek.Pop();
                            schELOPZ++;
                           
                        }
                        // а теперь добавим в стек рассм операцию
                        Stek.Push(mas_EL[i]);
                    }
                }
            }
            // правило 6 - извлекает из стека оставшиеся элементы
            while (Stek.Count != 0)
            {
                mas_EL_OPZ[schELOPZ] = new OPZ();
                mas_EL_OPZ[schELOPZ] = Stek.Pop();
                schELOPZ++;
            }
            // выходная строка готова, она хранится в mas_EL_OPZ
            // выведем на экран получившеюся строку
            textBox2.Text = "";
            for (int i = 0; i < schELOPZ; i++)
            {
                textBox2.Text = textBox2.Text + ((mas_EL_OPZ[i].operacia == "ch") ? mas_EL_OPZ[i].operand.ToString() : mas_EL_OPZ[i].operacia) + " ";
            }
            Rezult(mas_EL_OPZ);
        }
        private void Rezult(OPZ[] oPZs)
        {
            double a, b;
            Stack<string> Stek = new Stack<string>();
            for (int i = 0; i < oPZs.Length; i++)
            {
                if (oPZs[i] == null)
                {
                    continue;
                }
                if (Stek.Count != 0 && ("+-*/".IndexOf(oPZs[i].operacia) >= 0))
                {
                    switch (oPZs[i].operacia)
                    {
                        case "+":
                            a = Convert.ToDouble(Stek.Pop());
                            b = Convert.ToDouble(Stek.Pop());
                            Stek.Push((b + a).ToString());
                            break;
                        case "-":
                            a = Convert.ToDouble(Stek.Pop());
                            b = Convert.ToDouble(Stek.Pop());
                            Stek.Push((b - a).ToString());
                            break;
                        case "*":
                            a = Convert.ToDouble(Stek.Pop());
                            b = Convert.ToDouble(Stek.Pop());
                            Stek.Push((b * a).ToString());
                            break;
                        case "/":
                            a = Convert.ToDouble(Stek.Pop());
                            b = Convert.ToDouble(Stek.Pop());
                            Stek.Push((b / a).ToString());
                            break;
                    }
                }
                else
                {
                    Stek.Push(oPZs[i].operand.ToString());
                }
            }
            textBox3.Text = Stek.Pop();
        }
    }
}

