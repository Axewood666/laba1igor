using laba1igor.My_Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGraphicLib
{
    public abstract class MyQuadrilateral : MyFigure
    {
        private int width;
        private int height;
        public int  Height
        {
            get => height;
            set
            {
                if (value > 0)
                {
                    height = value;
                }
            }
        }
        public int Width
        {
            get => width;
            set
            {
                if (value > 0)
                {
                    width = value;
                }
            }
        }
        public MyQuadrilateral(MyPoint Cords, int width, int height) : base(Cords)
        {
            this.Width = width;
            this.Height = height;
        }
        public override abstract void Show(Graphics canvas);
        public void ResizeQua (int Nwidth, int Nheight)
        {
            Width = Nwidth;
            Height = Nheight;
        }
        public void ReverseQua()
        {
            (Width, Height) = (Height, Width);
        }
    }
}
