using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //2. Написать приложение — анкету, которую предлагается заполнить пользователю,
        //все данные отображаются на результирующем текстовом поле.

        public Form1()
        {
            InitializeComponent();
        }

        private void FillingOutTheQuestionare(string textBoxText, int index, string nameField)
        {
            if (string.IsNullOrWhiteSpace(textBoxText))
            {
                MessageBox.Show("The field surname is empty!");
            }
            else if (!listBox1.Items.Contains(textBoxText))
            {
                for (int i = 1; i <= listBox1.Items.Count - index; i++)
                {
                    if (listBox1.Items[index].ToString() != textBoxText && i == 1)//условие, что бы в случае изменения поля, не исчезали соседние поля
                    {
                        listBox1.Items.RemoveAt(index);
                    }
                }
                listBox1.Items.Insert(index, nameField + textBoxText);
            }
        }
       
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FillingOutTheQuestionare(textBox1.Text, 0, "Surname - ");
            }
        }

        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FillingOutTheQuestionare(textBox2.Text, 1, "Name - ");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FillingOutTheQuestionare(textBox3.Text, 2, "Middle name - ");
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FillingOutTheQuestionare(textBox4.Text, 3, "Date of birth - ");
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FillingOutTheQuestionare(textBox5.Text, 4, "Phone number - ");
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FillingOutTheQuestionare(textBox6.Text, 5, "Residence address - ");
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FillingOutTheQuestionare(textBox7.Text, 6, "Profession - ");
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FillingOutTheQuestionare(textBox8.Text, 7, "Place of work - ");
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FillingOutTheQuestionare(textBox9.Text, 8, "Martial status - ");
            }
        }
    }
}
