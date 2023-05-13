using System;
using System.Collections.Specialized;
using System.DirectoryServices;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace lab_7
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
        private CGroup group = new CGroup();

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
            if ((!array.drawed()) || (!group.drawed()))
            {
                graph.Clear(BackColor);
                for (int i = 0; i < array.size(); i++)
                {
                    if (array.getObject(i) != null)
                    {
                        array.getObject(i).draw(e, graph);
                        this.pictureBox2.Invalidate();
                    }
                }
                for (int i = 0; i < group.size(); i++)
                {
                    group.draw(e, graph);
                    this.pictureBox2.Invalidate();
                }
                array.setStatusOfDrawing(true);
                group.setStatusOfDrawingForGroup(true);
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
                        array.setStatusOfDrawing(false);
                        break;
                    case "triangle":
                        array.AddObject(new CTriangle(e.X, e.Y));
                        array.setStatusOfDrawing(false);
                        break;
                    case "rectangle":
                        array.AddObject(new CRectangle(e.X, e.Y));
                        array.setStatusOfDrawing(false);
                        break;
                    case "default":
                        break;
                }

                group.ungrouping(array);

                this.pictureBox2.Invalidate();
            }
            else
            {
                array.setStatus(e.X, e.Y, CtrlPress);
                int[] index = array.getIndexObjectFromXY(e.X, e.Y);

                for (int i = 0; i < index.Length; i++)
                {
                    group.addFigure(array.getObject(index[i]));
                    array.RemoveObj(index[i]);
                    group.setStatusOfDrawingForGroup(false);
                }
                this.pictureBox2.Invalidate();
            }
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (changePosition)
            {
                group.changePositionIfPossible(e.X - initial_x, e.Y - initial_y);
                    
                initial_x = e.X;
                initial_y = e.Y;

                this.pictureBox2.Invalidate();
                group.setStatusOfDrawingForGroup(false);
            }

            if (changeSize)
            {
                group.ChangeSizeIfPossible(e.X - initial_x);
               
                initial_x = e.X;

                this.pictureBox2.Invalidate();
                group.setStatusOfDrawingForGroup(false);
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

        public virtual bool CheckBorders(int x, int y)
        {
            return false;
        }

        public virtual void save(string path)
        {
            return;
        }

        public virtual void load(string path, string data)
        {
            return;
        }
    }

    public class CCircle : CFigure
    {
        private int radius = 25;

        public CCircle(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public CCircle()
        {
        }

        public override bool CheckInsideOrNot(int x_1, int y_1)
        {
            return (((x_1 - x) * (x_1 - x) + (y_1 - y) * (y_1 - y)) < ((radius + 5) * (radius + 5)));
        }

        public override void draw(PaintEventArgs e, Graphics graph)
        {
            if (selected)
            {
                graph.DrawEllipse(pen2, x - radius, y - radius, radius * 2, radius * 2);
            }
            else
            {
                graph.DrawEllipse(pen1, x - radius, y - radius, radius * 2, radius * 2);
            }
        }

        public override void changePositionIfPossible(int x, int y)
        {
            if (CheckBorders(x, y))
            {
                this.x = this.x + x;
                this.y = this.y + y;
            }
        }
        public override void ChangeSizeIfPossible(int dx_1) //������� ��������� �������
        {
            if (CheckBorders(0, 0))
            {
                radius = radius + dx_1;
            }
            else
            {
                if (dx_1 < 0)
                {
                    radius = radius + dx_1;
                }
            }
            if (radius < 25)
            {
                radius = 25;
            }
        }

        public override bool CheckBorders(int x, int y)
        {
            if (((this.x + radius > 800) && (x >= 0)) || ((this.x - radius < 0) && (x <= 0)) || ((this.y - radius < 0) && (y <= 0)) || ((this.y + radius > 417) && (y >= 0)))
            {
                return false;
            }
            else return true;
        }


        public override void save(string path)
        {
            string[] contents = new string[3];

            contents[0] = Convert.ToString(x);
            contents[1] = Convert.ToString(y);
            contents[2] = Convert.ToString(radius);

            File.WriteAllLines(path, contents);
        }

        public override void load(string path , string data)
        {
            string[] lines = File.ReadAllLines(path);
        }
    }

    public class CTriangle : CFigure
    {
        private Point[] points = new Point[3];
        private int a = 30;
        private int b = 20;
        public CTriangle(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        private void setVertices()
        {
            points[0].X = x - a; points[0].Y = y + b;
            points[1].X = x; points[1].Y = y - b;
            points[2].X = x + a; points[2].Y = y + b;
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
            if (CheckBorders(x, y))
            {
                this.x = this.x + x;
                this.y = this.y + y;
            }
        }
        public override void ChangeSizeIfPossible(int dx_1)
        {
            if (CheckBorders(0, 0))
            {
                a = a + dx_1;
                b = b + dx_1;
            }
            else
            {
                if (dx_1 < 0)
                {
                    a = a + dx_1;
                    b = b + dx_1;
                }
            }
            if (a < 30)
            {
                a = 30;
            }
            if (b < 20)
            {
                b = 20;
            }
        }

        public override bool CheckBorders(int x, int y)
        {
            if (((this.x - a < 10) && (x <= 0)) || ((this.x + a > 790) && (x >= 0)) || ((this.y - b < 10) && (y <= 0)) || ((this.y + b > 407) && (y >= 0)))
            {
                return false;
            }
            else return true;
        }
    }

    public class CRectangle : CFigure
    {
        private Point[] points = new Point[4];
        private int a = 20;
        public CRectangle(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        private void setVertices()
        {
            points[0].X = x - a; points[0].Y = y + a;
            points[1].X = x - a; points[1].Y = y - a;
            points[2].X = x + a; points[2].Y = y - a;
            points[3].X = x + a; points[3].Y = y + a;

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
            if (CheckBorders(x, y))
            {
                this.x = this.x + x;
                this.y = this.y + y;
            }
        }

        public override void ChangeSizeIfPossible(int dx_1)
        {
            if (CheckBorders(0, 0))
            {
                a = a + dx_1;
            }
            else
            {
                if (dx_1 < 0)
                {
                    a = a + dx_1;
                }
            }
            if (a < 20)
            {
                a = 20;
            }
        }

        public override bool CheckBorders(int x, int y)
        {
            if (((this.x - a < 10) && (x <= 0)) || ((this.x + a > 790) && (x >= 0)) || ((this.y - a < 10) && (y <= 0)) || ((this.y + a > 407) && (y >= 0)))
            {
                return false;
            }
            else return true;
        }
    }


    public class CGroup : CFigure
    {
        private int count;
        private bool status_of_drawing;
        private CFigure[] figures;

        public CGroup()
        {
            figures = new CFigure[0];
        }

        public int size()
        {
            return count;
        }

        public bool drawed ()
        {
            return status_of_drawing;
        }
        public void setStatusOfDrawingForGroup(bool res)
        {
            status_of_drawing = res;
        }

        public void addFigure(CFigure curr_fig)
        {
            count++;

            CFigure[] arr_copy = new CFigure[count];
            for (int i = 0; i < count - 1; i++)
            {
                arr_copy[i] = figures[i];
            }
            arr_copy[count - 1] = curr_fig;

            figures = arr_copy;

            figures[count - 1].SetStatusClicking(true);
        }

        public override bool CheckInsideOrNot(int x_1, int y_1)
        {
            for (int i = 0; i < count; i++)
            {
                if (figures[i].CheckInsideOrNot(x_1, y_1))
                {
                    return true;
                }
            }
            return false;
        }

        public override void draw(PaintEventArgs e, Graphics graph)
        {
            for (int i = 0; i < count; i++)
            {
                figures[i].draw(e, graph);
            }
        }

        public override void changePositionIfPossible(int x, int y)
        {
            if (CheckBorders(x, y))
            {
                for (int i = 0; i < count; i++)
                {
                    figures[i].changePositionIfPossible(x, y);
                }
            }
        }

        public override void ChangeSizeIfPossible(int dx)
        {
            if (CheckBorders(0, 0))
            {
                for (int i = 0; i < count; i++)
                {
                    figures[i].ChangeSizeIfPossible(dx);
                }
            }
            else
            {
                if (dx < 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        figures[i].ChangeSizeIfPossible(dx);
                    }
                }
            }
        }

        public override bool CheckBorders(int x, int y)
        {
            for (int i = 0; i < count; i++)
            {
                if (!figures[i].CheckBorders(x, y)) return false;
            }
            return true;
        }

        public void ungrouping(_Array tr)
        {
            for (int i = 0; i < count; i++)
            {
                tr.AddObject(figures[i]);
            }
            figures = new CFigure[0];
            count = 0;
        }

        public void delete()
        {
            figures = new CFigure[0];
            count = 0;
        }
    }


    public class _Array
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
                if (array[i] != null)
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
        public int[] getIndexObjectFromXY (int x, int y)
        {
            int[] mass = new int[0];

            int cnt = 0;
            for (int i = 0; i < _size; i++)
            {
                if (array[i] != null)
                {
                    if (array[i].GetStatusClicking())
                    {
                        cnt++;
                        mass = new int[cnt];
                        mass[cnt - 1] = i;
                    }
                }
            }
            return mass;
        }

        public void SetObject(int pozition, CFigure crc)
        {
            array[pozition] = crc; //�������� � �����������
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
        public void AddObject(CFigure crc)
        {
            abildraw = false;
            for (int i = 0; i < _size; i++)
            {
                if (array[i] == null)
                {
                    SetObject(i, crc);
                    return;
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
            return;
        }

        public virtual CFigure createFigure(string code, string data)
        {
            return null;
        }

        public void loadFigures (string path)
        {
            FileStream fstream = new FileStream("test.txt", FileMode.OpenOrCreate);

            string[] lines = File.ReadAllLines(path);

            for (int i = 0; i < lines.Length; i = i + 2)
            {
                AddObject(createFigure(lines[i], lines[i + 1]));
            }
        }
    }

    public class _Array_factory: _Array
    {
        public override CFigure createFigure(string code, string data)
        {
            var array = data.Split(' ');

            int x = Convert.ToInt32(array[0]);
            int y = Convert.ToInt32(array[0]);

            switch (code)
            {
                case "C":
                    return new CCircle(x, y);
                case "T":
                    return new CTriangle(x, y);
                case "R":
                    return new CRectangle(x, y);
                default:
                    break;
            }
            return null;
        }
    }
}
