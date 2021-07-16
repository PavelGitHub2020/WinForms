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
        private int wearDrivenWheel;//ведущие колеса
        private int wearDriveWheel;//ведомые колеса

        private double rearrangment_Of_Tires;//расстояние для перестановки шин

        private double distance;//итогое кол-во километров

        private int number;//износ колес в number раз

        private int counter;//кол-во ведущих колес

        private int counter1;//кол-во ведущих колес

        private Random random;

        private int number_Of_Wheel;//кол-во колес
        private int number_Of_Tires;//кол-во шин

        private string values;
        private string[] arrayValues;
        int lengthArray;
        public Form1()
        {
            InitializeComponent();
            textBox2.KeyPress += TextBox2_KeyPress;
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)//разрешен ввод только цифр и клавиши Backspace,Enter
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 13)
            {
                e.Handled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillingComboboxes();
        }

        private void FillingComboboxes()
        {
            for (int i = 4; i <= 10; i++)
            {
                if (i % 2 == 0)
                    comboBox1.Items.Add(i);//кол-во колес
            }
            for (int i = 4; i <= 20; i++)
                comboBox2.Items.Add(i);//кол-во новых шин
        }

        private void ZeroingValues()
        {
            counter = 0;
            counter1 = 0;
            values = "";
            arrayValues = null;
            wearDrivenWheel = 0;
            wearDriveWheel = 0;
            number = 0;
            lengthArray = 0;
        }

        private void TireWear()
        {
            number_Of_Wheel = Convert.ToInt32(comboBox1.Text);
            number_Of_Tires = Convert.ToInt32(comboBox2.Text);

            ZeroingValues();//при повторном обращении,старые значения обнуляем

            random = new Random();

            values = textBox2.Text;//записываем в строку значения износа
            arrayValues = values.Split(new string[] { "\r\n" }, StringSplitOptions.None);//массив чисел max и min износа

            if (Convert.ToInt32(arrayValues[0]) > 3000 || Convert.ToInt32(arrayValues[0]) <= 0)//если max износ ввели > 3000 || <= 0, по условию <= 3000 || > 0
            {
                MessageBox.Show("The max value can be 3000 or > 0");
                return;
            }
            else if (Convert.ToInt32(arrayValues[arrayValues.Length - 1]) <= 0 ||
                     Convert.ToInt32(arrayValues[arrayValues.Length - 1]) > 3000)//если min износ ввели 0 или меньше, по условию болбше 0
            {
                MessageBox.Show("The min value must be > 0 or < 3000");
                return;
            }

            wearDrivenWheel = Convert.ToInt32(arrayValues[0]);//ведомые колеса
            wearDriveWheel = Convert.ToInt32(arrayValues[arrayValues.Length - 1]);//ведущие колеса

            number = wearDrivenWheel / wearDriveWheel;//износ на ведущих колесах в number раз, то есть max / min

            lengthArray = arrayValues.Length;//длина массива значений ведущих и ведомых колес

            for (int i = 0; i < arrayValues.Length - 1; i++)
            {
                if (Convert.ToInt32(arrayValues[i]) > Convert.ToInt32(arrayValues[arrayValues.Length - 1]))
                {
                    counter1++;//кол-во ведомых колес
                }
            }

            counter = lengthArray - counter1;//кол-во ведущих колес
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || comboBox2.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("One of the forms is empty, please fill in completely!");
                return;
            }

            if (number_Of_Tires < number_Of_Wheel)
            {
                MessageBox.Show("Number of tires must be at least equal number of wheels!");
                return;
            }
            else
            {
                TireWear();
            }    
                
            if (lengthArray == number_Of_Wheel)//кол-во записей износа шин должно быть равным кол-ву колес
            {
                Max_Number_Of_Kilometers();
            }
            else
            {
                MessageBox.Show("Number of tire wear values must be equals number of wheel!");
                return;
            }
        }

        private void Max_Number_Of_Kilometers()
        {
            distance = 0.0;

            double max = wearDrivenWheel;//значение максимального износа
            double min = wearDriveWheel;//значение минимального износа

            double change = 0;//для замены местами шин

            int AdditionalNewTires = number_Of_Tires - number_Of_Wheel;//кол-во дополнительных новых шин

            random = new Random();

            rearrangment_Of_Tires = min / 4;//оптимальное расстояние перестановки шин

            while (min >= rearrangment_Of_Tires)
            {
                //отнимаем проехавшее расстояние
                max -= rearrangment_Of_Tires;
                min -= rearrangment_Of_Tires;

                //меняем местами
                change = max;
                max = min * number;
                min = change / number;

                //прибавляем проехавшее расстояние
                distance += rearrangment_Of_Tires;

                if (min < rearrangment_Of_Tires)
                {
                    distance += min;
                }

                if (AdditionalNewTires >= counter && min < rearrangment_Of_Tires)//если запасных шин >= кол-ва ведущих.колес,если нет,смысла менять на одной паре колес нет,так как на другой паре износ уже будет максимальным
                {
                    min = wearDrivenWheel;//меняем шины на новые по парно
                    AdditionalNewTires -= counter;
                }
            }
            distance = Math.Round(distance, 3);
            textBox1.Text = distance.ToString();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
