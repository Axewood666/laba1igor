using System;
using System.Drawing;
using System.Windows.Forms;

namespace laba1igor.My_Classes
{
    public class MyCircle : MyFigure
  {
    private int _radius;

    public int Radius
    {
      get => _radius;
      set
      {
        if (value > 0)
        {
          _radius = value;
        }
      }
    }

        public MyCircle(MyPoint CordPoint, int radiusValue) : base(CordPoint)
        {
      Radius = radiusValue;
      MessageBox.Show($"Круг с центром в точке [{CordPoint.XStart}, {CordPoint.YStart}], c радиусом {Radius} создан!", "Уведомление!",
      MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

    public void Show(Graphics canvas)
    {
      var pen = new Pen(Color.Black, 6);
      var brush = new SolidBrush(Color.DarkRed);
      var centerXDraw = CordPoint.XStart - _radius;
      var centerYDraw = CordPoint.YStart - _radius;
      canvas.DrawEllipse(pen, centerXDraw, centerYDraw, Radius * 2, Radius * 2);
      canvas.FillEllipse(brush, centerXDraw, centerYDraw, Radius * 2, Radius * 2);
    }

    public void ResizeCircle(Graphics canvas, int sizeChange)
    {
        _radius = sizeChange;
        Show(canvas);
    }
  }
}