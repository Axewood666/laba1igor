using System;
using System.Drawing;
using System.Windows.Forms;

namespace laba1igor.My_Classes
{
    public class MyRing : MyCircle
    {
        public MyCircle circle1
        { get; set; }
        public MyCircle circle2
        { get; set; }

        public MyRing(MyPoint Cords, int radiusValue, Color color) : base(Cords, radiusValue, color)
        {
            circle1 = new MyCircle(Cords, radiusValue, Color.DarkRed);
            circle2 = new MyCircle(Cords, (int)(radiusValue * 0.75F), Color.WhiteSmoke);
            MessageBox.Show($"Кольцо с центром в точке [{CordPoint.XStart}, {CordPoint.YStart}], c радиусом {Radius} создан!", "Уведомление!",
            MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        public override void Show(Graphics canvas)
        {
            circle1.Show(canvas);
            circle2.Show(canvas);
        }

        public void MoveTo(Graphics canvas, float newX, float newY)
        {
            circle1.CordPoint.ChangeX(newX);
            circle2.CordPoint.ChangeY(newY);

            Show(canvas);
        }

        public void ResizeRing(Graphics canvas, int sizeChange)
        {
            circle1.ResizeCircle(canvas, sizeChange);
            circle2.ResizeCircle(canvas, (int)(sizeChange * 0.75F));

            Show(canvas);
        }
    }
}