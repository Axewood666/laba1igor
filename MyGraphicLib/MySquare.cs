using System.Drawing;
using System.Windows.Forms;

namespace laba1igor.My_Classes
{
    public class MySquare
  {
    //private float _xCenter;
    //private float _yCenter;
    private float _side;

        //public float XCenter 
        //{
        //  get => _xCenter;
        //  set => _xCenter = value;
        //}
        //public float YCenter 
        //{
        //  get => _yCenter;
        //  set => _yCenter = value;
        //}
    public MyPoint CordPoint
    { get; set; }
        public float Side
    {
      get => _side;
      set => _side = value;
    }

    public MySquare(MyPoint Cordinates,
      float side)
    {
        CordPoint = Cordinates;
        Side = side;
        MessageBox.Show($"Квадрат в точке [{CordPoint.XStart}, {CordPoint.YStart}], c размером {side} создан!", "Уведомление!",
        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

    }

    public void Show(Graphics canvas)
    {
      var pen = new Pen(Color.Black, 6);
      var brush = new SolidBrush(Color.DarkOrchid);

      canvas.DrawRectangle(pen, CordPoint.XStart, CordPoint.YStart, _side, _side);
      canvas.FillRectangle(brush, CordPoint.XStart, CordPoint.YStart, _side, _side);
    }

    public void MoveTo(Graphics canvas, float changeX, float changeY, int BoxSizeX, int BoxSizeY, bool random)
    {
            if (CordPoint.XStart + _side + changeX < BoxSizeX && CordPoint.XStart + changeX > 3)
            {
                CordPoint.ChangeX(changeX);
            }
                else if (!random)
                {
                    MessageBox.Show("Перемещение по x невозможно!", "Выход за границы!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            if (CordPoint.YStart + _side + changeY < BoxSizeY && CordPoint.YStart + changeY > 3)
            {
                CordPoint.ChangeY(changeY);
            }
                else if (!random)
                {
                    MessageBox.Show("Перемещение по y невозможно!", "Выход за границы!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            Show(canvas);
    }

    public void ResizeSquare(Graphics canvas, float SizeChange, int BoxSizeX, int BoxSizeY, bool random)
    {
        if (SizeChange < _side || CordPoint.XStart + SizeChange <= BoxSizeX && CordPoint.YStart + SizeChange <= BoxSizeY)
        {
            _side = SizeChange;
        }
        else if (!random)
            {
                MessageBox.Show("Размер выходит за границы!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
            }
        Show(canvas);
    }
  }
}