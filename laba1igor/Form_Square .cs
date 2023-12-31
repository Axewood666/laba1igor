﻿using laba1igor.My_Classes;
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
        private MyPoint[] _points;
        private int _iter = 0;
        private int X_size;
        private int Y_size;
        private Random rand = new Random();
        public Form_Square()
        {
            InitializeComponent();
            buf = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(buf);
            g.Clear(Color.WhiteSmoke);
            X_size = pictureBox1.Width - 3;
            Y_size = pictureBox1.Height - 3;
            _squares = new MySquare[5];
            _points = new MyPoint[5];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            if (_iter == _squares.Length)
            {
                Array.Resize(ref _squares, _iter + 1);
                Array.Resize(ref _points, _iter + 1);
            }
            var x_cord = int.TryParse(textBox1.Text, out var x1);
            var y_cord = int.TryParse(textBox2.Text, out var y1);
            var Side = int.TryParse(textBox4.Text, out var S);
            if (x_cord && y_cord && Side && S > 0)
            {
                if (x1 >= 3 && x1 + S <= X_size && y1 >= 3 && y1 + S <= Y_size)
                {
                    _points[_iter] = new MyPoint(x1, y1);
                    _squares[_iter] = new MySquare(_points[_iter], S);
                    _squares[_iter].Show(g);
                    _iter++;
                }
                else
                {
                    MessageBox.Show("Выход за границы!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show("Неверно введены данные!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
            }
            PictureBoxUpd();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var iterStr = textBox5.Text;
            if (iterStr == "")
            {
                for (var i = _iter - 1; i >= 0; i--)
                {
                    _squares[i] = null;
                    _points[i] = null;
                }
                _iter = 0;
                g.Clear(Color.WhiteSmoke);
                MessageBox.Show("Все квадраты будут очищены!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (checkIter && iterator >= 0 && iterator < _squares.Length && _squares[iterator] != null)
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
                    MessageBox.Show("Квадрата с таким номером нет!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                }
            }

            PictureBoxUpd();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            var Size = int.TryParse(textBox3.Text, out var S);
            var iterStr = textBox5.Text;
            if (iterStr == "")
            {
                g.Clear(Color.WhiteSmoke);
                for (var i = 0; i < _iter; i++)
                {
                    if (_squares[i] != null)
                    {
                        int RandSize = rand.Next(10, Math.Min((int)(X_size - _squares[i].CordPoint.XStart), (int)(Y_size - _squares[i].CordPoint.YStart)));
                        _squares[i].ResizeQua(RandSize, RandSize);
                        _squares[i].Show(g);
                    }
                }
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (checkIter && iterator >= 0 && iterator < _iter && _squares[iterator] != null)
                {
                    if (Size && S > 0)
                    {
                        if (S < _squares[iterator].Width || _squares[iterator].CordPoint.XStart + S <= X_size && _squares[iterator].CordPoint.YStart + S <= Y_size)
                        {
                            g.Clear(Color.WhiteSmoke);

                            _squares[iterator].ResizeQua(S, S);
                            for (var i = 0; i < _iter; i++)
                            {
                                if (_squares[i] != null) _squares[i].Show(g);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Размер выходит за границы!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Квадрата с таким номером нет!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    MessageBox.Show("Неверно введен размер!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                }
            }

            PictureBoxUpd();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            var x = int.TryParse(textBox6.Text, out var newX);
            var y = int.TryParse(textBox7.Text, out var newY);
            var iterStr = textBox5.Text;
            if (iterStr == "")
            {
                g.Clear(Color.WhiteSmoke);
                for (var i = 0; i < _iter; i++)
                {
                    if (_squares[i] != null)
                    {
                        newX = rand.Next(3, X_size - (int)_squares[i].Width);
                        newY = rand.Next(3, Y_size - (int)_squares[i].Width);
                        _squares[i].MoveTo(newX, newY, g);
                    }
                }
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (checkIter && iterator >= 0 && iterator < _squares.Length && _squares[iterator] != null)
                {
                    if (x && y)
                    {
                        if (newX > 3 && newY > 3 && newX + _squares[iterator].Width < X_size && newY + _squares[iterator].Width < Y_size)
                        {
                            g.Clear(Color.WhiteSmoke);


                            for (var i = 0; i < _iter; i++)
                            {
                                if (i == iterator)
                                {
                                    _squares[i].MoveTo(newX, newY, g);
                                }
                                else
                                {
                                    if (_squares[i] != null) _squares[i].Show(g);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выход за границы!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Квадрата с таким номером нет!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    MessageBox.Show("Неверно введены координаты!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
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
            _points[iter] = null;
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
            _points = null;
            g.Clear(Color.WhiteSmoke);
            var randIter = rand.Next(1, 10);
            _squares = new MySquare[randIter];
            _points = new MyPoint[randIter];
            _iter = randIter;


            for (var i = 0; i < _iter; i++)
            {
                _points[i] = new MyPoint(rand.Next(50, 800),
                                           rand.Next(50, 400));
                _squares[i] = new MySquare(_points[i],
                                           rand.Next(25, 100));
                _squares[i].Show(g);
            }

            PictureBoxUpd();
        }
    }

}
