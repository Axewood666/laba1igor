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
    public Color color1
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

    public MyCircle(MyPoint Cords, float radiusValue, Color color)
    {
      CordPoint = Cords;
      Radius = radiusValue;
      color1 = color;
      MessageBox.Show($"Круг с центром в точке [{CordPoint.XStart}, {CordPoint.YStart}], c радиусом {Radius} создан!", "Уведомление!",
      MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

    public void Show(Graphics canvas)
    {
      var pen = new Pen(Color.Black, 6);
      var brush = new SolidBrush(color1);
      var centerXDraw = CordPoint.XStart - Radius;
      var centerYDraw = CordPoint.YStart - Radius;
      canvas.DrawEllipse(pen, centerXDraw, centerYDraw, Radius * 2, Radius * 2);
      canvas.FillEllipse(brush, centerXDraw, centerYDraw, Radius * 2, Radius * 2);
    }

    public void MoveTo(Graphics canvas, float newX, float newY, int BoxSizeX, int BoxSizeY, bool random)
    {
        if (CordPoint.XStart + Radius + newX <= BoxSizeX && CordPoint.XStart - Radius + newX >= 3)
            {
                CordPoint.ChangeX(newX);
            }
            else if (!random)
            {
                MessageBox.Show("Перемещение по x невозможно!", "Выход за границы!",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        if (CordPoint.YStart + Radius + newY <= BoxSizeY && CordPoint.YStart - Radius + newY >= 3)
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