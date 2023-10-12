using MyGraphicLib;
using System.Drawing;
using System.Windows.Forms;

namespace laba1igor.My_Classes
{
    public class MySquare : MyQuadrilateral
    {

        public MySquare(MyPoint CordPoint,
          int side, int side1 = 0) : base (CordPoint, side, side1)
        {
            Width = side;
            Height = side;
            MessageBox.Show($"Квадрат в точке [{CordPoint.XStart}, {CordPoint.YStart}], c размером {side} создан!", "Уведомление!",
            MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

        }

        public override void Show(Graphics canvas)
        {
            var pen = new Pen(Color.Black, 6);
            var brush = new SolidBrush(Color.DarkOrchid);
            canvas.DrawRectangle(pen, CordPoint.XStart, CordPoint.YStart, Width, Height);
            canvas.FillRectangle(brush, CordPoint.XStart, CordPoint.YStart, Width, Height);
        }
    }
}