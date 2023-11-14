using MyGraphicLib;
using System.Drawing;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace laba1igor.My_Classes
{
    public class MyRectangle : MyQuadrilateral
    {

        public MyRectangle(MyPoint CordPoint, int xSizeInit, int ySizeInit) : base(CordPoint, xSizeInit, ySizeInit)
        {
            MessageBox.Show($"Прямоугольник в точке [{CordPoint.XStart}, {CordPoint.YStart}], c шириной {xSizeInit} и высотой {ySizeInit} создан!", "Уведомление!",
            MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        public override void Show(Graphics canvas)
        {
            Pen pen = new Pen(Color.Black, 6);
            Brush brush = new SolidBrush(Color.OrangeRed);
            canvas.DrawRectangle(pen, CordPoint.XStart, CordPoint.YStart, Width, Height);
            canvas.FillRectangle(brush, CordPoint.XStart, CordPoint.YStart, Width, Height);
        }
    }
}