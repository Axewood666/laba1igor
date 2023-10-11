﻿using System;
using System.Drawing;
using System.Windows.Forms;

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
                MessageBox.Show($"Эллипс с центром в точке [{CordPoint.XStart}, {CordPoint.YStart}], c шириной {xSizeInit} и высотой {ySizeInit} создан!", "Уведомление!",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        public void Show(Graphics canvas)
        {
            var centerXDraw = CordPoint.XStart - XSize / 2F;
            var centerYDraw = CordPoint.YStart - YSize / 2F;
            canvas.DrawEllipse(pen, centerXDraw, centerYDraw, XSize, YSize);
            canvas.FillEllipse(brush, centerXDraw, centerYDraw, XSize, YSize);
        }

        public void MoveTo(Graphics canvas, float newX, float newY, int BoxSizeX, int BoxSizeY, bool random)
        {
            if (CordPoint.XStart + _xSize/2 + newX <= BoxSizeX && CordPoint.XStart - XSize/2 + newX >= 3)
            {
                CordPoint.ChangeX(newX);
            }
                else if (!random)
                {
                    MessageBox.Show("Перемещение по x невозможно!", "Выход за границы!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            if (CordPoint.YStart + _ySize/2 + newY < BoxSizeY && CordPoint.YStart - YSize/2 + newY >= 3)
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

        public void ResizeEllipse(Graphics canvas, float xNewSize, float yNewSize, int BoxSizeX, int BoxSizeY, bool random)
        {
            if ((xNewSize < XSize && yNewSize < YSize) || CordPoint.XStart + xNewSize / 2 <= BoxSizeX && CordPoint.YStart + yNewSize / 2 <= BoxSizeY && 
                CordPoint.XStart - xNewSize / 2 >= 3 && CordPoint.YStart - yNewSize / 2 >= 3)
            {
                XSize = (int)xNewSize;
                YSize = (int)yNewSize;
            }
            else if (!random)
            {
                MessageBox.Show("Размер выходит за границы", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
            }
            Show(canvas);
        }
    }
}