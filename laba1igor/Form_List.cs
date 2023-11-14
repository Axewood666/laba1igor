using laba1igor.My_Classes;
using MyGraphicLib;
using MyGraphicLib.list;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace laba1igor
{
    public partial class Form_List : Form
    {
        private MyList _list;
        public enum Methods
        {
            ShowTo = 0,
            Move = 1,
            delete = 2,
            add = 3
        }
        public Form_List()
        {
            InitializeComponent();
            buf = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(buf);
            g.Clear(Color.WhiteSmoke);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (_list == null) { _list = new MyList(); }
            else { MessageBox.Show("Список уже создан, сначала удалите его", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_list != null)
            {
                g.Clear(Color.WhiteSmoke);
                PictureBoxUpd();
                _list.Iterator(g, (int)Methods.delete);
                _list = null;
            }
            else { MessageBox.Show("Список не создан", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_list != null)
            {
                _list.Iterator(g, (int)Methods.add);
                PictureBoxUpd();
            }
            else { MessageBox.Show("Сначала создайте лист", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            g.Clear(Color.WhiteSmoke);
            PictureBoxUpd();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (_list != null)
            {
                g.Clear(Color.WhiteSmoke);
                _list.Iterator(g, (int)Methods.Move);
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
            if (_list != null)
            {
                _list.Iterator(g, (int)Methods.ShowTo);
                PictureBoxUpd();
            }


        }
    }
}
