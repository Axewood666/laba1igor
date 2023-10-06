using System;
using System.Drawing;

namespace laba1igor.My_Classes
{
    internal class MyEllipse
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
        //    get => _xStart;
        //    set => _xStart = value;
        //}

        //public float YStart
        //{
        //    get => _yStart;
        //    set => _yStart = value;
        //}
        public MyPoint CordPoint
        { get; set; }

        public MyEllipse(MyPoint Cords,
          int xSizeInit, int ySizeInit)
        {
            if (xSizeInit > 0 && ySizeInit > 0)
            {
                CordPoint = Cords;

                XSize = xSizeInit;
                YSize = ySizeInit;
            }
        }

        public void Show(Graphics canvas)
        {
            var centerXDraw = CordPoint.XStart - XSize / 2F;
            var centerYDraw = CordPoint.YStart - YSize / 2F;
            canvas.DrawEllipse(pen, centerXDraw, centerYDraw, XSize, YSize);
            canvas.FillEllipse(brush, centerXDraw, centerYDraw, XSize, YSize);
        }

        public void MoveTo(Graphics canvas, float newX, float newY, int BoxSizeX, int BoxSizeY)
        {
            if (CordPoint.XStart + _xSize/2 + newX <= BoxSizeX && CordPoint.XStart - XSize/2 + newX >= 3)
            {
                CordPoint.ChangeX(newX);
            }
            if (CordPoint.YStart + _ySize/2 + newY < BoxSizeY && CordPoint.YStart - YSize/2 + newY >= 3)
            {
                CordPoint.ChangeY(newY);
            }
            Show(canvas);
        }

        public void ResizeEllipse(Graphics canvas, float xNewSize, float yNewSize, int BoxSizeX, int BoxSizeY)
        {
            if (xNewSize > 0 && yNewSize > 0 && ((xNewSize < XSize && yNewSize < YSize) || CordPoint.XStart + xNewSize / 2 <= BoxSizeX && CordPoint.YStart + yNewSize / 2 <= BoxSizeY && CordPoint.XStart - xNewSize / 2 >= 3 && CordPoint.YStart - yNewSize / 2 >= 3))
            {
                XSize = (int)xNewSize;
                YSize = (int)yNewSize;
            }
            Show(canvas);
        }
    }
}