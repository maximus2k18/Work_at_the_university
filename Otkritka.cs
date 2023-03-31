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
    public partial class Otkritka : Form
    {
        public Otkritka()
        {
            InitializeComponent();
        }

        private void image_Click(object sender, EventArgs e)
        {
            Random RD = new Random();
            image.Left = image.Location.X + RD.Next(-200, 200);
            image.Top = image.Location.Y + RD.Next(-150, 150);
        }

        private void Otktitka_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
