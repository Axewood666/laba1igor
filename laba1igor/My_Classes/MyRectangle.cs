using System.Drawing;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace laba1igor.My_Classes
{
    internal class MyRectangle
  {
    //private float _xStart;
    //private float _yStart;

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

    //public float XStart
    //{
    //  get => _xStart;
    //  set => _xStart = value;
    //}

    //public float YStart
    //{
    //  get => _yStart;
    //  set => _yStart = value;
    //}
    public MyPoint CordPoint 
        { get; set; }

        public MyRectangle(MyPoint myPoint, int xSizeInit, int ySizeInit)
    {
            if (xSizeInit > 0 && ySizeInit > 0)
            {
                CordPoint = myPoint;
                XSize = xSizeInit;
                YSize = ySizeInit;
                MessageBox.Show($"Прямоугольник в точке [{CordPoint.XStart}, {CordPoint.YStart}], c шириной {xSizeInit} и высотой {ySizeInit} создан!", "Уведомление!",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
    }

    public void Show(Graphics canvas)
    {
      canvas.DrawRectangle(pen, CordPoint.XStart, CordPoint.YStart, XSize, YSize); 
      canvas.FillRectangle(brush, CordPoint.XStart, CordPoint.YStart, XSize, YSize);
    }

    public void MoveTo(Graphics canvas, float newX, float newY, int BoxSizeX, int BoxSizeY,bool random)
    {
      if (CordPoint.XStart + _xSize + newX < BoxSizeX && CordPoint.XStart + newX > 3)
            {
                CordPoint.ChangeX(newX);
            }
            else if (!random)
                {
                    MessageBox.Show("Перемещение по x невозможно!", "Выход за границы!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }

      if (CordPoint.YStart + _ySize + newY < BoxSizeY && CordPoint.YStart + newY > 3)
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

    public void ResizeRectangle(Graphics canvas, float xNewSize, float yNewSize, int BoxSizeX, int BoxSizeY, bool random) 
    {
            if (xNewSize > 0 && yNewSize > 0 && ((xNewSize < XSize && yNewSize < YSize) || CordPoint.XStart + xNewSize <= BoxSizeX && CordPoint.YStart + yNewSize <= BoxSizeY))
            {
                XSize = (int)xNewSize;
                YSize = (int)yNewSize;
            }
            else if (!random)
            {
                MessageBox.Show("Неверно введен размер", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
            }


            Show(canvas);
    }
  }
} 