﻿using laba1igor.My_Classes;
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
        private MyPoint[] _points;
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
            X_size = pictureBox1.Width - 3;
            Y_size = pictureBox1.Height - 3;
            _rectangles = new MyRectangle[5];
            _points = new MyPoint[5];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            if (_iter == _rectangles.Length)
            {
                Array.Resize(ref _rectangles, _iter + 1);
                Array.Resize(ref _points, _iter + 1);
            }
            var x_cord = float.TryParse(textBox1.Text, out var x1);
            var y_cord = float.TryParse(textBox2.Text, out var y1);
            var Height = int.TryParse(textBox3.Text, out var H);
            var Width = int.TryParse(textBox4.Text, out var W);
            if (x_cord && y_cord && Height && Width)
            {
                if (x1 >= 3 && x1 + W <= X_size && y1 >= 3 && y1 + H <= Y_size)
                {
                    _points[_iter] = new MyPoint(x1,y1);
                    _rectangles[_iter] = new MyRectangle(_points[_iter], W, H);
                    _rectangles[_iter].Show(g);
                    _iter++;
                }
                else
                {
                    MessageBox.Show("Проверьте введеные данные!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
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
                    _points[i] = null;
                }
                _iter = 0;
                g.Clear(Color.WhiteSmoke);
                MessageBox.Show("Все прямоугольники будут очищены!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (checkIter && iterator >= 0 && iterator < _rectangles.Length && _rectangles[iterator] != null)
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
                    MessageBox.Show("Прямоугольника с таким номером нет!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
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
                        _rectangles[i].ResizeRectangle(g, RandW, RandH, X_size, Y_size, true);
                    }
                }
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (Width &&  Height)
                {
                    if (checkIter && iterator > 0 && iterator < _iter && _rectangles[iterator] != null)
                    {
                        g.Clear(Color.WhiteSmoke);

                       _rectangles[iterator].ResizeRectangle(g, W, H, X_size, Y_size, false);
                        for (var i = 0; i < _iter; i++)
                        {
                            if (i == iterator) continue;
                            if (_rectangles[i] != null) _rectangles[i].Show(g);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Прямоугольника с таким номером нет!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
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
                        float RandX = rand.Next(-50, 50);
                        float RandY = rand.Next(-50, 50);
                        _rectangles[i].MoveTo(g, RandX, RandY, X_size, Y_size, true);
                    }
                }
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (x && y)
                {
                    if (checkIter && iterator > 0 && iterator < _rectangles.Length  && _rectangles[iterator] != null )
                    {
                        g.Clear(Color.WhiteSmoke);


                        for (var i = 0; i < _iter; i++)
                        {
                            if (i == iterator)
                            {
                                _rectangles[i].MoveTo(g, newX, newY, X_size, Y_size, false);
                            }
                            else
                            {
                                if (_rectangles[i] != null) _rectangles[i].Show(g);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Прямоугольника с таким номером нет!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
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
            _rectangles[iter] = null;
            _points[iter] = null;
        }
        private void PictureBoxUpd()
        {
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = (Bitmap)buf.Clone();
        }
        private void RandomArray()
        {
            _rectangles = null;
            _points = null;
            g.Clear(Color.WhiteSmoke);
            var randIter = rand.Next(1, 10);
            _rectangles = new MyRectangle[randIter];
            _points = new MyPoint[randIter];
            _iter = randIter;


            for (var i = 0; i < _iter; i++)
            {
                _points[i] = new MyPoint(rand.Next(50, 800),
                                           rand.Next(50, 400));

                _rectangles[i] = new MyRectangle(_points[i],
                                            rand.Next(25, 100),
                                            rand.Next(25, 100));
                _rectangles[i].Show(g);
            }

            PictureBoxUpd();
        }
    }

}
