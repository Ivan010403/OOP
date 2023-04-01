using System;
using System.Drawing;
using System.Security.Policy;

namespace lab_4
{
    public partial class Form1 : Form
    {
        private bool CtrlPress = false;
        private _Array array = new _Array();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!array.CheckClick(e.X, e.Y))
            {
                array.AddObject(new CCircle(e.X, e.Y));
            }
            else
            {
                array.setClickOrNot(e.X, e.Y, CtrlPress);
            }
            array.setStatusOfDrawing(false);
            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (!array.drawed())
            {
                for (int i = 0; i < array.size(); i++)
                {
                    if (array.getObject(i)!=null)
                    {
                        array.getObject(i).DrawCircle(e);
                    }
                }
                array.setStatusOfDrawing(true);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "ControlKey")
            {
                CtrlPress = true;
            }

            if (e.KeyCode.ToString() == "Delete")
            {
                array.RemoveAllObj();
                this.Invalidate();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "ControlKey")
            {
                CtrlPress = false;
            }
        }
    }

    class CCircle
    {
        private int x;
        private int y;
        private const int radius = 25;
        private bool selected = false;

        private Pen pen1 = new Pen(Color.Red, 10);
        private Pen pen2 = new Pen(Color.DarkBlue, 10);

        public CCircle(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void SetStatusClicking(bool vr)
        {
            selected = vr;
        }

        public bool CheckInsideOrNot (int x_1, int y_1)
        {
            return (((x_1 - x) * (x_1 - x) + (y_1 - y) * (y_1 - y)) < ((radius + 5) * (radius + 5)));
        }

        public void DrawCircle(PaintEventArgs e)
        {
            if (selected)
            {
                e.Graphics.DrawEllipse(pen2, x - radius, y - radius, radius * 2, radius * 2);
            }
            else
            {
                e.Graphics.DrawEllipse(pen1, x - radius, y - radius, radius * 2, radius * 2);
            }
        }
    }

    class _Array
    {
        private CCircle[] array;
        private int _size;
        private bool abildraw = true;

        public bool CheckClick (int x, int y)
        {
            bool summ = false;
            for (int i = 0; i < _size; i++)
            {
                if ((array[i] != null)&&(array[i].CheckInsideOrNot(x, y)))
                {
                    summ = true;
                }
            }
            return summ;
        }

        public bool drawed ()
        {
            return abildraw;
        }

        public void setStatusOfDrawing (bool result)
        {
            abildraw = result;
        }


        public void setClickOrNot (int x, int y, bool CtrlPress)
        {
            for (int i = 0; i < _size; i++)
            {
                if (array[i].CheckInsideOrNot(x, y))
                {
                    array[i].SetStatusClicking(true);
                }
                else
                {
                    if (!CtrlPress)
                    {
                        array[i].SetStatusClicking(false);
                    }
                }
            }
        }

        private void clearAllClicked()
        {
            for (int i = 0; i < _size; i++)
            {
                array[i].SetStatusClicking(false);
            }
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

        public void RemoveAllObj()
        {
            for (int i = 0; i < _size; i++)
            {
                array[i] = null;
            }
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

            clearAllClicked();
            return 0;
        }
    };
}