using System.Drawing;

namespace laba1igor.My_Classes
{
    public class MyCircle
  {
    private float _xCenter;
    private float _yCenter;
    private float _radius;

    public float XCenter
    {
      get => _xCenter;
      set
      {
        if (value >= 0)
        {
          _xCenter = value;
        }
      }
    }

    public float YCenter
    {
      get => _yCenter;
      set
      {
        if (value >= 0)
        {
          _yCenter = value;
        }
      }
    }

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

    public MyCircle(float coordXCenter, float coordYCenter, float radiusValue)
    {
      XCenter = coordXCenter;
      YCenter = coordYCenter;
      Radius = radiusValue;
    }

    public void Show(Graphics canvas)
    {
      var pen = new Pen(Color.Black, 6);
      var brush = new SolidBrush(Color.DarkRed);
      var centerXDraw = _xCenter - _radius;
      var centerYDraw = _yCenter - _radius;
      canvas.DrawEllipse(pen, centerXDraw, centerYDraw, Radius * 2, Radius * 2);
      canvas.FillEllipse(brush, centerXDraw, centerYDraw, Radius * 2, Radius * 2);
    }

    public void MoveTo(Graphics canvas, float newX, float newY)
    {
        if (_xCenter + _radius + newX < 877 && _xCenter - _radius + newX > 0)
        {
            XCenter += newX;
        }
        if (_yCenter + _radius + newY < 500 && _yCenter - _radius + newY > 0)
        {
            YCenter += newY;
        }

            Show(canvas);
    }

    public void ResizeCircle(Graphics canvas, float sizeChange)
    {
            if (sizeChange < _radius || _xCenter + sizeChange <= 877 && _yCenter + sizeChange <= 500 && _xCenter - sizeChange >= 0 && _yCenter - sizeChange >= 0)
            {
                _radius = sizeChange;
            }
      Show(canvas);
    }
  }
}