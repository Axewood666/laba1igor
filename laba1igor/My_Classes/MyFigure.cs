using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace laba1igor.My_Classes
{
    internal class MyFigure
    {
        public MyPoint CordPoint
        { get; set; }
        public MyFigure(MyPoint Cordinates)
        {
            CordPoint = Cordinates;
        }

        public void Show()
        {

        }

        public void MoveTo(float newX, float newY)
        {
            CordPoint.ChangeX(newX);
            CordPoint.ChangeY(newY);
        }
    }
}

