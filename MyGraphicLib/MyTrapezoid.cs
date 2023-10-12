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
    public class MyTrapezoid : MyQuadrilateral
    {
        public MyTrapezoid(MyPoint CordPoint, int width, int height) : base(CordPoint, width, height)
        {
            MessageBox.Show($"Трапеция в точке [{CordPoint.XStart}, {CordPoint.YStart}], c размером [{width},{height}] создан!", "Уведомление!",
            MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        public override void Show(Graphics canvas)
        {
            Point[] points = {
        new Point(CordPoint.XStart, CordPoint.YStart),
        new Point(CordPoint.XStart + Width, CordPoint.YStart),
        new Point(CordPoint.XStart + Width - (Width * 2 / 5), CordPoint.YStart - Height),
        new Point(CordPoint.XStart + (Width * 2 / 5), CordPoint.YStart - Height)
            };
            var pen = new Pen(Color.Black, 6);
            Brush brush = new SolidBrush(Color.DarkGoldenrod);
            canvas.DrawPolygon(pen, points);
            canvas.FillPolygon(brush, points);
        }
    }
}
