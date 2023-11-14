using MyGraphicLib;
using System.Drawing;
using System.Windows.Forms;

namespace laba1igor.My_Classes
{
    public class MyRhombus : MyQuadrilateral
    {
        public MyRhombus(MyPoint CordPoint,
          int width, int height) : base(CordPoint, width, height)
        {
            MessageBox.Show($"Ромб в точке [{CordPoint.XStart}, {CordPoint.YStart}], c размером [{width},{height}] создан!", "Уведомление!",
            MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        public override void Show(Graphics canvas)
        {
            Point[] points = {
            new Point((int)CordPoint.XStart + Width / 2, (int)CordPoint.YStart),
            new Point((int)CordPoint.XStart + Width, (int)CordPoint.YStart + Height / 2),
            new Point((int)CordPoint.XStart + Width / 2, (int)CordPoint.YStart + Height),
            new Point((int)CordPoint.XStart, (int)CordPoint.YStart + Height / 2)
            };
            var pen = new Pen(Color.Black, 6);
            Brush brush = new SolidBrush(Color.OrangeRed);
            canvas.DrawPolygon(pen, points);
            canvas.FillPolygon(brush, points);
        }
    }
}