using System;
using System.Drawing;
using System.Windows.Forms;

namespace laba1igor.My_Classes
{
    public class MyEllipse : MyCircle
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

        public MyEllipse(MyPoint CordPoint,
          int xSizeInit, int ySizeInit) : base (CordPoint, xSizeInit)
        {
            YSize = ySizeInit;
            MessageBox.Show($"Эллипс с центром в точке [{CordPoint.XStart}, {CordPoint.YStart}], c шириной {xSizeInit} и высотой {ySizeInit} создан!", "Уведомление!",
            MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        public override void Show(Graphics canvas)
        {
            Pen pen = new Pen(Color.Black, 6);
            Brush brush = new SolidBrush(Color.OrangeRed);
            var centerXDraw = base.CordPoint.XStart - Radius / 2F;
            var centerYDraw = base.CordPoint.YStart - YSize / 2F;
            canvas.DrawEllipse(pen, centerXDraw, centerYDraw, Radius, YSize);
            canvas.FillEllipse(brush, centerXDraw, centerYDraw, Radius, YSize);
        }


        public void ResizeEllipse(Graphics canvas, float xNewSize, float yNewSize)
        {
            Radius = (int)xNewSize;
            YSize = (int)yNewSize;
            Show(canvas);
        }
    }
}