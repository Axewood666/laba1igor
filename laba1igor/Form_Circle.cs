using laba1igor.My_Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace laba1igor
{
    public partial class Form_Circle : Form
    {
        private MyCircle[] _circles;
        private int _iter = 0;
        private int X_size = 877;
        private int Y_size = 500;
        private Random rand = new Random();
        public Form_Circle()
        {
            InitializeComponent();
            buf = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(buf);
            g.Clear(Color.WhiteSmoke);
            _circles = new MyCircle[5];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            if (_iter == _circles.Length)
            {
                Array.Resize(ref _circles, _iter + 1);
            }
            var x_cord = float.TryParse(textBox1.Text, out var x1);
            var y_cord = float.TryParse(textBox2.Text, out var y1);
            var R = float.TryParse(textBox3.Text, out var radius);
            if (x_cord && y_cord && R)
            {
                if (x1-radius >= 0 && x1 + radius <= X_size && y1-radius >= 0 && y1 + radius <= Y_size && radius > 0)
                {
                    _circles[_iter] = new MyCircle(x1, y1, radius);
                    _circles[_iter].Show(g);
                    _iter++;
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
                    _circles[i] = null;
                }
                _iter = 0;
                g.Clear(Color.WhiteSmoke);
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (checkIter && iterator < _circles.Length  && _circles[iterator] != null)
                {   
                    CircleDispose(iterator);
                    g.Clear(Color.WhiteSmoke);
                    for (var i = 0; i < _iter; i++)
                    {
                        if (_circles[i] != null) _circles[i].Show(g);
                    }
                }
                else
                {
                    label6.Text = "Круга с таким номером нет!";
                }
            }

            PictureBoxUpd();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            var first = float.TryParse(textBox4.Text, out var newRadius);
            var iterStr = textBox5.Text;
            if (iterStr == "")
            {
                g.Clear(Color.WhiteSmoke);
                for (var i = 0; i < _iter; i++)
                {
                    if (_circles[i] != null)
                    {
                        newRadius = rand.Next(25, 150);
                        _circles[i].ResizeCircle(g, newRadius);
                    }
                }
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (first && checkIter && iterator < _circles.Length && _circles[iterator] != null)
                {
                    if (iterator < _iter)
                    {
                        g.Clear(Color.WhiteSmoke);

                        _circles[iterator].ResizeCircle(g, newRadius);
                        for (var i = 0; i < _iter; i++)
                        {
                            if (i == iterator) continue;
                            if (_circles[i] != null) _circles[i].Show(g);
                        }
                    }
                    else
                    {
                        label6.Text = "Круга с таким номером нет!";
                    }
                }
                else
                {
                    label6.Text = "Неверно введен радиус!";
                }
            }

            PictureBoxUpd();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            var first = float.TryParse(textBox6.Text, out var newX);
            var second = float.TryParse(textBox7.Text, out var newY);
            var iterStr = textBox5.Text;
            if (iterStr == "")
            {
                g.Clear(Color.WhiteSmoke);
                for (var i = 0; i < _iter; i++)
                {
                    if (_circles[i] != null)
                    {
                        newX = rand.Next(-50, 50);
                        newY = rand.Next(-50, 50);
                        _circles[i].MoveTo(g, newX, newY);
                    }
                }
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (first && second && checkIter)
                {
                    if (iterator < _circles.Length && _circles[iterator] != null)
                    {
                        g.Clear(Color.WhiteSmoke);


                        for (var i = 0; i < _iter; i++)
                        {
                            if (i == iterator)
                            {
                                _circles[i].MoveTo(g, newX, newY);
                            }
                            else
                            {
                                if (_circles[i] != null) _circles[i].Show(g);
                            }
                        }
                    }
                    else
                    {
                        label6.Text = "Круга с таким номером нет!";
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
        private void CircleDispose(int iter)
        {
            _circles[iter] = null;
        }
        private void PictureBoxUpd()
        {
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = (Bitmap)buf.Clone();
        }
        private void RandomArray()
        {
            _circles = null;
            g.Clear(Color.WhiteSmoke);
            var randIter = rand.Next(1, 10);
            _circles = new MyCircle[randIter];
            _iter = randIter;


            for (var i = 0; i < _iter; i++)
            {
                _circles[i] = new MyCircle(rand.Next(100, 750),
                                           rand.Next(100, 400),
                                            rand.Next(25, 100));
                _circles[i].Show(g);
            }

            PictureBoxUpd();
        }
    }

}
