using laba1igor.My_Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static MyGraphicLib.MyArray;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace MyGraphicLib.list
{
    public class MyList
    {
        public MyElement first;

        public MyList()
        {
            MessageBox.Show("Создан список!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
       
        public void Iterator(Graphics g,int method)
        {
            switch (method)
            {
                case 0:
                    ShowTo(g); break;
                case 1:
                    Move(g); break;
                case 2:
                    Delete(); break;
                case 3:
                    Add(g); break;
            }
        }



        public void Add(Graphics g)
        {
            if (first == null)
            {
                first = new MyElement();
                first.ShowTo(g);
            }
            else
            {
                MyElement current = first;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = new MyElement();
                current.next.ShowTo(g);
            }
        }
        private void ShowTo(Graphics g)
        {
            MyElement current = first;
            while (current != null)
            {
                current.ShowTo(g);
                current = current.next;
            }
        }
        public void Move(Graphics g)
        {
            MyElement current = first;
            while (current != null)
            {
                current.Move(g);
                current = current.next;
            }
        }
        public void Delete()
        {
            if (first != null)
            {
                MyElement current = first;
                if (current.next != null)
                {
                    MyElement currentnext = current.next;
                    while (current.next != null)
                    {
                        current.Delete();
                        current = currentnext;
                        currentnext = current.next;
                    }
                    current.Delete();
                    first = null;
                }
            }
        }

    }
}
