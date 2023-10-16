using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ImageOperations
{
    public partial class Form1 : Form
    {
        Bitmap image;
        Bitmap image2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void открыть1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.png; *.jpg; *.bmp | All files (*.*) | *.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }

        private void открыть2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.png; *.jpg; *.bmp | All files (*.*) | *.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image2 = new Bitmap(dialog.FileName);
                pictureBox2.Image = image2;
                pictureBox2.Refresh();
            }
        }

        private void mSEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Functions func = new Functions();
            float res;
            Bitmap bmp1 = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(pictureBox2.Image);
            res = func.imageCompareMSE(bmp1, bmp2);
            label1.Text = res.ToString();
        }

        private void uIQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Functions func = new Functions();
            float res;
            Bitmap bmp1 = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(pictureBox2.Image);
            res = func.imageCompareUIQ(bmp1, bmp2);
            label1.Text = res.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
