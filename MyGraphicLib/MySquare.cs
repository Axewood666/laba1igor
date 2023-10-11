using System.Drawing;
using System.Windows.Forms;

namespace laba1igor.My_Classes
{
    public class MySquare : MyFigure
    {
        private float _side;
        public float Side
        {
            get => _side;
            set => _side = value;
        }

        public MySquare(MyPoint CordPoint,
          float side) : base(CordPoint)
        {
            Side = side;
            MessageBox.Show($"Квадрат в точке [{CordPoint.XStart}, {CordPoint.YStart}], c размером {side} создан!", "Уведомление!",
            MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

        }

        public override void Show(Graphics canvas)
        {
            var pen = new Pen(Color.Black, 6);
            var brush = new SolidBrush(Color.DarkOrchid);
            canvas.DrawRectangle(pen, CordPoint.XStart, CordPoint.YStart, Side, Side);
            canvas.FillRectangle(brush, CordPoint.XStart, CordPoint.YStart, Side, Side);
        }

        public void ResizeSquare(Graphics canvas, float SizeChange)
        {
            _side = SizeChange;
            Show(canvas);
        }
    }
}