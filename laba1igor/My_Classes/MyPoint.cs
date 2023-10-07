﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba1igor.My_Classes
{
    internal class MyPoint
    {
        private float _xStart;
        private float _yStart;
        public float XStart
        {
            get => _xStart;
            set => _xStart = value;
        }
        public float YStart
        {
            get => _yStart;
            set => _yStart = value;
        }
        public MyPoint(float x, float y)
        {
            XStart = x;
            YStart = y;
            MessageBox.Show($"Точка x: {x} y: {y} создана!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
        }
        public void ChangeX(float NewX)
        {
            XStart += NewX;
        }
        public void ChangeY(float NewY)
        {
            YStart += NewY;
        }
    }
}
