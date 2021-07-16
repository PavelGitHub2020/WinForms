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
    public partial class Form2 : Form
    {
        Form1 main = null;
        public Form2(string text, Form1 form1)
        {
            InitializeComponent();

            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.Text = text;

            main = form1;
        }

        private void button1Save_Click(object sender, EventArgs e)
        {
            main.ChangeTextInTextBox(this.textBox1.Text);
            this.Close();
        }

        private void button2Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
