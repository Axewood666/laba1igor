using laba1igor.My_Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace laba1igor
{
    public partial class Form_Rect : Form
    {
        private MyRectangle[] _rectangles;
        private int _iter = 0;
        private int X_size;
        private int Y_size;
        private Random rand = new Random();
        public Form_Rect()
        {
            InitializeComponent();
            buf = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(buf);
            g.Clear(Color.WhiteSmoke);
            X_size = pictureBox1.Width;
            Y_size = pictureBox1.Height;
            _rectangles = new MyRectangle[5];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            if (_iter == _rectangles.Length)
            {
                Array.Resize(ref _rectangles, _iter + 1);
            }
            var x_cord = float.TryParse(textBox1.Text, out var x1);
            var y_cord = float.TryParse(textBox2.Text, out var y1);
            var Height = int.TryParse(textBox3.Text, out var H);
            var Width = int.TryParse(textBox4.Text, out var W);
            if (x_cord && y_cord && Height && Width)
            {
                if (x1 >= 0 && x1 + W <= X_size && y1 >= 0 && y1 + H <= Y_size)
                {
                    _rectangles[_iter] = new MyRectangle(x1, y1, W, H);
                    _rectangles[_iter].Show(g);
                    _iter++;
                }
                else
                {
                    label6.Text = "Неверно введены данные";
                }
            }
           PictureBoxUpd();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            var iterStr = textBox5.Text;
            if (iterStr == "")
            {
                for (var i = _iter - 1; i >= 0; i--)
                {
                    _rectangles[i] = null;
                }
                _iter = 0;
                g.Clear(Color.WhiteSmoke);
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (checkIter && iterator < _rectangles.Length && _rectangles[iterator] != null)
                {
                    RectDispose(iterator);
                    g.Clear(Color.WhiteSmoke);
                    for (var i = 0; i < _iter; i++)
                    {
                        if (_rectangles[i] != null) _rectangles[i].Show(g);
                    }
                }
                else
                {
                    label6.Text = "прямоугольника с таким номером нет!";
                }
            }

            PictureBoxUpd();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            var Width = float.TryParse(textBox6.Text, out var W);
            var Height = float.TryParse(textBox7.Text, out var H);
            var iterStr = textBox5.Text;
            if (iterStr == "")
            {
                g.Clear(Color.WhiteSmoke);
                for (var i = 0; i < _iter; i++)
                {
                    if (_rectangles[i] != null)
                    {   
                        float RandH = rand.Next(10, 80);
                        float RandW = rand.Next(10, 80);
                        _rectangles[i].ResizeRectangle(g, RandW, RandH);
                    }
                }
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (Width && checkIter && Height)
                {
                    if (iterator < _iter)
                    {
                        g.Clear(Color.WhiteSmoke);

                        if (_rectangles[iterator] != null) _rectangles[iterator].ResizeRectangle(g, W, H);
                        else label6.Text = "прямоугольника с таким номером нет!";
                        for (var i = 0; i < _iter; i++)
                        {
                            if (i == iterator) continue;
                            if (_rectangles[i] != null) _rectangles[i].Show(g);
                        }
                    }
                    else
                    {
                        label6.Text = "Прямоугольника с таким номером нет!";
                    }
                }
                else
                {
                    label6.Text = "Неверно введены координаты!";
                }
            }

            PictureBoxUpd();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            var x = float.TryParse(textBox6.Text, out var newX);
            var y = float.TryParse(textBox7.Text, out var newY);
            var iterStr = textBox5.Text;
            if (iterStr == "")
            {
                g.Clear(Color.WhiteSmoke);
                for (var i = 0; i < _iter; i++)
                {
                    if (_rectangles[i] != null)
                    {
                        newX = rand.Next(-50, 50);
                        newY = rand.Next(-50, 50);
                        _rectangles[i].MoveTo(g, newX, newY);
                    }
                }
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (x && y && checkIter)
                {
                    if (iterator < _rectangles.Length  && _rectangles[iterator] != null )
                    {
                        g.Clear(Color.WhiteSmoke);


                        for (var i = 0; i < _iter; i++)
                        {
                            if (i == iterator)
                            {
                                _rectangles[i].MoveTo(g, newX, newY);
                            }
                            else
                            {
                                if (_rectangles[i] != null) _rectangles[i].Show(g);
                            }
                        }
                    }
                    else
                    {
                        label6.Text = "Прямоугольника с таким номером нет!";
                    }
                }
                else
                {
                    label6.Text = "Неверно введены координаты!";
                }
            }
            PictureBoxUpd();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            RandomArray();
        }
        private void RectDispose(int iter)
        {
            _rectangles[iter] = null;
        }
        private void PictureBoxUpd()
        {
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = (Bitmap)buf.Clone();
        }
        private void RandomArray()
        {
            _rectangles = null;
            g.Clear(Color.WhiteSmoke);
            var randIter = rand.Next(1, 10);
            _rectangles = new MyRectangle[randIter];
            _iter = randIter;


            for (var i = 0; i < _iter; i++)
            {
                _rectangles[i] = new MyRectangle(rand.Next(50, 800),
                                           rand.Next(50, 400),
                                            rand.Next(25, 100),
                                            rand.Next(25,100));
                _rectangles[i].Show(g);
            }

            PictureBoxUpd();
        }
    }

}
