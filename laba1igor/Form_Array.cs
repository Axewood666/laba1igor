using laba1igor.My_Classes;
using MyGraphicLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace laba1igor
{
    public partial class Form_Array : Form
    {
        private MyArray _arr;
        public Form_Array()
        {
            InitializeComponent();
            buf = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(buf);
            g.Clear(Color.WhiteSmoke);
        }
        public enum Methods
        {
            Add = 0,
            ShowTo = 1,
            Move = 2,
            delete = 3
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (_arr == null) { _arr = new MyArray(); }
            else { MessageBox.Show("Массив уже создан, сначала удалите его", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (_arr != null)
            {
                g.Clear(Color.WhiteSmoke);
                _arr.Iterator(g, (int)Methods.delete);
                _arr = null;
                PictureBoxUpd();
            }
            else { MessageBox.Show("Массив не создан", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
           
        private void button3_Click(object sender, EventArgs e)
        {
            if (_arr != null)
            {
                _arr.Iterator(g, (int)Methods.Add);
                PictureBoxUpd();
            }
            else { MessageBox.Show("Сначала создайте массив", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            g.Clear(Color.WhiteSmoke);
            PictureBoxUpd();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (_arr != null)
            {
                g.Clear(Color.WhiteSmoke);
                _arr.Iterator(g, (int)Methods.Move);
                PictureBoxUpd();
            }
        }
        private void PictureBoxUpd()
        {
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = (Bitmap)buf.Clone();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (_arr != null)
            {
                _arr.Iterator(g, (int)Methods.ShowTo);
                PictureBoxUpd();
            }
        }
    }
}
