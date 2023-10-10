using System;
using System.Drawing;
using System.Windows.Forms;

namespace laba1igor.My_Classes
{
    public class MyCircle : MyFigure
  {
    private float _radius;

    public float Radius
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

        public MyCircle(MyPoint CordPoint, float radiusValue) : base(CordPoint)
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

    public void MoveTo(Graphics canvas, float newX, float newY, int BoxSizeX, int BoxSizeY, bool random)
    {
        if (CordPoint.XStart + _radius + newX < BoxSizeX && CordPoint.XStart - _radius + newX > 3)
            {
                base.MoveTo(newX, 0);
            }
            else if (!random)
            {
                MessageBox.Show("Перемещение по x невозможно!", "Выход за границы!",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        if (CordPoint.YStart + _radius + newY < BoxSizeY && CordPoint.YStart - _radius + newY > 3)
            {
                base.MoveTo(0, newY);
            }
            else if (!random)
            {
                MessageBox.Show("Перемещение по y невозможно!", "Выход за границы!",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

            Show(canvas);
    }

    public void ResizeCircle(Graphics canvas, float sizeChange, int BoxSizeX, int BoxSizeY, bool Random)
    {
            if (sizeChange < _radius || CordPoint.XStart + sizeChange <= BoxSizeX && CordPoint.YStart + sizeChange <= BoxSizeY && CordPoint.XStart - sizeChange >= 3 && CordPoint.YStart - sizeChange >= 3)
            {
                _radius = sizeChange;
            }
            else if (!Random)
            {
                MessageBox.Show("Радиус выходит за границы", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
            }
      Show(canvas);
    }
  }
}