using System.Drawing;
using System.Security.Cryptography;

namespace laba1igor.My_Classes
{
    public class MyRectangle
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

    public MyRectangle(float coordXStart, float coordYStart,
      int xSizeInit, int ySizeInit)
    {
            if (xSizeInit > 0 && ySizeInit > 0)
            {
                XStart = coordXStart;
                YStart = coordYStart;

                XSize = xSizeInit;
                YSize = ySizeInit;
            }
    }

    public void Show(Graphics canvas)
    {
      canvas.DrawRectangle(pen, XStart, YStart, XSize, YSize); 
      canvas.FillRectangle(brush, XStart, YStart, XSize, YSize);
    }

    public void MoveTo(Graphics canvas, float newX, float newY)
    {
      if (_xStart + _xSize + newX < 877 && _xStart + newX > 0)
            {
                XStart += newX;
            }
      if (_yStart + _ySize + newY < 500 && _yStart + newY > 0)
            {
                YStart += newY;
            }
      Show(canvas);
    }

    public void ResizeRectangle(Graphics canvas, float xNewSize, float yNewSize) 
    {
            if (xNewSize > 0 && yNewSize > 0 && ((xNewSize < XSize && yNewSize < YSize) || _xStart + xNewSize <= 877 && _yStart + yNewSize <= 500))
            {
                XSize = (int)xNewSize;
                YSize = (int)yNewSize;
            }
     
      Show(canvas);
    }
  }
} 