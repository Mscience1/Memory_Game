using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pairs
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
          System.Media.SoundPlayer player = new System.Media.SoundPlayer();
          player.SoundLocation = @"C:\Users\Miki\Downloads\Soviet.wav";
          player.Load();
          player.PlayLooping();
            
        }
    }
}
