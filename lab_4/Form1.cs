using System;
using System.Drawing;
using System.Security.Policy;

namespace lab_4
{
    public partial class Form1 : Form
    {
        private _Array array = new _Array();
        Pen pen1 = new Pen(Color.Red, 10);
        Pen pen2 = new Pen(Color.Coral, 10);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            array.AddObject(new CCircle(e.X, e.Y));
            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (!array.drawed())
            {
                for (int i = 0; i < array.size(); i++)
                {
                    array.getObject(i).DrawCircle(pen1, e, this);
                }
                array.set_status(true);
            }
        }
    }

    class CCircle
    {
        private int x;
        private int y;
        private const int diam = 50;

        public CCircle(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void DrawCircle(Pen pen, PaintEventArgs e, Form1 frm)
        {
            e.Graphics.DrawEllipse(pen, x - diam/2, y - diam/2, diam, diam);
        }
    }

    class _Array
    {
        private CCircle[] array;
        private int _size;
        private bool abildraw;

        public bool drawed ()
        {
            return abildraw;
        }

        public void set_status (bool result)
        {
            abildraw = result;
        }

        public int size()
        {
            return _size;
        }

        public _Array()
        {
            array = new CCircle[0];
            Console.WriteLine("_Array()\n");
        }

        public _Array(int size)
        {
            _size = size;
            array = new CCircle[_size];
            Console.WriteLine("_Array(int size)\n");
        }

        public CCircle getObject (int pozition)
        {
            return array[pozition];
        }

        public void SetObject(int pozition, CCircle crc)
        {
            array[pozition] = crc; //работаем с указателями
        }

        public void RemoveObj(int pozition)
        {
            array[pozition] = null;
        }

        public int AddObject(CCircle crc)
        {
            abildraw = false;
            for (int i = 0; i < _size; i++)
            {
                if (array[i] == null)
                {
                    SetObject(i, crc);
                    return 0;
                }
            }

            _size += 1;
            CCircle[] arr_copy = new CCircle[_size];
            for (int i = 0; i < _size - 1; i++)
            {
                arr_copy[i] = array[i];
            }
            arr_copy[_size - 1] = crc;

            array = arr_copy;
            return 0;
        }

    };
}