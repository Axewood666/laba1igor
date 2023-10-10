using System;
using System.Drawing;
using System.Windows.Forms;

namespace laba1igor.My_Classes
{
    public class MyRing
  {
    private float _radius;
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

    public MyRing(MyPoint Cords, float radiusValue)
    {
      CordPoint = Cords;
      Radius = radiusValue;
      MessageBox.Show($"Кольцо с центром в точке [{CordPoint.XStart}, {CordPoint.YStart}], c радиусом {Radius} создан!", "Уведомление!",
      MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

    public void Show(Graphics canvas)
    {
      var pen = new Pen(Color.Black, 6);
      var brushOUT = new SolidBrush(Color.DarkRed);
      var brushIN = new SolidBrush(Color.WhiteSmoke);
      canvas.DrawEllipse(pen, CordPoint.XStart - _radius, CordPoint.YStart - _radius, Radius * 2, Radius * 2);
      canvas.FillEllipse(brushOUT, CordPoint.XStart - _radius, CordPoint.YStart - _radius, Radius * 2, Radius * 2);
      canvas.DrawEllipse(pen, CordPoint.XStart - _radius * 0.75F, CordPoint.YStart - _radius * 0.75F, Radius * 2 * 0.75F, Radius * 2 * 0.75F);
      canvas.FillEllipse(brushIN, CordPoint.XStart - _radius * 0.75F, CordPoint.YStart - _radius * 0.75F, Radius * 2 * 0.75F, Radius * 2 * 0.75F);
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