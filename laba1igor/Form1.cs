﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba1igor
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void circle_Click(object sender, EventArgs e)
        {
            var form_Circle = new Form_Circle();
            form_Circle.Show();
        }

        private void rectangle_Click(object sender, EventArgs e)
        {
            var form_Rect = new Form_Rect();
            form_Rect.Show();
        }

        private void line_Click(object sender, EventArgs e)
        {
            var form_Line = new Form_Line();
            form_Line.Show();
        }

        private void square_Click(object sender, EventArgs e)
        {
            var form_Square = new Form_Square();
            form_Square.Show();
        }

        private void ring_Click(object sender, EventArgs e)
        {
            var form_Ring = new Form_Ring();
            form_Ring.Show();
        }

        private void Rhombus_Click(object sender, EventArgs e)
        {
            var form_Rhombus = new Form_Rhombus();
            form_Rhombus.Show();
        }

        private void Trapezoid_Click(object sender, EventArgs e)
        {
            var form_Trapezoid = new Form_Trapezoid();
            form_Trapezoid.Show();
        }

        private void All_Click(object sender, EventArgs e)
        {
            var form_Figures = new Form_Figures();
            form_Figures.Show();
        }

        private void Array_Click(object sender, EventArgs e)
        {
            var form_Array = new Form_Array();
            form_Array.Show();
        }

        private void List_Click(object sender, EventArgs e)
        {
            var form_List = new Form_List();
            form_List.Show();
        }
    }
}
