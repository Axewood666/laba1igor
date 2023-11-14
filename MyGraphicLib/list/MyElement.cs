using laba1igor.My_Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static MyGraphicLib.MyArray;

namespace MyGraphicLib
{
    public class MyElement
    {
        public MyFigure _figure { get; set; }
        public MyElement next { get; set; }
        private int X_size = 877 - 3;
        private int Y_size = 500 - 3;
        Random rand = new Random();
        public MyElement()
        {
            RandFigure randFigure = (RandFigure)rand.Next(Enum.GetNames(typeof(RandFigure)).Length);
            switch (randFigure)
            {
                case RandFigure.Circle:
                    _figure = new MyCircle(new MyPoint(rand.Next(100, 750),
                                            rand.Next(100, 400)),
                                            rand.Next(25, 100), Color.DarkRed);
                    break;
                case RandFigure.Ellipse:
                    _figure = (new MyEllipse(new MyPoint(rand.Next(60, 770),
                                           rand.Next(60, 390)),
                                            rand.Next(20, 120),
                                            rand.Next(20, 120), Color.Aquamarine));
                    break;
                case RandFigure.Rectangle:
                    _figure = (new MyRectangle(new MyPoint(rand.Next(50, 800),
                                       rand.Next(50, 400)),
                                            rand.Next(25, 100),
                                            rand.Next(25, 100)));
                    break;

                case RandFigure.Rhombus:
                    _figure = (new MyRhombus(new MyPoint(rand.Next(50, 800),
                                      rand.Next(50, 400)),
                                            rand.Next(25, 100),
                                            rand.Next(25, 100)));
                    break;

                case RandFigure.Ring:
                    _figure = (new MyRing(new MyPoint(rand.Next(100, 750),
                       rand.Next(100, 400)),
                                            rand.Next(25, 100), Color.DarkRed));
                    break;
                case RandFigure.Square:
                    _figure = (new MySquare(new MyPoint(rand.Next(10, 800),
                        rand.Next(10, 420)),
                                           rand.Next(25, 70)));
                    break;
                case RandFigure.Trapezoid:
                    _figure = (new MyTrapezoid(new MyPoint(rand.Next(50, 790),
                        rand.Next(60, 400)),
                                            rand.Next(25, 80),
                                            rand.Next(25, 57)));
                    break;

            }
        }
        public void ShowTo(Graphics g)
        {
            _figure.Show(g);
        }
        public void Move(Graphics g)
        {
            switch (_figure)
            {
                case MyEllipse _:
                    int newX = rand.Next(((MyEllipse)_figure).Radius / 2 + 3, X_size - ((MyEllipse)_figure).Radius / 2);
                    int newY = rand.Next(((MyEllipse)_figure).YSize / 2 + 3, Y_size - ((MyEllipse)_figure).YSize / 2);
                    _figure.MoveTo(newX, newY, g);

                    break;
                case MyCircle _:
                    newX = rand.Next(((MyCircle)_figure).Radius + 3, X_size - ((MyCircle)_figure).Radius);
                    newY = rand.Next(((MyCircle)_figure).Radius + 3, Y_size - ((MyCircle)_figure).Radius);
                    _figure.MoveTo(newX, newY, g);
                    break;
                case MyTrapezoid _:
                    newX = rand.Next(3, X_size - ((MyTrapezoid)_figure).Width);
                    newY = rand.Next(((MyTrapezoid)_figure).Height + 3, Y_size);
                    _figure.MoveTo(newX, newY, g);
                    break;
                case MyQuadrilateral _:
                    newX = rand.Next(3, X_size - ((MyQuadrilateral)_figure).Width);
                    newY = rand.Next(3, Y_size - ((MyQuadrilateral)_figure).Height);
                    _figure.MoveTo(newX, newY, g);
                    break;

            }
        }

        internal void Delete()
        {
            _figure = null;
            next = null;
            rand = null;
        }
    }
}
