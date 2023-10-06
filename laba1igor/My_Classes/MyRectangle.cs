using System.Drawing;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace laba1igor.My_Classes
{
    internal class MyRectangle
  {
    private float _xStart;
    private float _yStart;

    private int _xSize;
    private int _ySize;
    
    private Pen pen = new Pen(Color.Black, 6);
    private Brush brush = new SolidBrush(Color.OrangeRed);

    public int XSize
        {
        get => _xSize;
        set
        {
            if (value > 0)
            {
                _xSize = value;
            }
        }
        }

    public int YSize
    {
      get => _ySize;
      set
      {
        if (value > 0)
        {
          _ySize = value;
        }
      }
    }

    public float XStart
    {
      get => _xStart;
      set => _xStart = value;
    }

    public float YStart
    {
      get => _yStart;
      set => _yStart = value;
    }
    public MyPoint CordPoint 
        { get; set; }

        public MyRectangle(MyPoint myPoint, int xSizeInit, int ySizeInit)
    {
            if (xSizeInit > 0 && ySizeInit > 0)
            {
                CordPoint = myPoint;
                XSize = xSizeInit;
                YSize = ySizeInit;
            }
    }

    public void Show(Graphics canvas)
    {
      canvas.DrawRectangle(pen, CordPoint.XStart, CordPoint.YStart, XSize, YSize); 
      canvas.FillRectangle(brush, CordPoint.XStart, CordPoint.YStart, XSize, YSize);
    }

    public void MoveTo(Graphics canvas, float newX, float newY, int BoxSizeX, int BoxSizeY)
    {
      if (CordPoint.XStart + _xSize + newX < BoxSizeX && CordPoint.XStart + newX > 3)
            {
                CordPoint.ChangeX(newX);
            }
      if (CordPoint.YStart + _ySize + newY < BoxSizeY && CordPoint.YStart + newY > 3)
            {
                CordPoint.ChangeY(newY);
            }
      Show(canvas);
    }

    public void ResizeRectangle(Graphics canvas, float xNewSize, float yNewSize, int BoxSizeX, int BoxSizeY) 
    {
            if (xNewSize > 0 && yNewSize > 0 && ((xNewSize < XSize && yNewSize < YSize) || _xStart + xNewSize <= BoxSizeX && _yStart + yNewSize <= BoxSizeY))
            {
                XSize = (int)xNewSize;
                YSize = (int)yNewSize;
            }
     
      Show(canvas);
    }
  }
} 