using laba1igor.My_Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace laba1igor
{
    public partial class Form_Rhombus : Form
    {
        private MyRhombus[] _rhombus;
        private MyPoint[] _points;
        private int _iter = 0;
        private int X_size;
        private int Y_size;
        private Random rand = new Random();
        public Form_Rhombus()
        {
            InitializeComponent();
            buf = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(buf);
            g.Clear(Color.WhiteSmoke);
            X_size = pictureBox1.Width - 3;
            Y_size = pictureBox1.Height - 3;
            _rhombus = new MyRhombus[5];
            _points = new MyPoint[5];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            if (_iter == _rhombus.Length)
            {
                Array.Resize(ref _rhombus, _iter + 1);
                Array.Resize(ref _points, _iter + 1);
            }
            var x_cord = float.TryParse(textBox1.Text, out var x1);
            var y_cord = float.TryParse(textBox2.Text, out var y1);
            var Height = int.TryParse(textBox3.Text, out var H);
            var Width = int.TryParse(textBox4.Text, out var W);
            if (x_cord && y_cord && Height && Width && H > 0 && W > 0)
            {
                if (x1 >= 3 && x1 + W <= X_size && y1 >= 3 && y1 + H <= Y_size)
                {
                    _points[_iter] = new MyPoint(x1, y1);
                    _rhombus[_iter] = new MyRhombus(_points[_iter], W, H);
                    _rhombus[_iter].Show(g);
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
                    _rhombus[i] = null;
                    _points[i] = null;
                }
                _iter = 0;
                g.Clear(Color.WhiteSmoke);
                MessageBox.Show("Все ромбы будут очищены!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (checkIter && iterator >= 0 && iterator < _rhombus.Length && _rhombus[iterator] != null)
                {
                    RectDispose(iterator);
                    g.Clear(Color.WhiteSmoke);
                    for (var i = 0; i < _iter; i++)
                    {
                        if (_rhombus[i] != null) _rhombus[i].Show(g);
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
                    if (_rhombus[i] != null)
                    {
                        int RandW = rand.Next(10, (int)(X_size - _rhombus[i].CordPoint.XStart));
                        int RandH = rand.Next(10, (int)(Y_size - _rhombus[i].CordPoint.YStart));
                        _rhombus[i].ResizeRhombus(g, RandW, RandH);
                    }
                }
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (checkIter && iterator >= 0 && iterator < _iter && _rhombus[iterator] != null)
                {
                    if (Width && Height && W > 0 && H > 0)
                    {
                        if ((W < _rhombus[iterator].Width && H < _rhombus[iterator].Height) || _rhombus[iterator].CordPoint.XStart + W <= X_size && _rhombus[iterator].CordPoint.YStart + H <= Y_size)
                        {
                            g.Clear(Color.WhiteSmoke);

                            _rhombus[iterator].ResizeRhombus(g, W, H);
                            for (var i = 0; i < _iter; i++)
                            {
                                if (i == iterator) continue;
                                if (_rhombus[i] != null) _rhombus[i].Show(g);
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
                    MessageBox.Show("Ромба с таким номером нет!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                }
            }

            PictureBoxUpd();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            var x = float.TryParse(textBox6.Text, out var newX);
            var y = float.TryParse(textBox7.Text, out var newY);
            var iterStr = textBox5.Text;
            if (iterStr == "")
            {
                g.Clear(Color.WhiteSmoke);
                for (var i = 0; i < _iter; i++)
                {
                    if (_rhombus[i] != null)
                    {
                        float RandX = rand.Next(3, (int)(X_size - _rhombus[i].Width));
                        float RandY = rand.Next(3, (int)(Y_size - _rhombus[i].Height));
                        _rhombus[i].MoveTo(RandX, RandY);
                        _rhombus[i].Show(g);
                    }
                }
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (checkIter && iterator >= 0 && iterator < _rhombus.Length && _rhombus[iterator] != null)
                {
                    if (x && y)
                    {
                        if (newX > 3 && newY > 3 && newX + _rhombus[iterator].Width < X_size && newY + _rhombus[iterator].Height < Y_size)
                        {
                            g.Clear(Color.WhiteSmoke);


                            for (var i = 0; i < _iter; i++)
                            {
                                if (i == iterator)
                                {
                                    _rhombus[i].MoveTo(newX, newY);
                                    _rhombus[i].Show(g);
                                }
                                else
                                {
                                    if (_rhombus[i] != null) _rhombus[i].Show(g);
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
                    MessageBox.Show("Ромба с таким номером нет!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
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
                    if (_rhombus[i] != null)
                    {
                        if (_rhombus[i].CordPoint.XStart + _rhombus[i].Height <= X_size && _rhombus[i].CordPoint.YStart + _rhombus[i].Width <= Y_size)
                            _rhombus[i].ReverseRhombus(g);
                        else
                        {
                            _rhombus[i].Show(g);
                        }
                    }

                }
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (checkIter && iterator >= 0 && iterator < _rhombus.Length && _rhombus[iterator] != null)
                {
                    if (_rhombus[iterator].CordPoint.XStart + _rhombus[iterator].Height <= X_size && _rhombus[iterator].CordPoint.YStart + _rhombus[iterator].Width <= Y_size)
                    {
                        g.Clear(Color.WhiteSmoke);


                        for (var i = 0; i < _iter; i++)
                        {
                            if (i == iterator)
                            {
                                _rhombus[i].ReverseRhombus(g);
                            }
                            else
                            {
                                if (_rhombus[i] != null) _rhombus[i].Show(g);
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
        private void RectDispose(int iter)
        {
            _rhombus[iter] = null;
            _points[iter] = null;
        }
        private void PictureBoxUpd()
        {
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = (Bitmap)buf.Clone();
        }
        private void RandomArray()
        {
            _rhombus = null;
            _points = null;
            g.Clear(Color.WhiteSmoke);
            var randIter = rand.Next(1, 10);
            _rhombus = new MyRhombus[randIter];
            _points = new MyPoint[randIter];
            _iter = randIter;


            for (var i = 0; i < _iter; i++)
            {
                _points[i] = new MyPoint(rand.Next(50, 800),
                                           rand.Next(50, 400));

                _rhombus[i] = new MyRhombus(_points[i],
                                            rand.Next(25, 100),
                                            rand.Next(25, 100));
                _rhombus[i].Show(g);
            }

            PictureBoxUpd();
        }
    }

}
