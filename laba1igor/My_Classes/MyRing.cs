using System;
using System.Drawing;
using System.Windows.Forms;

namespace laba1igor.My_Classes
{
    internal class MyRing
    {
        public MyPoint CordPoint1
        { get; set; }
        public MyPoint CordPoint2 
        { get; set; }
        public MyCircle circle1 { get; set; }
        public MyCircle circle2 { get; set; }

        public MyRing(MyPoint Cords, float radiusValue)
        {

            circle1 = new MyCircle(Cords, radiusValue, Color.DarkRed);
            circle2 = new MyCircle(Cords, radiusValue * 0.75F, Color.WhiteSmoke);
            MessageBox.Show($"Кольцо с центром в точке [{circle1.CordPoint.XStart}, {circle1.CordPoint.YStart}], c радиусом {circle1.Radius} создан!", "Уведомление!",
            MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        public void Show(Graphics canvas)
        {
            circle1.Show(canvas);
            circle2.Show(canvas);
            //canvas.DrawEllipse(pen, CordPoint.XStart - _radius, CordPoint.YStart - _radius, Radius * 2, Radius * 2);
            //canvas.FillEllipse(brushOUT, CordPoint.XStart - _radius, CordPoint.YStart - _radius, Radius * 2, Radius * 2);
            //canvas.DrawEllipse(pen, CordPoint.XStart - _radius * 0.75F, CordPoint.YStart - _radius * 0.75F, Radius * 2 * 0.75F, Radius * 2 * 0.75F);
            //canvas.FillEllipse(brushIN, CordPoint.XStart - _radius * 0.75F, CordPoint.YStart - _radius * 0.75F, Radius * 2 * 0.75F, Radius * 2 * 0.75F);
        }

        public void MoveTo(Graphics canvas, float newX, float newY, int BoxSizeX, int BoxSizeY, bool random)
        {
            if (circle1.CordPoint.XStart + circle1.Radius + newX <= BoxSizeX && circle1.CordPoint.XStart - circle1.Radius + newX >= 3)
            {
                circle1.CordPoint.ChangeX(newX);
            }
            else if (!random)
            {
                MessageBox.Show("Перемещение по x невозможно!", "Выход за границы!",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            if (circle1.CordPoint.YStart + circle1.Radius + newY <= BoxSizeY && circle1.CordPoint.YStart - circle1.Radius + newY >= 3)
            {
                circle1.CordPoint.ChangeY(newY);
            }
            else if (!random)
            {
                MessageBox.Show("Перемещение по y невозможно!", "Выход за границы!",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

            Show(canvas);
        }

        public void ResizeCircle(Graphics canvas, float sizeChange, int BoxSizeX, int BoxSizeY, bool Random)
        {
            if (sizeChange < circle1.Radius || circle1.CordPoint.XStart + sizeChange <= BoxSizeX && circle1.CordPoint.YStart + sizeChange <= BoxSizeY && circle1.CordPoint.XStart - sizeChange >= 3 && circle1.CordPoint.YStart - sizeChange >= 3)
            {
                circle1.ResizeCircle(canvas, sizeChange, BoxSizeX, BoxSizeY, Random);
                circle2.ResizeCircle(canvas, sizeChange * 0.75F, BoxSizeX, BoxSizeY, Random);
            }
            else if (!Random)
            {
                MessageBox.Show("Радиус выходит за границы", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
            }
            Show(canvas);
        }
    }
}