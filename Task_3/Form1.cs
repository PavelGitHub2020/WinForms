using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Threading;

namespace HomeLesson
{
    public partial class Form1 : Form
    {
        //Написать приложение, которое отображает количество текста, 
        //прочитанного из файла с помощью ProgressBar.
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const string file = @"B:\учебный проект\для примеров\WinFormsApplication\Text1.txt"; 

            string[] words;

            int countLine = System.IO.File.ReadAllLines(file).Length;

            int counterWords = 0;

            string[] allLines = File.ReadAllLines(file);

            using (StreamReader streamReader = new StreamReader(file,System.Text.Encoding.UTF8))
            {
                progressBar1.Maximum = countLine;
                textBox1.Text = "";

                for (int i = 0; i < countLine; i++)
                {
                    
                    textBox3.Text = "";
                    textBox3.Text += Environment.NewLine;
                    textBox3.AppendText((i + 1).ToString());

                    words = allLines[i].Split(' ', '.', ',');

                    textBox2.Text = "";

                    foreach (string word in words)
                    {
                        textBox1.AppendText(word);
                        textBox1.Text += Environment.NewLine;

                        ++counterWords;
                        textBox2.Text = Environment.NewLine;
                        textBox2.AppendText(counterWords.ToString());
                    }

                    progressBar1.PerformStep();
                    this.Update();
                }
            }

            FileInfo sizeInBytes = new FileInfo(file);
            label2.Text = $"File size in bytes - {sizeInBytes.Length.ToString()}";

            label3.Text = $"Number of the characters in the file - {File.ReadAllText(file).Length.ToString()}";
        }
    }
}


