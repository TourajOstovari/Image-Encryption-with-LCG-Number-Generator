using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ImageEncryption
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LCG.lst.Clear();
            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            LCG.LCG_(Code, (long)(Code * numericUpDown1.Value), (long)(Code + numericUpDown1.Value), (bitmap.Width));
            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int i2 = 0; i2 < bitmap.Width; i2++)
                {
                    Color c = bitmap.GetPixel(i2, i);
                    long temp = LCG.lst[i2];
                    byte r = (byte)(c.R ^ temp);
                    byte g = (byte)(c.G ^ temp);
                    c = Color.FromArgb(r, g, c.B);
                    bitmap.SetPixel(i2, i, c);

                }
            }
            pictureBox1.Image = bitmap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            LCG.lst.Clear();
            LCG.LCG_(Code, (long)(Code * numericUpDown1.Value), (long)(Code + numericUpDown1.Value), (bitmap.Width));

            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int i2 = 0; i2 < bitmap.Width; i2++)
                {
                    Color c = bitmap.GetPixel(i2, i);
                    long temp = LCG.lst[i2];
                    byte r = (byte)(c.R ^ temp);
                    byte g = (byte)(c.G ^ temp);
                    c = Color.FromArgb(r, g, c.B);
                    bitmap.SetPixel(i2, i, c);
                }
            }
            pictureBox2.Image = bitmap;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(System.IO.Path.GetFullPath(openFileDialog1.FileName.ToString()));
                pictureBox1.Image = img;
            }
        }
        public static Int64 Code = 1;
        private void button3_Click(object sender, EventArgs e)
        {
            Code = 1;
            SHA512CryptoServiceProvider Sha512 = new SHA512CryptoServiceProvider();
            byte[] Sha2 = Sha512.ComputeHash(Encoding.UTF8.GetBytes(textBox1.Text));
            for (int i = 0; i < Sha2.Length; i++)
            {
                Code = Code + Sha2[i];
            }
            label2.Text = Code.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Save(@"C:\EncryptedImage" + System.IO.Path.GetExtension(openFileDialog1.FileName.ToString()));
            MessageBox.Show("در درایو سی داده ذخیره شد.");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox2.Image.Save(@"C:\DecryptedImage" + System.IO.Path.GetExtension(openFileDialog1.FileName.ToString()));
            MessageBox.Show("در درایو سی داده ذخیره شد.");
        }
    }
}
