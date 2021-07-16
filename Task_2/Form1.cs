using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson2
{
    public partial class Form1 : Form
    {
        //2 Разработайте приложение, которое состоит из двух форм.
        //Первая форма содержит TextBox доступный только для чтения и две кнопки
        // «загрузить файл» и «редактировать». Кнопка «редактировать» изначально неактивна.
        // При нажатии на первую кнопку, открывается диалог и пользователю предлагают выбрать
        //текстовый файл. Выбранный файл загружается в TextBox и кнопка «редактировать» 
        //становится активной. При нажатии на вторую кнопку открывается вторая форма (не модально),
        // которая содержит TextBox доступный для редактирования и две кнопки «Сохранить» и «Отменить».
        // При нажатии на первую кнопку изменения отображаются в TextBox первой формы.

        public Form1()
        {
            InitializeComponent();

            button2Edit.Enabled = false;

            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Both;

            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files(*.*)|*.*";
        }

        private void button1UploadFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                string fileText = System.IO.File.ReadAllText(fileName);
                textBox1.Text = fileText;
            }
            button2Edit.Enabled = true;
        }

        private void button2Edit_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox1.Text.ToString()))
            {
                Form2 form2 = new Form2(textBox1.Text.ToString(), this);
                form2.Show();
            }
            else
            MessageBox.Show("Select and upload file!");
        }

        public void ChangeTextInTextBox(string value)
        {
            this.textBox1.Text = value;
        }

        private void changeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.BackColor = colorDialog1.Color;
            }
        }
    }
}
