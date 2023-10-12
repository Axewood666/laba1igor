using laba1igor.My_Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace laba1igor
{
    public partial class Form_Circle : Form
    {
        private MyCircle[] _circles;
        private MyPoint[] _points;
        private int _iter = 0;
        private int X_size;
        private int Y_size;
        private Random rand = new Random();
        public Form_Circle()
        {
            InitializeComponent();
            buf = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(buf);
            g.Clear(Color.WhiteSmoke);
            X_size = pictureBox1.Width - 3;
            Y_size = pictureBox1.Height - 3;
            _circles = new MyCircle[5];
            _points = new MyPoint[5];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_iter == _circles.Length)
            {
                Array.Resize(ref _circles, _iter + 1);
                Array.Resize(ref _points, _iter + 1);
            }
            var x_cord = int.TryParse(textBox1.Text, out var x1);
            var y_cord = int.TryParse(textBox2.Text, out var y1);
            var R = int.TryParse(textBox3.Text, out var radius);
            if (x_cord && y_cord && R && radius > 0)
            {
                if (x1 - radius >= 3 && x1 + radius <= X_size && y1 - radius >= 3 && y1 + radius <= Y_size)
                {
                    _points[_iter] = new MyPoint(x1, y1);
                    _circles[_iter] = new MyCircle(_points[_iter], radius, Color.DarkRed);
                    _circles[_iter].Show(g);
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
                    _circles[i] = null;
                    _points[i] = null;
                }
                _iter = 0;
                g.Clear(Color.WhiteSmoke);
                MessageBox.Show("Все круги будут очищены!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (checkIter && 0 <= iterator && iterator < _circles.Length && _circles[iterator] != null)
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
                    MessageBox.Show("Круга с таким номером нет!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                }
            }

            PictureBoxUpd();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var first = int.TryParse(textBox4.Text, out var newRadius);
            var iterStr = textBox5.Text;
            if (iterStr == "")
            {
                g.Clear(Color.WhiteSmoke);
                for (var i = 0; i < _iter; i++)
                {
                    if (_circles[i] != null)
                    {
                        newRadius = rand.Next(10, (int)Math.Min(Math.Min(_circles[i].CordPoint.XStart, X_size - _circles[i].CordPoint.XStart),
                            Math.Min(_circles[i].CordPoint.YStart, Y_size - _circles[i].CordPoint.YStart)) - 3);
                        _circles[i].ResizeCircle(g, newRadius);
                    }
                }
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (checkIter && iterator >= 0 && iterator < _iter && iterator < _circles.Length && _circles[iterator] != null)
                {
                    if (first && newRadius > 0)
                    {
                        if (newRadius < _circles[iterator].Radius || _circles[iterator].CordPoint.XStart + newRadius <= Y_size && _circles[iterator].CordPoint.YStart + newRadius <= Y_size
                                && _circles[iterator].CordPoint.XStart - newRadius >= 3 && _circles[iterator].CordPoint.YStart - newRadius >= 3)
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
                            MessageBox.Show("Выход за границы!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверно введен радиус!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    MessageBox.Show("Круга с таким номером нет!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                }
            }

            PictureBoxUpd();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            var first = int.TryParse(textBox6.Text, out var newX);
            var second = int.TryParse(textBox7.Text, out var newY);
            var iterStr = textBox5.Text;
            if (iterStr == "")
            {
                g.Clear(Color.WhiteSmoke);
                for (var i = 0; i < _iter; i++)
                {
                    if (_circles[i] != null)
                    {
                        newX = rand.Next(_circles[i].Radius + 3, X_size - _circles[i].Radius);
                        newY = rand.Next(_circles[i].Radius + 3, Y_size - _circles[i].Radius);
                        _circles[i].MoveTo(newX, newY, g);
                    }
                }
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (checkIter && 0 <= iterator && iterator < _circles.Length && _circles[iterator] != null)
                {
                    if (first && second)
                    {
                        if (_circles[iterator].Radius + newX < X_size && newX - _circles[iterator].Radius > 3
                            && _circles[iterator].Radius + newY < Y_size && newY - _circles[iterator].Radius > 3)

                        {

                            g.Clear(Color.WhiteSmoke);
                            for (var i = 0; i < _iter; i++)
                            {
                                if (i == iterator)
                                {
                                    _circles[i].MoveTo(newX, newY, g);
                                }
                                else
                                {
                                    if (_circles[i] != null) _circles[i].Show(g);
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
                    MessageBox.Show("Круга с таким номером нет!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                }
            }
            PictureBoxUpd();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            RandomArray();
        }
        private void CircleDispose(int iter)
        {
            _circles[iter] = null;
            _points[iter] = null;
        }
        private void PictureBoxUpd()
        {
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = (Bitmap)buf.Clone();
        }
        private void RandomArray()
        {
            _circles = null;
            _points = null;
            g.Clear(Color.WhiteSmoke);
            var randIter = rand.Next(1, 10);
            _circles = new MyCircle[randIter];
            _points = new MyPoint[randIter];
            _iter = randIter;


            for (var i = 0; i < _iter; i++)
            {
                _points[i] = new MyPoint(rand.Next(100, 750),
                                           rand.Next(100, 400));

                _circles[i] = new MyCircle(_points[i],
                                            rand.Next(25, 100), Color.DarkRed);
                _circles[i].Show(g);
            }

            PictureBoxUpd();
        }
    }

}
