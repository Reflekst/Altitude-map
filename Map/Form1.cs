using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RandomPixelImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {   
            //Wczytanie pliku tekstowego
            int width, height, distance;
            int a = 255, r = 0, g = 0, b = 0;
            StreamReader sr = File.OpenText("big.txt");
            string line;
            line = sr.ReadLine();
            var split = line.Split(new Char[] { ' ' });
            width = Int32.Parse(split[0]);
            height = Int32.Parse(split[1]);
            distance = Int32.Parse(split[2]);
            double[] points = new double[(width * height)];
            int index = 0;
            while ((line = sr.ReadLine()) != null)
            {
                for (int i = 0; i < (split.Length - 1); i++)
                {
                    split = line.Split(new Char[] { ' ' });
                    points[index] = Convert.ToDouble(split[i].Replace('.', ','));
                    index++;
                }
            }
            //Stworzenie mapy składającej sie z pikseli
            Bitmap bmp = new Bitmap(width, height);

            //Kolorowanie pixeli
            for (int y = 0; y < height; y++)
            {
                for (int i = 0; i < width; i++)
                {
                    if (points[i + (500 * y)] < 99.5)
                    {
                        r = 0 + (int)(4 * (points[i + (500 * y)] - 43));
                        g = 255;
                        b = 0;
                    }
                    else
                    {
                        r = 255;
                        g = 255 - (int)(2.5 * (points[i + (500 * y)] - 99.5));
                        b = 0;
                    }
                    bmp.SetPixel(i, y, Color.FromArgb(a, r, g, b));
                }
            }

            pictureBox1.Image = bmp;

            bmp.Save("RandomImage.png");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
