using System.Drawing;

namespace laba1igor.My_Classes
{
    public class MySquare
  {
    private float _xCenter;
    private float _yCenter;
    private float _side;       
    
    public float XCenter 
    {
      get => _xCenter;
      set => _xCenter = value;
    }
    public float YCenter 
    {
      get => _yCenter;
      set => _yCenter = value;
    }
  
    public float Side
    {
      get => _side;
      set => _side = value;
    }

    public MySquare(float coordXCenter, float coordYCenter,
      float side)
    {
      XCenter = coordXCenter;
      YCenter = coordYCenter;

      Side = side;
    }
  
    public MySquare(int coordXCenter, int coordYCenter,
      int side)
    {

      XCenter = coordXCenter;
      YCenter = coordYCenter;

      Side = side;

    }

    public void Show(Graphics canvas)
    {
      var pen = new Pen(Color.Black, 6);
      var brush = new SolidBrush(Color.DarkOrchid);

      canvas.DrawRectangle(pen, _xCenter, _yCenter, _side, _side);
      canvas.FillRectangle(brush, _xCenter, _yCenter, _side, _side);
    }

    public void MoveTo(Graphics canvas, float changeX, float changeY)
    {
            if (_xCenter + _side + changeX < 877 && _xCenter + changeX > 0)
            {
                XCenter+=changeX;
            }
            if (_yCenter + _side + changeY < 500 && _yCenter + changeY > 0)
            {
                YCenter+=changeY;
            }

            Show(canvas);
    }

    public void ResizeSquare(Graphics canvas, float SizeChange)
    {
        if (SizeChange > _side)
        {
            if (_xCenter + SizeChange <= 877 && _yCenter + SizeChange <= 500)
            {
                _side = SizeChange;
            }
        }
        else
        {
            _side = SizeChange;
        }
        Show(canvas);
    }
  }
}