using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace laba1igor.My_Classes
{
    public abstract class MyFigure
    {
        public MyPoint CordPoint
        { get; set; }
        public MyFigure(MyPoint Cordinates)
        {
            CordPoint = Cordinates;
        }

        public virtual void Show(Graphics canvas)
        {

        }

        public void MoveTo(int newX, int newY, Graphics canvas)
        {
            CordPoint.ChangeX(newX);
            CordPoint.ChangeY(newY);
            Show(canvas);
        }
    }
}

