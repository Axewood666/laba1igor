using laba1igor.My_Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace laba1igor
{
    public partial class Form_Ring : Form
    {
        private MyRing[] _rings;
        private MyPoint[] _points;
        private int _iter = 0;
        private int X_size;
        private int Y_size;
        private Random rand = new Random();
        public Form_Ring()
        {
            InitializeComponent();
            buf = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(buf);
            g.Clear(Color.WhiteSmoke);
            X_size = pictureBox1.Width - 3;
            Y_size = pictureBox1.Height - 3;
            _rings = new MyRing[5];
            _points = new MyPoint[5];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_iter == _rings.Length)
            {
                Array.Resize(ref _rings, _iter + 1);
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
                    _rings[_iter] = new MyRing(_points[_iter], radius, Color.DarkGoldenrod);
                    _rings[_iter].Show(g);
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
                    _rings[i] = null;
                    _points[i] = null;
                }
                _iter = 0;
                g.Clear(Color.WhiteSmoke);
                MessageBox.Show("Все кольца будут очищены!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (checkIter && 0 <= iterator && iterator < _rings.Length && _rings[iterator] != null)
                {
                    CircleDispose(iterator);
                    g.Clear(Color.WhiteSmoke);
                    for (var i = 0; i < _iter; i++)
                    {
                        if (_rings[i] != null) _rings[i].Show(g);
                    }
                }
                else
                {
                    MessageBox.Show("Кольца с таким номером нет!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
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
                    if (_rings[i] != null)
                    {
                        newRadius = rand.Next(10, (int)Math.Min(Math.Min(_rings[i].circle1.CordPoint.XStart, X_size - _rings[i].circle1.CordPoint.XStart),
                            Math.Min(_rings[i].circle1.CordPoint.YStart, Y_size - _rings[i].circle1.CordPoint.YStart)) - 3);
                        _rings[i].ResizeRing(g, newRadius);
                    }
                }
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (checkIter && iterator >= 0 && iterator < _iter && iterator < _rings.Length && _rings[iterator] != null)
                {
                    if (first && newRadius > 0)
                    {
                        if (newRadius < _rings[iterator].circle1.Radius || _rings[iterator].circle1.CordPoint.XStart + newRadius <= Y_size && _rings[iterator].circle1.CordPoint.YStart + newRadius <= Y_size
                                && _rings[iterator].circle1.CordPoint.XStart - newRadius >= 3 && _rings[iterator].circle1.CordPoint.YStart - newRadius >= 3)
                        {
                            g.Clear(Color.WhiteSmoke);

                            _rings[iterator].ResizeRing(g, newRadius);
                            for (var i = 0; i < _iter; i++)
                            {
                                if (i == iterator) continue;
                                if (_rings[i] != null) _rings[i].Show(g);
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
                        MessageBox.Show("Кольца с таким номером нет!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    MessageBox.Show("Неверно введен радиус!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
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
                    if (_rings[i] != null)
                    {
                        newX = rand.Next(_rings[i].circle1.Radius + 3, X_size - _rings[i].circle1.Radius);
                        newY = rand.Next(_rings[i].circle1.Radius + 3, Y_size - _rings[i].circle1.Radius);
                        _rings[i].MoveTo(g, newX, newY);
                    }
                }
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (checkIter && 0 <= iterator && iterator < _rings.Length && _rings[iterator] != null)
                {
                    if (first && second)
                    {
                        if (_rings[iterator].circle1.Radius + newX < X_size && newX - _rings[iterator].circle1.Radius > 3
                            && _rings[iterator].circle1.Radius + newY < Y_size && newY - _rings[iterator].circle1.Radius > 3)
                        {
                            g.Clear(Color.WhiteSmoke);


                            for (var i = 0; i < _iter; i++)
                            {
                                if (i == iterator)
                                {
                                    _rings[i].MoveTo(g, newX, newY);
                                }
                                else
                                {
                                    if (_rings[i] != null) _rings[i].Show(g);
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
                    MessageBox.Show("Кольца с таким номером нет!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
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
            _rings[iter] = null;
            _points[iter] = null;
        }
        private void PictureBoxUpd()
        {
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = (Bitmap)buf.Clone();
        }
        private void RandomArray()
        {
            _rings = null;
            _points = null;
            g.Clear(Color.WhiteSmoke);
            var randIter = rand.Next(1, 10);
            _rings = new MyRing[randIter];
            _points = new MyPoint[randIter];
            _iter = randIter;


            for (var i = 0; i < _iter; i++)
            {
                _points[i] = new MyPoint(rand.Next(100, 750),
                                           rand.Next(100, 400));

                _rings[i] = new MyRing(_points[i],
                                            rand.Next(25, 100), Color.DarkRed);
                _rings[i].Show(g);
            }

            PictureBoxUpd();
        }
    }

}
