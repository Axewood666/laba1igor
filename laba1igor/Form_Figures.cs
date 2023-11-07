using laba1igor.My_Classes;
using MyGraphicLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace laba1igor
{
    public partial class Form_Figures : Form
    {
        private MyFigure[] _figures;
        private MyPoint[] _points;
        private int _iter = 0;
        private int X_size;
        private int Y_size;
        private int StepSize;
        private Random rand = new Random();
        public Form_Figures()
        {
            InitializeComponent();
            buf = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(buf);
            g.Clear(Color.WhiteSmoke);
            X_size = pictureBox1.Width - 3;
            Y_size = pictureBox1.Height - 3;
            StepSize = 10;
            
            _figures = new MyCircle[5];
            _points = new MyPoint[5];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _figures = null;
            _points = null;
            g.Clear(Color.WhiteSmoke);
            PictureBoxUpd();
            int randCount = rand.Next(20, 30);

            _figures = new MyFigure[randCount];
            _points = new MyPoint[randCount];
            _iter = randCount;
            for (var i = 0; i < _iter; i++)
            {
                int randFigure = rand.Next(0, 7);  // 0-Cirle 1-Ellipse 2-Rectangle 3-Rhombus 4-Ring 5-Square 6-Trapezoid
                if (randFigure == 0)
                {
                    _points[i] = new MyPoint(rand.Next(100, 750),
                                                rand.Next(100, 400));

                    _figures[i] = new MyCircle(_points[i],
                                                rand.Next(25, 100), Color.DarkRed);

                }
                if (randFigure == 1)
                {
                    _points[i] = new MyPoint(rand.Next(60, 770),
                                               rand.Next(60, 390));
                    _figures[i] = new MyEllipse(_points[i],
                                                rand.Next(20, 120),
                                                rand.Next(20, 120), Color.Aquamarine);
                }
                if (randFigure == 2)
                {
                    _points[i] = new MyPoint(rand.Next(50, 800),
                                           rand.Next(50, 400));

                    _figures[i] = new MyRectangle(_points[i],
                                                rand.Next(25, 100),
                                                rand.Next(25, 100));
                }
                if (randFigure == 3)
                {
                    _points[i] = new MyPoint(rand.Next(50, 800),
                                          rand.Next(50, 400));

                    _figures[i] = new MyRhombus(_points[i],
                                                rand.Next(25, 100),
                                                rand.Next(25, 100));
                }
                if (randFigure == 4)
                {
                    _points[i] = new MyPoint(rand.Next(100, 750),
                           rand.Next(100, 400));

                    _figures[i] = new MyRing(_points[i],
                                                rand.Next(25, 100), Color.DarkRed);
                }
                if (randFigure == 5)
                {
                    _points[i] = new MyPoint(rand.Next(10, 800),
                            rand.Next(10, 420));
                    _figures[i] = new MySquare(_points[i],
                                               rand.Next(25, 70));
                }
                if (randFigure == 6)
                {
                    _points[i] = new MyPoint(rand.Next(50, 790),
                           rand.Next(60, 400));

                    _figures[i] = new MyTrapezoid(_points[i],
                                                rand.Next(25, 80),
                                                rand.Next(25, 57));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_iter != 0)
            {
                MessageBox.Show("Все фигуры будут уничтожены!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
                for (var i = _iter - 1; i >= 0; i--)
                {
                    _figures[i] = null;
                    _points[i] = null;
                }
                _iter = 0;
                g.Clear(Color.WhiteSmoke);
                PictureBoxUpd();
            }
            else
            {
                MessageBox.Show("Список пуст!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (_iter != 0)
            {
                for (int i = 0; i < _iter; i++)
                {
                    _figures[i].Show(g);
                }
                PictureBoxUpd();
            }
            else
            {
                MessageBox.Show("Список пуст!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            g.Clear(Color.WhiteSmoke);
            PictureBoxUpd();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            g.Clear(Color.WhiteSmoke);
            for (var i = 0; i < _iter; i++)
            {
                if (_figures[i] is MyEllipse)
                {

                    int newX = rand.Next(((MyEllipse)_figures[i]).Radius / 2 + 3, X_size - ((MyEllipse)_figures[i]).Radius / 2);
                    int newY = rand.Next(((MyEllipse)_figures[i]).YSize / 2 + 3, Y_size - ((MyEllipse)_figures[i]).YSize / 2);
                    _figures[i].MoveTo(newX, newY, g);
                }
                else if (_figures[i] is MyRing || _figures[i] is MyCircle)
                {

                    int newX = rand.Next(((MyCircle)_figures[i]).Radius + 3, X_size - ((MyCircle)_figures[i]).Radius);
                    int newY = rand.Next(((MyCircle)_figures[i]).Radius + 3, Y_size - ((MyCircle)_figures[i]).Radius);
                    _figures[i].MoveTo(newX, newY, g);
                }
                else if (_figures[i] is MyRectangle || _figures[i] is MyRhombus || _figures[i] is MySquare)
                {
                    int newX = rand.Next(3, X_size - ((MyQuadrilateral)_figures[i]).Width);
                    int newY = rand.Next(3, Y_size - ((MyQuadrilateral)_figures[i]).Height);
                    _figures[i].MoveTo(newX, newY, g);
                }
                else if (_figures[i] is MyTrapezoid)
                {
                    int newX = rand.Next(3, X_size - ((MyTrapezoid)_figures[i]).Width);
                    int newY = rand.Next(((MyTrapezoid)_figures[i]).Height + 3, Y_size);
                    _figures[i].MoveTo(newX, newY, g);
                }
            }
            PictureBoxUpd();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                    g.Clear(Color.WhiteSmoke);
                    foreach (var obj in _figures)
                    {
                        if (obj is MyEllipse)
                        {
                            if (obj.CordPoint.XStart - StepSize - ((MyCircle)obj).Radius/2 >= 3)
                            {
                                obj.MoveTo(obj.CordPoint.XStart - StepSize, obj.CordPoint.YStart, g);
                            }
                            else
                            {
                                obj.Show(g);
                            }
                        }
                        if (obj is MyCircle && !(obj is MyEllipse))
                        {
                            if (obj.CordPoint.XStart - StepSize - ((MyCircle)obj).Radius >= 3)
                            {
                                obj.MoveTo(obj.CordPoint.XStart - StepSize, obj.CordPoint.YStart, g);
                            }
                            else
                            {
                                obj.Show(g);
                            }
                        }
                        if (obj is MyQuadrilateral)
                        {
                            if (obj.CordPoint.XStart - StepSize >= 3)
                            {
                                obj.MoveTo(obj.CordPoint.XStart - StepSize, obj.CordPoint.YStart, g);
                            }
                            else
                            {
                                obj.Show(g);
                            }
                        }
                    }
         
                    PictureBoxUpd();
                    return true;
                case Keys.Right:
                     g.Clear(Color.WhiteSmoke);
                    foreach (var obj in _figures)
                    {
                        if (obj is MyEllipse)
                        {
                            if (obj.CordPoint.XStart + StepSize + ((MyCircle)obj).Radius/2 <= X_size)
                            {
                                obj.MoveTo(obj.CordPoint.XStart + StepSize, obj.CordPoint.YStart, g);
                            }
                            else
                            {
                                obj.Show(g);
                            }
                        }
                        if (obj is MyCircle && !(obj is MyEllipse))
                        {
                            if (obj.CordPoint.XStart + StepSize + ((MyCircle)obj).Radius <= X_size)
                            {
                                obj.MoveTo(obj.CordPoint.XStart + StepSize, obj.CordPoint.YStart, g);
                            }
                            else
                            {
                                obj.Show(g);
                            }
                        }
                        if (obj is MyQuadrilateral)
                        {
                            if (obj.CordPoint.XStart + StepSize + ((MyQuadrilateral)obj).Width <= X_size)
                            {
                                obj.MoveTo(obj.CordPoint.XStart + StepSize, obj.CordPoint.YStart, g);
                            }
                            else
                            {
                                obj.Show(g);
                            }
                        }
                    }
                    PictureBoxUpd();
                    return true;
                case Keys.Up:
                    g.Clear(Color.WhiteSmoke);
                    foreach (var obj in _figures)
                    {
                        if (obj is MyEllipse)
                        {
                            if (obj.CordPoint.YStart - StepSize - ((MyEllipse)obj).YSize / 2 >= 3)
                            {
                                obj.MoveTo(obj.CordPoint.XStart, obj.CordPoint.YStart - StepSize, g);
                            }
                            else
                            {
                                obj.Show(g);
                            }
                        }
                        if (obj is MyCircle && !(obj is MyEllipse))
                        {
                            if (obj.CordPoint.YStart - StepSize - ((MyCircle)obj).Radius >= 3)
                            {
                                obj.MoveTo(obj.CordPoint.XStart, obj.CordPoint.YStart - StepSize, g);
                            }
                            else
                            {
                                obj.Show(g);
                            }
                        }
                        if (obj is MyQuadrilateral && !(obj is MyTrapezoid))
                        {
                            if (obj.CordPoint.YStart - StepSize >= 3)
                            {
                                obj.MoveTo(obj.CordPoint.XStart, obj.CordPoint.YStart - StepSize, g);
                            }
                            else
                            {
                                obj.Show(g);
                            }
                        }
                        if (obj is MyTrapezoid)
                        {
                            if (obj.CordPoint.YStart - StepSize - ((MyQuadrilateral)obj).Height >= 3)
                            {
                                obj.MoveTo(obj.CordPoint.XStart, obj.CordPoint.YStart - StepSize, g);
                            }
                            else
                            {
                                obj.Show(g);
                            }
                        }
                    }
                    PictureBoxUpd();
                    return true;
                case Keys.Down:
                    g.Clear(Color.WhiteSmoke);
                    foreach (var obj in _figures)
                    {
                        if (obj is MyEllipse)
                        {
                            if (obj.CordPoint.YStart + StepSize + ((MyEllipse)obj).YSize / 2 <= Y_size)
                            {
                                obj.MoveTo(obj.CordPoint.XStart, obj.CordPoint.YStart + StepSize, g);
                            }
                            else
                            {
                                obj.Show(g);
                            }
                        }
                        if (obj is MyCircle && !(obj is MyEllipse))
                        {
                            if (obj.CordPoint.YStart + StepSize + ((MyCircle)obj).Radius <= Y_size)
                            {
                                obj.MoveTo(obj.CordPoint.XStart, obj.CordPoint.YStart + StepSize, g);
                            }
                            else
                            {
                                obj.Show(g);
                            }
                        }
                        if (obj is MyQuadrilateral && !(obj is MyTrapezoid))
                        {
                            if (obj.CordPoint.YStart + StepSize + ((MyQuadrilateral)obj).Height <= Y_size)
                            {
                                obj.MoveTo(obj.CordPoint.XStart, obj.CordPoint.YStart + StepSize, g);
                            }
                            else
                            {
                                obj.Show(g);
                            }
                        }
                        if (obj is MyTrapezoid)
                        {
                            if (obj.CordPoint.YStart + StepSize <= Y_size)
                            {
                                obj.MoveTo(obj.CordPoint.XStart, obj.CordPoint.YStart + StepSize, g);
                            }
                            else
                            {
                                obj.Show(g);
                            }
                        }
                    }
                    PictureBoxUpd();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void PictureBoxUpd()
        {
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = (Bitmap)buf.Clone();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            g.Clear(Color.WhiteSmoke);
            for (var i = 0; i < _iter; i++)
            {
                if (_figures[i] is MyEllipse)
                {

                    int newX = rand.Next(((MyEllipse)_figures[i]).Radius / 2 + 3, X_size - ((MyEllipse)_figures[i]).Radius / 2);
                    int newY = rand.Next(((MyEllipse)_figures[i]).YSize / 2 + 3, Y_size - ((MyEllipse)_figures[i]).YSize / 2);
                    _figures[i].MoveTo(newX, newY, g);
                }
                else if (_figures[i] is MyRing || _figures[i] is MyCircle)
                {

                    int newX = rand.Next(((MyCircle)_figures[i]).Radius + 3, X_size - ((MyCircle)_figures[i]).Radius);
                    int newY = rand.Next(((MyCircle)_figures[i]).Radius + 3, Y_size - ((MyCircle)_figures[i]).Radius);
                    _figures[i].MoveTo(newX, newY, g);
                }
                else if (_figures[i] is MyQuadrilateral)
                {
                    _figures[i].Show(g);
                }
            }
            PictureBoxUpd();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            g.Clear(Color.WhiteSmoke);
            for (var i = 0; i < _iter; i++)
            {
                if (_figures[i] is MyEllipse)
                {

                    int rNewW = rand.Next(1, (int)Math.Min(_figures[i].CordPoint.XStart - 3, X_size - _figures[i].CordPoint.XStart));
                    int rNewH = rand.Next(1, (int)Math.Min(_figures[i].CordPoint.YStart - 3, Y_size - _figures[i].CordPoint.YStart));
                    ((MyEllipse)_figures[i]).ResizeEllipse(g, rNewW, rNewH);
                }
                else if (_figures[i] is MyCircle)
                {

                    int newRadius = rand.Next(10, (int)Math.Min(Math.Min(_figures[i].CordPoint.XStart, X_size - _figures[i].CordPoint.XStart),
                                                Math.Min(_figures[i].CordPoint.YStart, Y_size - _figures[i].CordPoint.YStart)) - 3);
                    if (_figures[i] is MyRing)
                    {
                        ((MyRing)_figures[i]).ResizeRing(g, newRadius);
                    }
                    else
                    {
                        ((MyCircle)_figures[i]).ResizeCircle(g, newRadius);
                    }
                    _figures[i].Show(g);
                }
                else
                {
                    _figures[i].Show(g);
                }
            }
            PictureBoxUpd();
        }
    }

}
