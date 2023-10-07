using System;
using System.Drawing;
using System.Windows.Forms;

namespace laba1igor.My_Classes
{
    internal class MyCircle
  {
    //private float _xCenter;
    //private float _yCenter;
    private float _radius;

        //public float XCenter
        //{
        //  get => _xCenter;
        //  set
        //  {
        //    if (value >= 0)
        //    {
        //      _xCenter = value;
        //    }
        //  }
        //}

        //public float YCenter
        //{
        //  get => _yCenter;
        //  set
        //  {
        //    if (value >= 0)
        //    {
        //      _yCenter = value;
        //    }
        //  }
        //}
    public MyPoint CordPoint
    { get; set; }
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

    public MyCircle(MyPoint Cords, float radiusValue)
    {
      CordPoint = Cords;
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
                CordPoint.ChangeX(newX);
            }
            else if (!random)
            {
                MessageBox.Show("Перемещение по x невозможно!", "Выход за границы!",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        if (CordPoint.YStart + _radius + newY < BoxSizeY && CordPoint.YStart - _radius + newY > 3)
            {
                CordPoint.ChangeY(newY);
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
            if (sizeChange > 0 && (sizeChange < _radius || CordPoint.XStart + sizeChange <= BoxSizeX && CordPoint.YStart + sizeChange <= BoxSizeY && CordPoint.XStart - sizeChange >= 3 && CordPoint.YStart - sizeChange >= 3))
            {
                _radius = sizeChange;
            }
            else if (!Random)
            {
                MessageBox.Show("Неверно введен радиус", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
            }
      Show(canvas);
    }
  }
}