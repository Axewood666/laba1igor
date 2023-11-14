using laba1igor.My_Classes;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGraphicLib
{
    public class MyArray
    {
        Random rand = new Random();
        public List<MyFigure> _figures;
        private int _iter = 0;
        private int X_size = 877 - 3;
        private int Y_size = 500 - 3;
        public MyArray()
        {
            _figures = new List<MyFigure>();
            MessageBox.Show("Массив был создан!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public enum RandFigure
        {
            Circle,
            Ellipse,
            Rectangle,
            Rhombus,
            Ring,
            Square,
            Trapezoid
        }
        public void Iterator(Graphics g, int method)
        {
            RandFigure randFigure = (RandFigure)rand.Next(Enum.GetNames(typeof(RandFigure)).Length);
            switch (method)
            {
                case 0:
                    switch (randFigure)
                    {
                        case RandFigure.Circle:
                            Add(new MyCircle(new MyPoint(rand.Next(100, 750),
                                                    rand.Next(100, 400)),
                                                    rand.Next(25, 100), Color.DarkRed), g);
                            break;
                        case RandFigure.Ellipse:
                            Add(new MyEllipse(new MyPoint(rand.Next(60, 770),
                                                   rand.Next(60, 390)),
                                                    rand.Next(20, 120),
                                                    rand.Next(20, 120), Color.Aquamarine), g);
                            break;
                        case RandFigure.Rectangle:
                            Add(new MyRectangle(new MyPoint(rand.Next(50, 800),
                                               rand.Next(50, 400)),
                                                    rand.Next(25, 100),
                                                    rand.Next(25, 100)), g);
                            break;

                        case RandFigure.Rhombus:
                            Add(new MyRhombus(new MyPoint(rand.Next(50, 800),
                                              rand.Next(50, 400)),
                                                    rand.Next(25, 100),
                                                    rand.Next(25, 100)), g);
                            break;

                        case RandFigure.Ring:
                            Add(new MyRing(new MyPoint(rand.Next(100, 750),
                               rand.Next(100, 400)),
                                                    rand.Next(25, 100), Color.DarkRed), g);
                            break;
                        case RandFigure.Square:
                            Add(new MySquare(new MyPoint(rand.Next(10, 800),
                                rand.Next(10, 420)),
                                                   rand.Next(25, 70)), g);
                            break;
                        case RandFigure.Trapezoid:
                            Add(new MyTrapezoid(new MyPoint(rand.Next(50, 790),
                                rand.Next(60, 400)),
                                                    rand.Next(25, 80),
                                                    rand.Next(25, 57)), g);
                            break;

                    }
                    break;
                case 1:
                    ShowTo(g);
                    break;
                case 2:
                    Move(g);
                    break;
                case 3:
                   Delete(g);
                    break;
            }
        }


        private void Add(MyFigure figura, Graphics g)
        {
            _figures.Add(figura);
            _iter++;
            _figures[_iter - 1].Show(g);
        }
        private void ShowTo(Graphics g)
        {
            for (int i = 0; i < _iter; i++)
            {
                _figures[i].Show(g);
            }
        }
        private void Move(Graphics g)
        {
            for (var i = 0; i < _iter; i++)
            {
                switch (_figures[i])
                {
                    case MyEllipse _:
                        int newX = rand.Next(((MyEllipse)_figures[i]).Radius / 2 + 3, X_size - ((MyEllipse)_figures[i]).Radius / 2);
                        int newY = rand.Next(((MyEllipse)_figures[i]).YSize / 2 + 3, Y_size - ((MyEllipse)_figures[i]).YSize / 2);
                        _figures[i].MoveTo(newX, newY, g);

                        break;
                    case MyCircle _:
                        newX = rand.Next(((MyCircle)_figures[i]).Radius + 3, X_size - ((MyCircle)_figures[i]).Radius);
                        newY = rand.Next(((MyCircle)_figures[i]).Radius + 3, Y_size - ((MyCircle)_figures[i]).Radius);
                        _figures[i].MoveTo(newX, newY, g);
                        break;
                    case MyTrapezoid _:
                        newX = rand.Next(3, X_size - ((MyTrapezoid)_figures[i]).Width);
                        newY = rand.Next(((MyTrapezoid)_figures[i]).Height + 3, Y_size);
                        _figures[i].MoveTo(newX, newY, g);
                        break;
                    case MyQuadrilateral _:
                        newX = rand.Next(3, X_size - ((MyQuadrilateral)_figures[i]).Width);
                        newY = rand.Next(3, Y_size - ((MyQuadrilateral)_figures[i]).Height);
                        _figures[i].MoveTo(newX, newY, g);
                        break;

                }
            }
        }
        private void Delete(Graphics g)
        {
            for (int i = 0; i < _iter; i++)
            {
                _figures[i] = null;
            }
            _figures = null;
            _iter = 0;
            rand = null;
        }
    }
}


