using laba1igor.My_Classes;
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
            var x_cord = float.TryParse(textBox1.Text, out var x1);
            var y_cord = float.TryParse(textBox2.Text, out var y1);
            var Height = int.TryParse(textBox3.Text, out var H);
            var Width = int.TryParse(textBox4.Text, out var W);
            if (x_cord && y_cord && Height && Width)
            {
                if (x1 - W/2 >= 3 && x1 + W/2 <= X_size && y1 - H/2 >= 3 && y1 + H/2 <= Y_size)
                {
                    _points[_iter] = new MyPoint(x1, y1);
                    _elipse[_iter] = new MyEllipse(_points[_iter], W, H);
                    _elipse[_iter].Show(g);
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
                if (checkIter && iterator > 0 && iterator < _elipse.Length && _elipse[iterator] != null)
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
                        int rNewH = rand.Next(20, 80);
                        int rNewW = rand.Next(20, 80);
                        _elipse[i].ResizeEllipse(g, rNewW, rNewH, X_size, Y_size, true);
                    }
                }
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (nHeight && nWidth)
                {
                    if (checkIter && iterator > 0 && iterator < _iter && _elipse[iterator] != null)
                    {
                        g.Clear(Color.WhiteSmoke);

                        _elipse[iterator].ResizeEllipse(g, nW, nH, X_size, Y_size, false);
                        for (var i = 0; i < _iter; i++)
                        {
                            if (i == iterator) continue;
                            if (_elipse[i] != null) _elipse[i].Show(g);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Эллипса с таким номером нет!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
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
                    if (_elipse[i] != null)
                    {
                        newX = rand.Next(-50, 50);
                        newY = rand.Next(-50, 50);
                        _elipse[i].MoveTo(g, newX, newY, X_size, Y_size, true);
                    }
                }
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (x && y)
                {
                    if (checkIter && iterator > 0 && iterator < _elipse.Length && _elipse[iterator] != null)
                    {
                        g.Clear(Color.WhiteSmoke);


                        for (var i = 0; i < _iter; i++)
                        {
                            if (i == iterator)
                            {
                                _elipse[i].MoveTo(g, newX, newY, X_size, Y_size, false);
                            }
                            else
                            {
                                if (_elipse[i] != null) _elipse[i].Show(g);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Эллипса с таким номером нет!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
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
                                            rand.Next(20, 120));
                _elipse[i].Show(g);
            }

            PictureBoxUpd();
        }
    }

}
