using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {
        //Создайте приложение, которое будет рисовать шахматную
        //доску и шахматные фигуры на клиентской области
        //формы.Для каждой фигуры должно отображаться
        //контекстное меню(индивидуальная информация).

        Font f;
        Rectangle rect;
        LinearGradientBrush lgh;
        Graphics g;

        string[] descriptionOfFifures;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DescriptionOfFigures();

            ArrangementFigure();
        }

        public string DescriptionOfFigures()//Описание фигур
        {
            descriptionOfFifures = new string[6];//6 фигур, 6 описаний

            descriptionOfFifures[0] = "King - the most valuable piece, since the irremediable threat of capture\n" +
                                      "(this situation is called 'checkmate' means the loss of the game.\n" +
                                      "Moves one field vertically, horizontally, or diagonally.";
            descriptionOfFifures[1] = "Queen - the strongest piece, since it moves on any number of fields vertically,\n" +
                                      "horizontally or diagonally, combines the moves of the rook and the bishop.";
            descriptionOfFifures[2] = "Rook - moves to any number of fields vertically or horizontally.";

            descriptionOfFifures[3] = "Elephant - goes in any number of fields on the diagonal.";

            descriptionOfFifures[4] = "Horse - can go to one of the fields closest to the one on which it stands,\n" +
                                      "but not on the same horizontal, vertical or diagonal,\n" +
                                      "i.e. it goes with the Russian letter ' G '(or Latin'L').";
            descriptionOfFifures[5] = "Pawn-moves one square vertically forward. From the starting position,\n" +
                                      "you can also make the first move two fields ahead.\nHas one space diagonally forward.";
            return "";
        }
        private void ArrangementFigure()//Добавление фигур
        {
            string path = @"B:\учебный проект\для примеров\WinFormsApplication\WindowsFormsApplication6\Chess\bin\Debug\";

            Button button = new Button();
            button.Size = new Size(50, 50);
            button.Location = new Point(159, 61);
            button.BackgroundImage = Image.FromFile(path + "rook1.png", false);
            button.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button, descriptionOfFifures[2]);

            Button button1 = new Button();
            button1.Size = new Size(50, 50);
            button1.Location = new Point(230, 61);
            button1.BackgroundImage = Image.FromFile(path + "Horse1.png", false);
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button1, descriptionOfFifures[4]);

            Button button2 = new Button();
            button2.Size = new Size(50, 50);
            button2.Location = new Point(300, 61);
            button2.BackgroundImage = Image.FromFile(path + "Elephant1.png", false);
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button2, descriptionOfFifures[3]);

            Button button3 = new Button();
            button3.Size = new Size(50, 50);
            button3.Location = new Point(370, 61);
            button3.BackgroundImage = Image.FromFile(path + "King1.png", false);
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button3, descriptionOfFifures[0]);

            Button button4 = new Button();
            button4.Size = new Size(50, 50);
            button4.Location = new Point(440, 61);
            button4.BackgroundImage = Image.FromFile(path + "Queen1.png", false);
            button4.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button4, descriptionOfFifures[1]);

            Button button5 = new Button();
            button5.Size = new Size(50, 50);
            button5.Location = new Point(510, 61);
            button5.BackgroundImage = Image.FromFile(path + "Elephant1.png", false);
            button5.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button5, descriptionOfFifures[3]);

            Button button6 = new Button();
            button6.Size = new Size(50, 50);
            button6.Location = new Point(580, 61);
            button6.BackgroundImage = Image.FromFile(path + "Horse1.png", false);
            button6.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button6, descriptionOfFifures[4]);

            Button button7 = new Button();
            button7.Size = new Size(50, 50);
            button7.Location = new Point(650, 61);
            button7.BackgroundImage = Image.FromFile(path + "rook1.png", false);
            button7.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button7, descriptionOfFifures[2]);

            Button button8 = new Button();
            button8.Size = new Size(50, 50);
            button8.Location = new Point(159, 130);
            button8.BackgroundImage = Image.FromFile(path + "Pawn1.png", false);
            button8.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button8, descriptionOfFifures[5]);

            Button button9 = new Button();
            button9.Size = new Size(50, 50);
            button9.Location = new Point(230, 130);
            button9.BackgroundImage = Image.FromFile(path + "Pawn1.png", false);
            button9.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button9, descriptionOfFifures[5]);

            Button button10 = new Button();
            button10.Size = new Size(50, 50);
            button10.Location = new Point(300, 130);
            button10.BackgroundImage = Image.FromFile(path + "Pawn1.png", false);
            button10.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button10, descriptionOfFifures[5]);

            Button button11 = new Button();
            button11.Size = new Size(50, 50);
            button11.Location = new Point(370, 130);
            button11.BackgroundImage = Image.FromFile(path + "Pawn1.png", false);
            button11.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button11, descriptionOfFifures[5]);

            Button button12 = new Button();
            button12.Size = new Size(50, 50);
            button12.Location = new Point(440, 130);
            button12.BackgroundImage = Image.FromFile(path + "Pawn1.png", false);
            button12.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button12, descriptionOfFifures[5]);

            Button button13 = new Button();
            button13.Size = new Size(50, 50);
            button13.Location = new Point(510, 130);
            button13.BackgroundImage = Image.FromFile(path + "Pawn1.png", false);
            button13.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button13, descriptionOfFifures[5]);

            Button button14 = new Button();
            button14.Size = new Size(50, 50);
            button14.Location = new Point(580, 130);
            button14.BackgroundImage = Image.FromFile(path + "Pawn1.png", false);
            button14.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button14, descriptionOfFifures[5]);

            Button button15 = new Button();
            button15.Size = new Size(50, 50);
            button15.Location = new Point(650, 130);
            button15.BackgroundImage = Image.FromFile(path + "Pawn1.png", false);
            button15.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button15, descriptionOfFifures[5]);

            //вторая расстановка

            Button button16 = new Button();
            button16.Size = new Size(50, 50);
            button16.Location = new Point(159, 550);
            button16.BackgroundImage = Image.FromFile(path + "rook1.png", false);
            button16.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button16, descriptionOfFifures[2]);

            Button button17 = new Button();
            button17.Size = new Size(50, 50);
            button17.Location = new Point(230, 550);
            button17.BackgroundImage = Image.FromFile(path + "Horse1.png", false);
            button17.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button17, descriptionOfFifures[4]);

            Button button18 = new Button();
            button18.Size = new Size(50, 50);
            button18.Location = new Point(300, 550);
            button18.BackgroundImage = Image.FromFile(path + "Elephant1.png", false);
            button18.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button18, descriptionOfFifures[3]);

            Button button19 = new Button();
            button19.Size = new Size(50, 50);
            button19.Location = new Point(370, 550);
            button19.BackgroundImage = Image.FromFile(path + "King1.png", false);
            button19.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button19, descriptionOfFifures[0]);

            Button button20 = new Button();
            button20.Size = new Size(50, 50);
            button20.Location = new Point(440, 550);
            button20.BackgroundImage = Image.FromFile(path + "Queen1.png", false);
            button20.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button20, descriptionOfFifures[1]);

            Button button21 = new Button();
            button21.Size = new Size(50, 50);
            button21.Location = new Point(510, 550);
            button21.BackgroundImage = Image.FromFile(path + "Elephant1.png", false);
            button21.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button21, descriptionOfFifures[3]);

            Button button22 = new Button();
            button22.Size = new Size(50, 50);
            button22.Location = new Point(580, 550);
            button22.BackgroundImage = Image.FromFile(path + "Horse1.png", false);
            button22.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button22, descriptionOfFifures[4]);

            Button button23 = new Button();
            button23.Size = new Size(50, 50);
            button23.Location = new Point(650, 550);
            button23.BackgroundImage = Image.FromFile(path + "rook1.png", false);
            button23.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button23, descriptionOfFifures[2]);

            Button button24 = new Button();
            button24.Size = new Size(50, 50);
            button24.Location = new Point(159, 480);
            button24.BackgroundImage = Image.FromFile(path + "Pawn1.png", false);
            button24.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button24, descriptionOfFifures[5]);

            Button button25 = new Button();
            button25.Size = new Size(50, 50);
            button25.Location = new Point(230, 480);
            button25.BackgroundImage = Image.FromFile(path + "Pawn1.png", false);
            button25.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button25, descriptionOfFifures[5]);

            Button button26 = new Button();
            button26.Size = new Size(50, 50);
            button26.Location = new Point(300, 480);
            button26.BackgroundImage = Image.FromFile(path + "Pawn1.png", false);
            button26.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button26, descriptionOfFifures[5]);

            Button button27 = new Button();
            button27.Size = new Size(50, 50);
            button27.Location = new Point(370, 480);
            button27.BackgroundImage = Image.FromFile(path + "Pawn1.png", false);
            button27.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button27, descriptionOfFifures[5]);

            Button button28 = new Button();
            button28.Size = new Size(50, 50);
            button28.Location = new Point(440, 480);
            button28.BackgroundImage = Image.FromFile(path + "Pawn1.png", false);
            button28.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button28, descriptionOfFifures[5]);

            Button button29 = new Button();
            button29.Size = new Size(50, 50);
            button29.Location = new Point(510, 480);
            button29.BackgroundImage = Image.FromFile(path + "Pawn1.png", false);
            button29.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button29, descriptionOfFifures[5]);

            Button button30 = new Button();
            button30.Size = new Size(50, 50);
            button30.Location = new Point(580, 480);
            button30.BackgroundImage = Image.FromFile(path + "Pawn1.png", false);
            button30.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button30, descriptionOfFifures[5]);

            Button button31 = new Button();
            button31.Size = new Size(50, 50);
            button31.Location = new Point(650, 480);
            button31.BackgroundImage = Image.FromFile(path + "Pawn1.png", false);
            button31.BackgroundImageLayout = ImageLayout.Stretch;
            CreateToolTipForFigure(button31, descriptionOfFifures[5]);

            this.Controls.Add(button);
            this.Controls.Add(button1);
            this.Controls.Add(button2);
            this.Controls.Add(button3);
            this.Controls.Add(button4);
            this.Controls.Add(button5);
            this.Controls.Add(button6);
            this.Controls.Add(button7);
            this.Controls.Add(button8);
            this.Controls.Add(button9);
            this.Controls.Add(button10);
            this.Controls.Add(button11);
            this.Controls.Add(button12);
            this.Controls.Add(button13);
            this.Controls.Add(button14);
            this.Controls.Add(button15);
            this.Controls.Add(button16);
            this.Controls.Add(button17);
            this.Controls.Add(button18);
            this.Controls.Add(button19);
            this.Controls.Add(button20);
            this.Controls.Add(button21);
            this.Controls.Add(button22);
            this.Controls.Add(button23);
            this.Controls.Add(button24);
            this.Controls.Add(button25);
            this.Controls.Add(button26);
            this.Controls.Add(button27);
            this.Controls.Add(button28);
            this.Controls.Add(button29);
            this.Controls.Add(button30);
            this.Controls.Add(button31);
        }
        private void CreateToolTipForFigure(Control control,string text)//Метод, который отображает информацию о фигуре
        {
            ToolTip toolTip = new ToolTip();
            toolTip.Active = true;
            toolTip.SetToolTip(control, text);
            toolTip.IsBalloon = true;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)//Рисование доски
        {
            g = e.Graphics;

            //First line
            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("8", f, Brushes.Black, 120, 70);

            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("a", f, Brushes.Black, 170, 15);

            rect = new Rectangle(150, 50, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(220, 50, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(290, 50, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(360, 50, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(430, 50, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(500, 50, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(570, 50, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(640, 50, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("8", f, Brushes.Black, 715, 70);

            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("h", f, Brushes.Black, 660, 610);

            //Second line
            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("7", f, Brushes.Black, 120, 140);

            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("b", f, Brushes.Black, 245, 15);

            rect = new Rectangle(150, 120, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(220, 120, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(290, 120, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(360, 120, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(430, 120, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(500, 120, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(570, 120, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(640, 120, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("7", f, Brushes.Black, 715, 140);

            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("g", f, Brushes.Black, 590, 610);

            //Third line
            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("6", f, Brushes.Black, 120, 210);

            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("c", f, Brushes.Black, 310, 15);

            rect = new Rectangle(150, 190, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(220, 190, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(290, 190, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(360, 190, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(430, 190, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(500, 190, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(570, 190, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(640, 190, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("6", f, Brushes.Black, 715, 210);

            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("f", f, Brushes.Black, 520, 610);

            //Fourth line
            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("5", f, Brushes.Black, 120, 280);

            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("d", f, Brushes.Black, 380, 15);

            rect = new Rectangle(150, 260, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(220, 260, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(290, 260, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(360, 260, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(430, 260, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(500, 260, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(570, 260, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(640, 260, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("5", f, Brushes.Black, 715, 280);

            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("e", f, Brushes.Black, 450, 610);

            //Fifth line
            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("4", f, Brushes.Black, 120, 350);

            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("e", f, Brushes.Black, 450, 15);

            rect = new Rectangle(150, 330, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(220, 330, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(290, 330, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(360, 330, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(430, 330, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(500, 330, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(570, 330, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(640, 330, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("4", f, Brushes.Black, 715, 350);

            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("d", f, Brushes.Black, 380, 610);

            //Sixth line
            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("3", f, Brushes.Black, 120, 420);

            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("f", f, Brushes.Black, 520, 15);

            rect = new Rectangle(150, 400, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(220, 400, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(290, 400, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(360, 400, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(430, 400, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(500, 400, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(570, 400, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(640, 400, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("3", f, Brushes.Black, 715, 420);

            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("c", f, Brushes.Black, 310, 610);

            //Seventh line
            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("2", f, Brushes.Black, 120, 490);

            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("g", f, Brushes.Black, 590, 15);

            rect = new Rectangle(150, 470, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(220, 470, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(290, 470, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(360, 470, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(430, 470, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(500, 470, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(570, 470, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(640, 470, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("2", f, Brushes.Black, 715, 490);

            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("b", f, Brushes.Black, 240, 610);

            //Eighth line
            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("1", f, Brushes.Black, 120, 560);

            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("h", f, Brushes.Black, 660, 15);

            rect = new Rectangle(150, 540, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(220, 540, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(290, 540, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(360, 540, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(430, 540, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(500, 540, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(570, 540, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Gray, Color.Gray, 45.0f, true);
            g.FillRectangle(lgh, rect);

            rect = new Rectangle(640, 540, 70, 70);
            lgh = new LinearGradientBrush(rect, Color.Coral, Color.Coral, 45.0f, true);
            g.FillRectangle(lgh, rect);

            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("1", f, Brushes.Black, 715, 560);

            f = new Font("Verdana", 20, FontStyle.Italic);
            g.DrawString("a", f, Brushes.Black, 170, 610);

            g.Dispose();
        }
    }
}
