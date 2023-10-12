using laba1igor.My_Classes;
using MyGraphicLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace laba1igor
{
    public partial class Form_Trapezoid : Form
    {
        private MyTrapezoid[] _trapezoids;
        private MyPoint[] _points;
        private int _iter = 0;
        private int X_size;
        private int Y_size;
        private Random rand = new Random();
        public Form_Trapezoid()
        {
            InitializeComponent();
            buf = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(buf);
            g.Clear(Color.WhiteSmoke);
            X_size = pictureBox1.Width - 3;
            Y_size = pictureBox1.Height - 3;
            _trapezoids = new MyTrapezoid[5];
            _points = new MyPoint[5];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            if (_iter == _trapezoids.Length)
            {
                Array.Resize(ref _trapezoids, _iter + 1);
                Array.Resize(ref _points, _iter + 1);
            }
            var x_cord = int.TryParse(textBox1.Text, out var x1);
            var y_cord = int.TryParse(textBox2.Text, out var y1);
            var Height = int.TryParse(textBox3.Text, out var H);
            var Width = int.TryParse(textBox4.Text, out var W);
            if (x_cord && y_cord && Height && Width && H > 0 && W > 0)
            {
                if (x1 >= 3 && x1 + W <= X_size && y1 - H >= 3 && y1 <= Y_size)
                {
                    _points[_iter] = new MyPoint(x1, y1);
                    _trapezoids[_iter] = new MyTrapezoid(_points[_iter], W, H);
                    _trapezoids[_iter].Show(g);
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
                MessageBox.Show("Неверно введены данные", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
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
                    _trapezoids[i] = null;
                    _points[i] = null;
                }
                _iter = 0;
                g.Clear(Color.WhiteSmoke);
                MessageBox.Show("Все трапеции будут очищены!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (checkIter && iterator >= 0 && iterator < _trapezoids.Length && _trapezoids[iterator] != null)
                {
                    RectDispose(iterator);
                    g.Clear(Color.WhiteSmoke);
                    for (var i = 0; i < _iter; i++)
                    {
                        if (_trapezoids[i] != null) _trapezoids[i].Show(g);
                    }
                }
                else
                {
                    MessageBox.Show("Трапеции с таким номером нет!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                }
            }

            PictureBoxUpd();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            var Width = int.TryParse(textBox6.Text, out var W);
            var Height = int.TryParse(textBox7.Text, out var H);
            var iterStr = textBox5.Text;
            if (iterStr == "")
            {
                g.Clear(Color.WhiteSmoke);
                for (var i = 0; i < _iter; i++)
                {
                    if (_trapezoids[i] != null)
                    {
                        int RandW = rand.Next(1, X_size - _trapezoids[i].CordPoint.XStart);
                        int RandH = rand.Next(1, _trapezoids[i].CordPoint.YStart);
                        _trapezoids[i].ResizeQua(RandW, RandH);
                        _trapezoids[i].Show(g);
                    }
                }
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (checkIter && iterator >= 0 && iterator < _iter && _trapezoids[iterator] != null)
                {
                    if (Width && Height && W > 0 && H > 0)
                    {
                        if ((W < _trapezoids[iterator].Width && H < _trapezoids[iterator].Height) || _trapezoids[iterator].CordPoint.XStart + W <= X_size && _trapezoids[iterator].CordPoint.YStart - H >= 3)
                        {
                            g.Clear(Color.WhiteSmoke);

                            _trapezoids[iterator].ResizeQua(W, H);
                            for (var i = 0; i < _iter; i++)
                            {
                                if (_trapezoids[i] != null) _trapezoids[i].Show(g);
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
                    MessageBox.Show("Трапеции с таким номером нет!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
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
                    if (_trapezoids[i] != null)
                    {
                        int RandX = rand.Next(3, X_size - _trapezoids[i].Width);
                        int RandY = rand.Next(_trapezoids[i].Height + 3, Y_size);
                        _trapezoids[i].MoveTo(RandX, RandY);
                        _trapezoids[i].Show(g);
                    }
                }
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (checkIter && iterator >= 0 && iterator < _trapezoids.Length && _trapezoids[iterator] != null)
                {
                    if (x && y)
                    {
                        if (newX >= 3 && newX + _trapezoids[iterator].Width < X_size && newY - _trapezoids[iterator].Height >= 3)
                        {
                            g.Clear(Color.WhiteSmoke);


                            for (var i = 0; i < _iter; i++)
                            {
                                if (i == iterator)
                                {
                                    _trapezoids[i].MoveTo(newX, newY);
                                    _trapezoids[i].Show(g);
                                }
                                else
                                {
                                    if (_trapezoids[i] != null) _trapezoids[i].Show(g);
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
                    MessageBox.Show("Трапеции с таким номером нет!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
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
                    if (_trapezoids[i] != null)
                    {
                        if (_trapezoids[i].CordPoint.XStart + _trapezoids[i].Height <= X_size && _trapezoids[i].CordPoint.YStart - _trapezoids[i].Width >= 3)
                        {
                            _trapezoids[i].ReverseQua();
                            _trapezoids[i].Show(g);
                        }

                        else
                        {
                            _trapezoids[i].Show(g);
                        }
                    }

                }
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (checkIter && iterator >= 0 && iterator < _trapezoids.Length && _trapezoids[iterator] != null)
                {
                    if (_trapezoids[iterator].CordPoint.XStart + _trapezoids[iterator].Height <= X_size && _trapezoids[iterator].CordPoint.YStart - _trapezoids[iterator].Width >= 3)
                    {
                        g.Clear(Color.WhiteSmoke);


                        for (var i = 0; i < _iter; i++)
                        {
                            if (i == iterator)
                            {
                                _trapezoids[i].ReverseQua();
                                _trapezoids[i].Show(g);
                            }
                            else
                            {
                                if (_trapezoids[i] != null) _trapezoids[i].Show(g);
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
                    MessageBox.Show("Трапеции с таким номером нет!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                }
            }
            PictureBoxUpd();
        }
        private void RectDispose(int iter)
        {
            _trapezoids[iter] = null;
            _points[iter] = null;
        }
        private void PictureBoxUpd()
        {
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = (Bitmap)buf.Clone();
        }
        private void RandomArray()
        {
            _trapezoids = null;
            _points = null;
            g.Clear(Color.WhiteSmoke);
            var randIter = rand.Next(1, 10);
            _trapezoids = new MyTrapezoid[randIter];
            _points = new MyPoint[randIter];
            _iter = randIter;


            for (var i = 0; i < _iter; i++)
            {
                _points[i] = new MyPoint(rand.Next(50, 800),
                                           rand.Next(50, 400));

                _trapezoids[i] = new MyTrapezoid(_points[i],
                                            rand.Next(25, 100),
                                            rand.Next(25, 100));
                _trapezoids[i].Show(g);
            }

            PictureBoxUpd();
        }
    }

}
