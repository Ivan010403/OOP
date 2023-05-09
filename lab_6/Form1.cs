using System.Collections.Specialized;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace lab_6
{
    public partial class Form1 : Form
    {
        private TextBox red = new TextBox();
        private TextBox green = new TextBox();
        private TextBox blue = new TextBox();
        private Button enter_rgb = new Button();
        private ColorDialog clr = new ColorDialog();
        private Color curr_color = new Color();

        private _Array array = new _Array();
        private string current_figure = "default";

        private bool CtrlPress = false;

        private bool isChange = false;
        private bool changePosition = false;

        private bool isChangeSize = false;
        private bool changeSize = false;

        private int initial_x = 0;
        private int initial_y = 0;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "ControlKey")
            {
                CtrlPress = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "ControlKey")
            {
                CtrlPress = false;
            }
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            if (!array.drawed())
            {
                for (int i = 0; i < array.size(); i++)
                {
                    if (array.getObject(i) != null)
                    {
                        array.getObject(i).draw(e, graph);
                    }
                }
                array.setStatusOfDrawing(true);
                
            }
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (!array.CheckClick(e.X, e.Y))
            {
                switch (current_figure)
                {
                    case "circle":
                        array.AddObject(new CCircle(e.X, e.Y));
                        break;
                    case "triangle":
                        array.AddObject(new CTriangle(e.X, e.Y));
                        break;
                    case "rectangle":
                        array.AddObject(new CRectangle(e.X, e.Y));
                        break;
                    case "default":
                        break;
                }
            }
            else
            {
                array.setStatus(e.X, e.Y, CtrlPress);
            }


            array.setStatusOfDrawing(false);
            this.pictureBox2.Invalidate();
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (changePosition)
            {
                for (int i = 0; i < array.size(); i++)
                {
                    if (array.getObject(i).GetStatusClicking() == true)
                    {
                        array.getObject(i).changePositionIfPossible(e.X - initial_x, e.Y - initial_y);
                    }
                    this.pictureBox2.Invalidate();
                    array.setStatusOfDrawing(false);
                }
                initial_x = e.X;
                initial_y = e.Y;
                array.setStatusOfDrawing(false);
            }

            if (changeSize)
            {
                for (int i = 0; i < array.size(); i++)
                {
                    if (array.getObject(i).GetStatusClicking() == true)
                    {
                        array.getObject(i).ChangeSizeIfPossible(e.X - initial_x);
                    }
                    this.pictureBox2.Invalidate();
                    array.setStatusOfDrawing(false);
                }
                initial_x = e.X;
                initial_y = e.Y;
                array.setStatusOfDrawing(false);
            }
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (isChange)
            {
                changePosition = true;
                initial_x = e.X;
                initial_y = e.Y;
            }
            if (isChangeSize)
            {
                changeSize = true;
                initial_x = e.X;
                initial_y = e.Y;
            }
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            if (isChange)
            {
                changePosition = false;
            }

            if (isChangeSize)
            {
                changeSize = false;
            }
        }

    }
    public class CFigure
    {
        protected int x, y;
        protected int size = 0; //
        protected bool selected = false;

        protected Pen pen1 = new Pen(Color.Red, 10);
        protected Pen pen2 = new Pen(Color.DarkBlue, 10);

        public virtual bool CheckInsideOrNot(int x_1, int y_1)
        {
            return false;
        }

        public void SetStatusClicking(bool vr)
        {
            selected = vr;
        }
        public bool GetStatusClicking()
        {
            return selected;
        }

        public virtual void draw(PaintEventArgs e, Graphics graph)
        {
            return;
        }

        public void setPen(Color clr)
        {
            pen2 = new Pen(clr, 10);
        }

        public virtual void ChangeSizeIfPossible(int dx)
        {
            return;
        }

        public virtual void changePositionIfPossible(int x, int y)
        {
            return;
        }
    }

    public class CCircle : CFigure
    {
        private const int radius = 25;


        public CCircle(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool CheckInsideOrNot(int x_1, int y_1)
        {
            return (((x_1 - x) * (x_1 - x) + (y_1 - y) * (y_1 - y)) < ((radius + 5) * (radius + 5)));
        }

        public override void draw(PaintEventArgs e, Graphics graph)
        {
            if (selected)
            {
                graph.DrawEllipse(pen2, x - Convert.ToInt32(radius + size / 2), y - Convert.ToInt32(radius + size / 2), Convert.ToInt32(radius * 2 + size), Convert.ToInt32(radius * 2 + size));
            }
            else
            {
                graph.DrawEllipse(pen1, x - Convert.ToInt32(radius + size / 2), y - Convert.ToInt32(radius + size / 2), Convert.ToInt32(radius * 2 + size), Convert.ToInt32(radius * 2 + size));
            }
        }

        public override void changePositionIfPossible(int x, int y)
        {
            if (!(((this.x + radius + this.size / 2 > 800) && (x > 0)) || ((this.x - radius - this.size / 2 < 0) && (x < 0)) || ((this.y - radius - this.size / 2 < 0) && (y < 0)) || ((this.y + radius + this.size / 2 > 450) && (y > 0))))
            {
                this.x = this.x + x;
                this.y = this.y + y;
            }
        }
        public override void ChangeSizeIfPossible(int dx_1) //сделать отдельную функцию
        {
            if (!((this.x + radius + this.size / 2 > 800) || (this.x - radius - this.size / 2 < 0) || (this.y - radius - this.size / 2 < 0) || (this.y + radius + this.size / 2 > 450)))
            {
                this.size = this.size + dx_1;
            }
            else
            {
                if (dx_1 < 0)
                {
                    this.size = this.size + dx_1;
                }
            }
            if (this.size < 0)
            {
                this.size = 0;
            }
        }
    }

    public class CTriangle : CFigure
    {
        private Point[] points = new Point[3];
        public CTriangle(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        private void setVertices()
        {
            points[0].X = x - Convert.ToInt32(30 + size); points[0].Y = y + Convert.ToInt32(20 + size);
            points[1].X = x; points[1].Y = y - Convert.ToInt32(20 + size);
            points[2].X = x + Convert.ToInt32(30 + size); points[2].Y = y + Convert.ToInt32(20 + size);
        }

        public override bool CheckInsideOrNot(int x_1, int y_1)
        {
            int a = (points[0].X - x_1) * (points[1].Y - points[0].Y) - (points[1].X - points[0].X) * (points[0].Y - y_1);
            int b = (points[1].X - x_1) * (points[2].Y - points[1].Y) - (points[2].X - points[1].X) * (points[1].Y - y_1);
            int c = (points[2].X - x_1) * (points[0].Y - points[2].Y) - (points[0].X - points[2].X) * (points[2].Y - y_1);

            if ((a >= 0 && b >= 0 && c >= 0) || (a <= 0 && b <= 0 && c <= 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void draw(PaintEventArgs e, Graphics graph)
        {
            setVertices();
            if (selected)
            {
                graph.DrawPolygon(pen2, points);
            }
            else
            {
                graph.DrawPolygon(pen1, points);
            }
        }

        public override void changePositionIfPossible(int x, int y)
        {
            if (!(((this.x + x - 30 - size < 0) && (x < 0)) || ((this.x + x + 30 + size > 800) && (x > 0)) || ((this.y - 20 - size < 0) && (y < 0)) || ((this.y + 20 + size > 450) && (y > 0))))
            {
                this.x = this.x + x;
                this.y = this.y + y;
            }
        }
        public override void ChangeSizeIfPossible(int dx_1)
        {
            if (!CheckBorders())
            {
                this.size = this.size + dx_1;
            }
            else
            {
                if (dx_1 < 0)
                {
                    this.size = this.size + dx_1;
                }
            }
            if (this.size < 0)
            {
                this.size = 0;

            }
        }

        public bool CheckBorders()
        {
            if ((this.x + 30 + size > 800) || (this.x - 30 - size < 0) || (this.y - 2 - size < 0) || (this.y + 20 + size > 450))
            {
                return false;
            }
            else return true;
        }
    }

    public class CRectangle : CFigure
    {
        private Point[] points = new Point[4];
        public CRectangle(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        private void setVertices()
        {
            points[0].X = x - Convert.ToInt32(20 + size); points[0].Y = y + Convert.ToInt32(20 + size);
            points[1].X = x - Convert.ToInt32(20 + size); points[1].Y = y - Convert.ToInt32(20 + size);
            points[2].X = x + Convert.ToInt32(20 + size); points[2].Y = y - Convert.ToInt32(20 + size);
            points[3].X = x + Convert.ToInt32(20 + size); points[3].Y = y + Convert.ToInt32(20 + size);

        }

        public override bool CheckInsideOrNot(int x_1, int y_1)
        {
            if ((x_1 >= points[1].X) && (x_1 <= points[3].X) && (y_1 >= points[1].Y) && (y_1 <= points[3].Y))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void draw(PaintEventArgs e, Graphics graph)
        {
            setVertices();
            if (selected)
            {
                graph.DrawPolygon(pen2, points);
            }
            else
            {
                graph.DrawPolygon(pen1, points);
            }
        }

        public override void changePositionIfPossible(int x, int y)
        {
            if (!(((this.x - 20 - size < 0) && (x < 0)) || ((this.x + 20 + size > 800) && (x > 0)) || (((this.y - 20 - size) < 0) && (y < 0)) || ((this.y + 20 + size > 450) && (y > 0))))
            {
                this.x = this.x + x;
                this.y = this.y + y;
            }
        }

        public override void ChangeSizeIfPossible(int dx_1)
        {
            if (!((this.x - 20 - size < 0) || (this.x + 20 + size > 800) || ((this.y - 20 - size) < 0) || (this.y + 20 + size > 450)))
            {
                this.size = this.size + dx_1;
            }
            else
            {
                if (dx_1 < 0)
                {
                    this.size = this.size + dx_1;
                }
            }
            if (this.size < 0)
            {
                this.size = 0;
            }
        }
    }


    class _Array
    {
        private CFigure[] array;
        private int _size;
        private bool abildraw = true;

        public bool CheckClick(int x, int y)
        {
            bool summ = false;
            for (int i = 0; i < _size; i++)
            {
                if ((array[i] != null) && (array[i].CheckInsideOrNot(x, y)))
                {
                    summ = true;
                }
            }
            return summ;
        }

        public bool drawed()
        {
            return abildraw;
        }

        public void setStatusOfDrawing(bool result)
        {
            abildraw = result;
        }


        public void setStatus(int x, int y, bool CtrlPress)
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
            array = new CFigure[0];
            Console.WriteLine("_Array()\n");
        }

        public CFigure getObject(int pozition)
        {
            return array[pozition];
        }

        public void SetObject(int pozition, CFigure crc)
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
        public int AddObject(CFigure crc)
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
            CFigure[] arr_copy = new CFigure[_size];
            for (int i = 0; i < _size - 1; i++)
            {
                arr_copy[i] = array[i];
            }
            arr_copy[_size - 1] = crc;

            array = arr_copy;

            clearAllClicked();
            return 0;
        }
    }
}
    












//    public class Model
//    {

//        private string[] readAllFile;
//        private string pathToFile;

//        public System.EventHandler observers;
//        public Model()
//        {
//            pathToFile = "C:\\Users\\vanyk\\OneDrive\\Документы\\GitHub\\OOP\\lab_6\\data.txt";
//            readAllFile = File.ReadAllLines(pathToFile);
//        }

//        public void SaveData()
//        {

//        }
//    }

//}