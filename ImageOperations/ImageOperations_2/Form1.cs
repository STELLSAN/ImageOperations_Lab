using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageOperations_2
{
    public partial class Form1 : Form
    {
        Bitmap image;
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.png; *.jpg; *.bmp | All files (*.*) | *.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
                pictureBox2.Image = image;
                pictureBox2.Refresh();
            }
        }

        private void применитьШумToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Filters();
            Bitmap bmp1 = new Bitmap(pictureBox1.Image);
            bmp1 = filter.ExponentialNoise(bmp1);
            pictureBox2.Image = bmp1;
            pictureBox2.Refresh();
        }
    }
}
