using System.Collections.Specialized;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace lab_6
{
    public partial class Form1 : Form
    {
        private TextBox red = new TextBox();
        private TextBox green = new TextBox();
        private TextBox blue = new TextBox();


        private _Array array = new _Array();
        private string current_figure = "default";

        public Form1()
        {
            InitializeComponent();
        }

        #region clicks on menu's items
        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            current_figure = "circle";
        }

        private void triangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            current_figure = "triangle";
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            current_figure = "rectangle";
        }

        private void defaultToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            current_figure = "default";
        }

        private void changeTheColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            current_figure = "default";

            red.Size = new Size(40, 20);
            green.Size = new Size(40, 20);
            blue.Size = new Size(40, 20);

            red.Location = new Point(600, 100);
            green.Location = new Point(600, 150);
            blue.Location = new Point(600, 200);

            Controls.Add(red);
            Controls.Add(green);
            Controls.Add(blue);

            Button enter_rgb = new Button();
            enter_rgb.Location = new Point(700, 150);
            enter_rgb.Text = "Enter rgb";
            Controls.Add(enter_rgb);
            enter_rgb.MouseClick += Enter_rgb_MouseClick;
            array.setStatusOfDrawing(false);
        }

        private void Enter_rgb_MouseClick(object? sender, MouseEventArgs e)
        {
            for (int i = 0; i < array.size(); i++)
            {
                if (array.getObject(i).GetStatusClicking()==true)
                {
                    array.getObject(i).setPen(Convert.ToInt32(red.Text), Convert.ToInt32(green.Text), Convert.ToInt32(blue.Text));
                }
            }
            array.setStatusOfDrawing(false);
            this.Invalidate();
        }

        private void changeTheSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            current_figure = "default";
        }

        private void changeTheLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            current_figure = "default";
        }

        private void deleteObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            current_figure = "default";
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            current_figure = "default";

        }
        #endregion

        private void Form1_MouseClick(object sender, MouseEventArgs e)
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
                        //array.AddObject(new CRectangle(e.X, e.Y));
                        break;
                    case "default":
                        break;
                }
            }
            else
            {
                array.setStatus(e.X, e.Y);
            }
            
            
            array.setStatusOfDrawing(false);
            this.Invalidate();
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            if (!array.drawed())
            {
                for (int i = 0; i < array.size(); i++)
                {
                    if (array.getObject(i) != null)
                    {
                        array.getObject(i).draw(e);
                    }
                }
                array.setStatusOfDrawing(true);
            }
        }
    }

    public class CFigure
    {
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

        public virtual void draw (PaintEventArgs e)
        {
            return;
        }

        public void setPen(int r, int g, int b)
        {
            pen2 = new Pen(Color.FromArgb(r, g, b), 10);
        }
    }

    public class CCircle : CFigure
    {
        private int x;
        private int y;
        private const int radius = 25;


        public CCircle (int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool CheckInsideOrNot(int x_1, int y_1)
        {
            return (((x_1 - x) * (x_1 - x) + (y_1 - y) * (y_1 - y)) < ((radius + 5) * (radius + 5)));
        }

        public override void draw(PaintEventArgs e)
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

    public class CTriangle : CFigure
    {
        private int initial_x, initial_y;

        int[] x = new int[3];
        int[] y = new int[3];

        public CTriangle(int x, int y)
        {
            this.initial_x = x;
            this.initial_y = y;
        }

        public override bool CheckInsideOrNot(int x_1, int y_1)
        {
            int a = (x[0] - x_1) * (y[1] - y[0]) - (x[1] - x[0]) * (y[0] - y_1);
            int b = (x[1] - x_1) * (y[2] - y[1]) - (x[2] - x[1]) * (y[1] - y_1);
            int c = (x[2] - x_1) * (y[0] - y[2]) - (x[0] - x[2]) * (y[2] - y_1);

            if ((a >= 0 && b >= 0 && c >= 0) || (a <= 0 && b <= 0 && c <= 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class CRectangle : CFigure
    {
        public override bool CheckInsideOrNot(int x_1, int y_1)
        {
            return false;
        }
    }




    public class Model
    {
        private int A;
        private int B;
        private int C;

        private string[] readAllFile;
        private string pathToFile;

        public System.EventHandler observers;
        public Model()
        {
            pathToFile = "C:\\Users\\vanyk\\OneDrive\\Документы\\GitHub\\OOP\\lab_4_2\\data.txt";
            readAllFile = File.ReadAllLines(pathToFile);

            if (readAllFile.Length == 3)
            {
                A = Convert.ToInt16(readAllFile[0]);
                B = Convert.ToInt16(readAllFile[1]);
                C = Convert.ToInt16(readAllFile[2]);
            }
            else
            {
                MessageBox.Show("Broken file");
            }
        }

        #region Getters and setters
        public void setA(int A)
        {
            if (this.A != A)
            {
                this.A = A;
                ConditionsForA();
                observers.Invoke(this, null);
            }
        }

        public void setB(int B)
        {
            if (this.B != B)
            {
                if (checkConditionsForB(B))
                {
                    this.B = B;
                }
                observers.Invoke(this, null);
            }
        }

        public void setC(int C)
        {
            if (this.C != C)
            {
                this.C = C;
                ConditionsForA();
                observers.Invoke(this, null);
            }
        }


        public int getA()
        {
            return A;
        }

        public int getB()
        {
            return B;
        }

        public int getC()
        {
            return C;
        }

        #endregion


        #region Conditions
        private void ConditionsForA()
        {
            if (A > B) B = A;
            if (A > C) C = A;

            if (A > 100) A = 100;
            if (B > 100) B = 100;
            if (C > 100) C = 100;


            if (A < 0) A = 0;
            if (B < 0) B = 0;
            if (C < 0) C = 0;
        }

        private void ConditionsForC()
        {
            if (C < B) B = C;
            if (C < A) A = C;

            if (A > 100) A = 100;
            if (B > 100) B = 100;
            if (C > 100) C = 100;

            if (A < 0) A = 0;
            if (B < 0) B = 0;
            if (C < 0) C = 0;
        }

        private bool checkConditionsForB(int B)
        {
            if ((B < 0) || (B > 100) || (A > B) || (B > C)) return false;
            else return true;
        }

        #endregion

        public void SaveData()
        {
            readAllFile[0] = Convert.ToString(A);
            readAllFile[1] = Convert.ToString(B);
            readAllFile[2] = Convert.ToString(C);

            File.WriteAllLines(pathToFile, readAllFile);
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


        public void setStatus(int x, int y)
        {
            for (int i = 0; i < _size; i++)
            {
                if (array[i].CheckInsideOrNot(x, y))
                {
                    array[i].SetStatusClicking(true);
                }
                else
                {
                    array[i].SetStatusClicking(false);
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