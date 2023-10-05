using laba1igor.My_Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace laba1igor
{
    public partial class Form_Square : Form
    {
        private MySquare[] _squares;
        private int _iter = 0;
        private int X_size = 877;
        private int Y_size = 500;
        private Random rand = new Random();
        public Form_Square()
        {
            InitializeComponent();
            buf = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(buf);
            g.Clear(Color.WhiteSmoke);
            _squares = new MySquare[5];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            if (_iter == _squares.Length)
            {
                Array.Resize(ref _squares, _iter + 1);
            }
            var x_cord = float.TryParse(textBox1.Text, out var x1);
            var y_cord = float.TryParse(textBox2.Text, out var y1);
            var Side = int.TryParse(textBox4.Text, out var S);
            if (x_cord && y_cord && Side)
            {
                if (x1 >= 0 && x1 + S <= X_size && y1 >= 0 && y1 + S <= Y_size && S > 0)
                {
                _squares[_iter] = new MySquare(x1, y1, S);
                _squares[_iter].Show(g);
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
                    _squares[i] = null;
                }
                _iter = 0;
                g.Clear(Color.WhiteSmoke);
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (checkIter && iterator < _squares.Length && _squares[iterator] != null)
                {
                    RectDispose(iterator);
                    g.Clear(Color.WhiteSmoke);
                    for (var i = 0; i < _iter; i++)
                    {
                        if (_squares[i] != null) _squares[i].Show(g);
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
            var Size = float.TryParse(textBox3.Text, out var S);
            var iterStr = textBox5.Text;
            if (iterStr == "")
            {
                g.Clear(Color.WhiteSmoke);
                for (var i = 0; i < _iter; i++)
                {
                    if (_squares[i] != null)
                    {
                        float RandSize = rand.Next(25, 150);
                        _squares[i].ResizeSquare(g, RandSize);
                    }
                }
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (Size && checkIter && _squares.Length > iterator && _squares[iterator] != null)
                {
                    if (iterator < _iter)
                    {
                        g.Clear(Color.WhiteSmoke);

                        _squares[iterator].ResizeSquare(g, S);
                        for (var i = 0; i < _iter; i++)
                        {
                            if (i == iterator) continue;
                            if (_squares[i] != null) _squares[i].Show(g);
                        }
                    }
                    else
                    {
                        label6.Text = "Прямоугольника с таким номером нет!";
                    }
                }
                else
                {
                    label6.Text = "Неверно введены данные!";
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
                    if (_squares[i] != null)
                    {
                        newX = rand.Next(-50, 50);
                        newY = rand.Next(-50, 50);
                        _squares[i].MoveTo(g, newX, newY);
                    }
                }
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (x && y && checkIter && iterator < _squares.Length && _squares[iterator] != null)
                {
                    if (_squares[iterator] != null)
                    {
                        g.Clear(Color.WhiteSmoke);


                        for (var i = 0; i < _iter; i++)
                        {
                            if (i == iterator)
                            {
                                _squares[i].MoveTo(g, newX, newY);
                            }
                            else
                            {
                                if (_squares[i] != null) _squares[i].Show(g);
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
            _squares[iter] = null;
        }
        private void PictureBoxUpd()
        {
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = (Bitmap)buf.Clone();
        }
        private void RandomArray()
        {
            label6.Text = "";
            _squares = null;
            g.Clear(Color.WhiteSmoke);
            var randIter = rand.Next(1, 10);
            _squares = new MySquare[randIter];
            _iter = randIter;


            for (var i = 0; i < _iter; i++)
            {
                _squares[i] = new MySquare(rand.Next(50, 800),
                                           rand.Next(50, 400),
                                           rand.Next(25, 100));
                _squares[i].Show(g);
            }

            PictureBoxUpd();
        }
    }

}
