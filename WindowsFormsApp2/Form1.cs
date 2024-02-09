using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private SoundPlayer player;
        private bool isLooping = false;
        public Form1()
        {
            InitializeComponent();
            player = new SoundPlayer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Audio Files|*.wav;*.mp3|All Files|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    player.SoundLocation = filePath;
                    label1.Text = "Сейчас воспросизводится: " + openFileDialog.FileName;

                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;

                    
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player.Play();
            timer1.Start(); // Запускаем таймер

        }

        private void button3_Click(object sender, EventArgs e)
        {
            player.Stop();
            timer1.Stop(); // Останавливаем таймер
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (isLooping)
            {
                player.Play();
            }
            else
            {
                player.PlayLooping();
            }

            isLooping = !isLooping;
            button4.Text = isLooping ? "Stop Loop" : "Loop";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (player != null && player.SoundLocation != null && player.Stream != null)
            {
                int progress = (int)(player.Stream.Position * 100 / player.Stream.Length);
                progressBar1.Value = progress;
            }
            else
            {
                progressBar1.Value = 0;
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

           
        }
    }
}
