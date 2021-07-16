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

namespace Lesson1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            comboBox1.Items.Add("*.txt");
            comboBox1.Items.Add("*.*");
            comboBox1.Items.Add("*.pdf");
            comboBox1.Items.Add("*.7z");
            comboBox1.Items.Add("*.doc");
        }

        private void chooseFolder()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            var dir = new DirectoryInfo(textBox1.Text);
            foreach (FileInfo fileInfo in dir.GetFiles(comboBox1.SelectedItem.ToString()))
            {
                listBox1.Items.Add(Path.GetFileNameWithoutExtension(fileInfo.FullName));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chooseFolder();
        }
    }
}
