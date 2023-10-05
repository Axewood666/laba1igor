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
        private int _iter = 0;
        private int X_size = 877;
        private int Y_size = 500;
        private Random rand = new Random();
        public Form_Line()
        {
            InitializeComponent();
            buf = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(buf);
            g.Clear(Color.WhiteSmoke);
            _elipse = new MyEllipse[5];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            if (_iter == _elipse.Length)
            {
                Array.Resize(ref _elipse, _iter + 1);
            }
            var x_cord = float.TryParse(textBox1.Text, out var x1);
            var y_cord = float.TryParse(textBox2.Text, out var y1);
            var Height = int.TryParse(textBox3.Text, out var H);
            var Width = int.TryParse(textBox4.Text, out var W);
            if (x_cord && y_cord && Height && Width)
            {
                if (x1 - W/2 >= 0 && x1 + W/2 <= X_size && y1 - H/2 >= 0 && y1 + H/2 <= Y_size)
                {
                    _elipse[_iter] = new MyEllipse(x1, y1, W, H);
                    _elipse[_iter].Show(g);
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
                    _elipse[i] = null;
                }
                _iter = 0;
                g.Clear(Color.WhiteSmoke);
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (checkIter && iterator < _elipse.Length && _elipse[iterator] != null)
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
                    label6.Text = "Линии с таким номером нет!";
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
                        _elipse[i].ResizeEllipse(g, rNewW, rNewH);
                    }
                }
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (checkIter && nHeight && nWidth)
                {
                    if (iterator < _iter)
                    {
                        g.Clear(Color.WhiteSmoke);

                        if (_elipse[iterator] != null) _elipse[iterator].ResizeEllipse(g, nW, nH);
                        else label6.Text = "Линии с таким номером нет!";
                        for (var i = 0; i < _iter; i++)
                        {
                            if (i == iterator) continue;
                            if (_elipse[i] != null) _elipse[i].Show(g);
                        }
                    }
                    else
                    {
                        label6.Text = "Линии с таким номером нет!";
                    }
                }
                else
                {
                    label6.Text = "Неверно введен угол!";
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
                        _elipse[i].MoveTo(g, newX, newY);
                    }
                }
            }
            else
            {
                var checkIter = int.TryParse(textBox5.Text, out var iterator);
                if (x && y && checkIter)
                {
                    if (iterator < _elipse.Length && _elipse[iterator] != null)
                    {
                        g.Clear(Color.WhiteSmoke);


                        for (var i = 0; i < _iter; i++)
                        {
                            if (i == iterator)
                            {
                                _elipse[i].MoveTo(g, newX, newY);
                            }
                            else
                            {
                                if (_elipse[i] != null) _elipse[i].Show(g);
                            }
                        }
                    }
                    else
                    {
                        label6.Text = "Линии с таким номером нет!";
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
        private void EllipseDispose(int iter)
        {
            _elipse[iter] = null;
        }
        private void PictureBoxUpd()
        {
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = (Bitmap)buf.Clone();
        }
        private void RandomArray()
        {
            _elipse = null;
            g.Clear(Color.WhiteSmoke);
            var randIter = rand.Next(1, 10);
            _elipse = new MyEllipse[randIter];
            _iter = randIter;


            for (var i = 0; i < _iter; i++)
            {
                _elipse[i] = new MyEllipse(rand.Next(60, 770),
                                           rand.Next(60, 390),
                                            rand.Next(20, 120),
                                            rand.Next(20, 120));
                _elipse[i].Show(g);
            }

            PictureBoxUpd();
        }
    }

}
