using System;
using System.Drawing;

namespace laba1igor.My_Classes
{
    public class MyEllipse
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

        public MyEllipse(float coordXStart, float coordYStart,
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
            var centerXDraw = XStart - XSize / 2F;
            var centerYDraw = YStart - YSize / 2F;
            canvas.DrawEllipse(pen, centerXDraw, centerYDraw, XSize, YSize);
            canvas.FillEllipse(brush, centerXDraw, centerYDraw, XSize, YSize);
        }

        public void MoveTo(Graphics canvas, float newX, float newY)
        {
            if (_xStart + _xSize/2 + newX <= 877 && _xStart - XSize/2 + newX >= 0)
            {
                XStart += newX;
            }
            if (_yStart + _ySize/2 + newY < 500 && _yStart - YSize/2 + newY >= 0)
            {
                YStart += newY;
            }
            Show(canvas);
        }

        public void ResizeEllipse(Graphics canvas, float xNewSize, float yNewSize)
        {
            if (xNewSize > 0 && yNewSize > 0 && ((xNewSize < XSize && yNewSize < YSize) || _xStart + xNewSize / 2 <= 877 && _yStart + yNewSize / 2 <= 500 && _xStart - xNewSize / 2 >= 0 && _yStart - yNewSize / 2 >= 0))
            {
                XSize = (int)xNewSize;
                YSize = (int)yNewSize;
            }
            Show(canvas);
        }
    }
}