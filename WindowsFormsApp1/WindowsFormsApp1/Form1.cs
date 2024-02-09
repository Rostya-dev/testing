using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private string photoPath;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файлы изображений|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
            openFileDialog.Title = "Выберите фотографию";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                photoPath = openFileDialog.FileName;
                label1.Text = photoPath; // Отображение пути к фотографии
                pictureBox1.ImageLocation = photoPath; // Открытие фотографии
            }
        }
    }
 }
