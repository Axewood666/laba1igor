using System.Drawing;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace laba1igor.My_Classes
{
    public class MyRectangle : MySquare
  {
    private int _ySize;
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

        public MyRectangle(MyPoint CordPoint, int xSizeInit, int ySizeInit) : base (CordPoint, xSizeInit)
    {
            YSize = ySizeInit;
            MessageBox.Show($"Прямоугольник в точке [{CordPoint.XStart}, {CordPoint.YStart}], c шириной {xSizeInit} и высотой {ySizeInit} создан!", "Уведомление!",
            MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
    }

    public void Show(Graphics canvas)
    {
        Pen pen = new Pen(Color.Black, 6);
        Brush brush = new SolidBrush(Color.OrangeRed);
        canvas.DrawRectangle(pen, CordPoint.XStart, CordPoint.YStart, Side, YSize); 
        canvas.FillRectangle(brush, CordPoint.XStart, CordPoint.YStart, Side, YSize);
    }

    public void ResizeRectangle(Graphics canvas, float xNewSize, float yNewSize) 
    {
            Side = (int)xNewSize;
            YSize = (int)yNewSize;
            Show(canvas);
    }
  }
} 