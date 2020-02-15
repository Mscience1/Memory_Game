using Pairs.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Pr0metheus 23.11.2019

namespace Pairs
{
    public partial class Form1 : Form
    {
        private const int CARD_NUMBER = 8;
        private Image[] m_Images = new Image[CARD_NUMBER];

        private bool m_IsFirst = true;
        private PictureBox m_FirstPictureBox;
        private PictureBox m_SecondPictureBox;
        int m_CountTrue = 0;

        public Form1()
        {
            InitializeComponent();
            SetImagesArray();
        }

        private void SetImagesArray()
        {
            m_Images[0] = Resources.Meme1;
            m_Images[1] = Resources.Meme2;
            m_Images[2] = Resources.Meme3;
            m_Images[3] = Resources.Meme4;
            m_Images[4] = Resources.Meme1;
            m_Images[5] = Resources.Meme2;
            m_Images[6] = Resources.Meme3;
            m_Images[7] = Resources.Meme4;

            Random rnd = new Random();
            for (int i = 0; i < CARD_NUMBER; i++)
            {
                Swap(i, rnd.Next(CARD_NUMBER));
            }
        }

        private void Swap(int i, int j)
        {
            Image image = m_Images[i];
            m_Images[i] = m_Images[j];
            m_Images[j] = image;
        }

        private void pictureBox_Card_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;

            string picName = pictureBox.Name;

            int k = int.Parse(picName.Substring(picName.Length - 1));

            k--;
            if (!IsImagesMatch(pictureBox.Image, Resources.Saturn_Aur))
                pictureBox.Image = Resources.Saturn_Aur;
            else
                pictureBox.Image = m_Images[k];

            if (!m_IsFirst)
            {
                m_SecondPictureBox = pictureBox;
                timer1.Start();
            }
            else
            {

                m_FirstPictureBox = pictureBox;
            }
            m_IsFirst = !m_IsFirst;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsImagesMatch(m_FirstPictureBox.Image, m_SecondPictureBox.Image))
            {

                m_FirstPictureBox.Enabled = false;
                m_SecondPictureBox.Enabled = false;
                m_CountTrue += 2;
            }
            else
            {
                m_FirstPictureBox.Image = Resources.Saturn_Aur;
                m_SecondPictureBox.Image = Resources.Saturn_Aur;
            }
            timer1.Stop();
            if (m_CountTrue == CARD_NUMBER)
            {

                MessageBox.Show("Winner!!!!");
                this.Hide();
                Form f2 = new Form2();
                f2.ShowDialog();        
            }
        }

        public bool IsImagesMatch(Image image1, Image image2)
        {
            try
            {
                ImageConverter converter = new ImageConverter();

                byte[] imgBytes1 = new byte[1];
                byte[] imgBytes2 = new byte[1];


                imgBytes1 = (byte[])converter.ConvertTo(image1, imgBytes2.GetType());
                imgBytes2 = (byte[])converter.ConvertTo(image2, imgBytes1.GetType());
                System.Security.Cryptography.SHA256Managed sha = new System.Security.Cryptography.SHA256Managed();
                byte[] imgHash1 = sha.ComputeHash(imgBytes1);
                byte[] imgHash2 = sha.ComputeHash(imgBytes2);


                for (int i = 0; i < imgHash1.Length && i < imgHash2.Length; i++)
                {

                    if (!(imgHash1[i] == imgHash2[i]))
                        return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            m_CountTrue = 0;
            pictureBox1.Image = Resources.Saturn_Aur;
            pictureBox2.Image = Resources.Saturn_Aur;
            pictureBox3.Image = Resources.Saturn_Aur;
            pictureBox4.Image = Resources.Saturn_Aur;
            pictureBox5.Image = Resources.Saturn_Aur;
            pictureBox6.Image = Resources.Saturn_Aur;
            pictureBox7.Image = Resources.Saturn_Aur;
            pictureBox8.Image = Resources.Saturn_Aur;
            Random rnd = new Random();
            
            for (int i = 0; i < CARD_NUMBER; i++)
            {
                Swap(i, rnd.Next(CARD_NUMBER));
            }
            pictureBox1.Enabled = true;
            pictureBox2.Enabled = true;
            pictureBox3.Enabled = true;
            pictureBox4.Enabled = true;
            pictureBox5.Enabled = true;
            pictureBox6.Enabled = true;
            pictureBox7.Enabled = true;
            pictureBox8.Enabled = true;
        
        }
    }
}
