using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba1igor.My_Classes
{
    public class MyPoint
    {
        private int _xStart;
        private int _yStart;
        public int XStart
        {
            get => _xStart;
            set => _xStart = value;
        }
        public int YStart
        {
            get => _yStart;
            set => _yStart = value;
        }
        public MyPoint(int x, int y)
        {
            XStart = x;
            YStart = y;
            MessageBox.Show($"Точка x: {x} y: {y} создана!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
        }
        public void ChangeX(int NewX)
        {
            XStart = NewX;
        }
        public void ChangeY(int NewY)
        {
            YStart = NewY;
        }
    }
}
