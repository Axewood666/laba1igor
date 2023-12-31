﻿using laba1igor.My_Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace laba1igor
{
    public partial class Form_Line : Form
    {
        private MyEllipse[] _elipse;
        private MyPoint[] _points;
        private int _iter = 0;
        private int X_size;
        private int Y_size;
        private Random rand = new Random();
        public Form_Line()
        {
            InitializeComponent();
            X_size = pictureBox1.Width - 3;
            Y_size = pictureBox1.Height - 3;
            buf = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(buf);
            g.Clear(Color.WhiteSmoke);
            _elipse = new MyEllipse[5];
            _points = new MyPoint[5];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            if (_iter == _elipse.Length)
            {
                Array.Resize(ref _elipse, _iter + 1);
                Array.Resize(ref _points, _iter + 1);
            }
            var x_cord = int.TryParse(textBox1.Text, out var x1);
            var y_cord = int.TryParse(textBox2.Text, out var y1);
            var Height = int.TryParse(textBox3.Text, out var H);
            var Width = int.TryParse(textBox4.Text, out var W);
            if (x_cord && y_cord && Height && Width && H > 0 && W > 0)
            {
                if (x1 - W / 2 >= 3 && x1 + W / 2 <= X_size && y1 - H / 2 >= 3 && y1 + H / 2 <= Y_size)
                {
                    _points[_iter] = new MyPoint(x1, y1);
                    _elipse[_iter] = new MyEllipse(_points[_iter], W, H, Color.Aquamarine);
                    _elipse[_iter].Show(g);
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
            label6.Text = "";
            var iterStr = textBox5.Text;
            if (iterStr == "")
            {
                for (var i = _iter - 1; i >= 0; i--)
                {
                    _elipse[i] = null;
                    _points[i] = null;
                }
                _iter = 0;
                g.Clear(Color.WhiteSmoke);
                MessageBox.Show("Все эллипсы будут очищены!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (checkIter && iterator >= 0 && iterator < _elipse.Length && _elipse[iterator] != null)
                {
                    EllipseDispose(iterator);
                    g.Clear(Color.WhiteSmoke);
                    for (var i = 0; i < _iter; i++)
                    {
                        if (_elipse[i] != null)
                        {
                            _elipse[i].Show(g);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Эллипса с таким номером нет!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                }
            }

            PictureBoxUpd();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            var nHeight = int.TryParse(textBox6.Text, out var nH);
            var nWidth = int.TryParse(textBox7.Text, out var nW);
            var iterStr = textBox5.Text;
            if (iterStr == "")
            {
                g.Clear(Color.WhiteSmoke);
                for (var i = 0; i < _iter; i++)
                {
                    if (_elipse[i] != null)
                    {
                        int rNewW = rand.Next(1, (int)Math.Min(_elipse[i].CordPoint.XStart - 3, X_size - _elipse[i].CordPoint.XStart));
                        int rNewH = rand.Next(1, (int)Math.Min(_elipse[i].CordPoint.YStart - 3, Y_size - _elipse[i].CordPoint.YStart));
                        _elipse[i].ResizeEllipse(g, rNewW, rNewH);
                    }
                }
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (checkIter && iterator >= 0 && iterator < _iter && _elipse[iterator] != null)
                {
                    if (nHeight && nWidth && nH > 0 && nW > 0)
                    {
                        if ((nW < _elipse[iterator].Radius && nH < _elipse[iterator].YSize) || _elipse[iterator].CordPoint.XStart + nW / 2 <= X_size && _elipse[iterator].CordPoint.YStart + nH / 2 <= Y_size &&
                           _elipse[iterator].CordPoint.XStart - nW / 2 >= 3 && _elipse[iterator].CordPoint.YStart - nH / 2 >= 3)
                        {
                            g.Clear(Color.WhiteSmoke);

                            _elipse[iterator].ResizeEllipse(g, nW, nH);
                            for (var i = 0; i < _iter; i++)
                            {
                                if (i == iterator) continue;
                                if (_elipse[i] != null) _elipse[i].Show(g);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Размер выходит за границы", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверно введен размер!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    MessageBox.Show("Эллипса с таким номером нет!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
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
                    if (_elipse[i] != null)
                    {
                        newX = rand.Next(_elipse[i].Radius / 2 + 3, X_size - _elipse[i].Radius / 2);
                        newY = rand.Next(_elipse[i].YSize / 2 + 3, Y_size - _elipse[i].YSize / 2);
                        _elipse[i].MoveTo(newX, newY, g);
                    }
                }
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (checkIter && iterator >= 0 && iterator < _elipse.Length && _elipse[iterator] != null)
                {
                    if (x && y)
                    {
                        if (_elipse[iterator].Radius / 2 + newX < X_size && newX - _elipse[iterator].Radius / 2 > 3
                            && _elipse[iterator].YSize / 2 + newY < Y_size && newY - _elipse[iterator].YSize / 2 > 3)
                        {
                            g.Clear(Color.WhiteSmoke);


                            for (var i = 0; i < _iter; i++)
                            {
                                if (i == iterator)
                                {
                                    _elipse[i].MoveTo(newX, newY, g);
                                }
                                else
                                {
                                    if (_elipse[i] != null) _elipse[i].Show(g);
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
                        MessageBox.Show("Неверно введены координаты!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    MessageBox.Show("Эллипса с таким номером нет!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
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
        private void button6_Click(object sender, EventArgs e)
        {
            var iterStr = textBox5.Text;
            if (iterStr == "")
            {
                g.Clear(Color.WhiteSmoke);
                for (var i = 0; i < _iter; i++)
                {
                    if (_elipse[i] != null)
                    {
                        if (_elipse[i].CordPoint.XStart + _elipse[i].YSize / 2 <= X_size && _elipse[i].CordPoint.YStart + _elipse[i].Radius / 2 <= Y_size && _elipse[i].CordPoint.XStart - _elipse[i].YSize / 2 >= 3 && 
                            _elipse[i].CordPoint.YStart - _elipse[i].Radius / 2 >= 3)
                            _elipse[i].ReverseEllipse(g);
                        else
                        {
                            _elipse[i].Show(g);
                        }
                    }

                }
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (checkIter && iterator >= 0 && iterator < _elipse.Length && _elipse[iterator] != null)
                {
                    if (_elipse[iterator].CordPoint.XStart + _elipse[iterator].YSize / 2 <= X_size && _elipse[iterator].CordPoint.YStart + _elipse[iterator].Radius / 2 <= Y_size 
                        && _elipse[iterator].CordPoint.XStart - _elipse[iterator].YSize / 2 >= 3 && _elipse[iterator].CordPoint.YStart - _elipse[iterator].Radius / 2 >= 3)
                    {
                        g.Clear(Color.WhiteSmoke);


                        for (var i = 0; i < _iter; i++)
                        {
                            if (i == iterator)
                            {
                                _elipse[i].ReverseEllipse(g);
                            }
                            else
                            {
                                if (_elipse[i] != null) _elipse[i].Show(g);
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
                    MessageBox.Show("Ромба с таким номером нет!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                }
            }
            PictureBoxUpd();
        }
        private void EllipseDispose(int iter)
        {
            _elipse[iter] = null;
            _points[iter] = null;
        }
        private void PictureBoxUpd()
        {
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = (Bitmap)buf.Clone();
        }
        private void RandomArray()
        {
            _elipse = null;
            _points = null;
            g.Clear(Color.WhiteSmoke);
            var randIter = rand.Next(1, 10);
            _elipse = new MyEllipse[randIter];
            _points = new MyPoint[randIter];
            _iter = randIter;


            for (var i = 0; i < _iter; i++)
            {
                _points[i] = new MyPoint(rand.Next(60, 770),
                                           rand.Next(60, 390));
                _elipse[i] = new MyEllipse(_points[i],
                                            rand.Next(20, 120),
                                            rand.Next(20, 120), Color.Aquamarine);
                _elipse[i].Show(g);
            }

            PictureBoxUpd();
        }
    }

}
