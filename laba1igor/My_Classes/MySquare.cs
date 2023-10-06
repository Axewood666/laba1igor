using System.Drawing;

namespace laba1igor.My_Classes
{
    internal class MySquare
  {
    //private float _xCenter;
    //private float _yCenter;
    private float _side;

        //public float XCenter 
        //{
        //  get => _xCenter;
        //  set => _xCenter = value;
        //}
        //public float YCenter 
        //{
        //  get => _yCenter;
        //  set => _yCenter = value;
        //}
    public MyPoint CordPoint
    { get; set; }
        public float Side
    {
      get => _side;
      set => _side = value;
    }

    public MySquare(MyPoint Cordinates,
      float side)
    {
      CordPoint = Cordinates;
      Side = side;
    }

    public void Show(Graphics canvas)
    {
      var pen = new Pen(Color.Black, 6);
      var brush = new SolidBrush(Color.DarkOrchid);

      canvas.DrawRectangle(pen, CordPoint.XStart, CordPoint.YStart, _side, _side);
      canvas.FillRectangle(brush, CordPoint.XStart, CordPoint.YStart, _side, _side);
    }

    public void MoveTo(Graphics canvas, float changeX, float changeY, int BoxSizeX, int BoxSizeY)
    {
            if (CordPoint.XStart + _side + changeX < BoxSizeX && CordPoint.XStart + changeX > 3)
            {
                CordPoint.ChangeX(changeX);
            }
            if (CordPoint.YStart + _side + changeY < BoxSizeY && CordPoint.YStart + changeY > 3)
            {
                CordPoint.ChangeY(changeY);
            }

            Show(canvas);
    }

    public void ResizeSquare(Graphics canvas, float SizeChange, int BoxSizeX, int BoxSizeY)
    {
        if (SizeChange > 0 && SizeChange < _side || CordPoint.XStart + SizeChange <= BoxSizeX && CordPoint.YStart + SizeChange <= BoxSizeY)
        {
            _side = SizeChange;
        }
        Show(canvas);
    }
  }
}