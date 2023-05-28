using System;
using System.Collections.Specialized;
using System.DirectoryServices;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace lab_7
{
    public partial class Form1 : Form
    {
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
            this.graph = Graphics.FromImage(pictureBox2.Image);
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
                graph.Clear(BackColor);
                for (int i = 0; i < array.size(); i++)
                {
                    if (array.getObject(i) != null)
                    {
                        array.getObject(i).draw(e, graph);
                        this.pictureBox2.Invalidate();
                    }
                }
                array.setStatusOfDrawing(true);
            }
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (!array.ClickOnScreen(e.X, e.Y, CtrlPress))
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

                treeView1.Nodes.Clear();
                uploadTree();
            }

            array.setStatusOfDrawing(false);
            this.pictureBox2.Invalidate();
        }

        private void uploadTree()
        {
            this.treeView1.Nodes.Add("Storage");

            for (int i = 0; i < array.size(); i++)
            {
                if (array.getObject(i) != null)
                {
                    if (array.getObject(i).getNode()!=null)
                    {
                        this.treeView1.Nodes[0].Nodes.Add(array.getObject(i).getNode());

                    }
                }
            }

        }

        //private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        //{
        //    for (int i = 0; i < array.size(); i++)
        //    {
        //        if (treeView1.TopNode.LastNode.Index >= i) // Выбор объектов в меню Storage
        //            array.getObject(i).SetStatusClicking(treeView1.TopNode.Nodes[i].Checked);
        //    }
        //    pictureBox2.Invalidate();
        //}

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (changePosition)
            {
                for (int i = 0; i < array.size(); i++)
                {
                    if (array.getObject(i)!=null)
                    {
                        if (array.getObject(i).GetStatusClicking() == true)
                        {
                            array.getObject(i).changePositionIfPossible(e.X - initial_x, e.Y - initial_y);
                        }
                        this.pictureBox2.Invalidate();
                        array.setStatusOfDrawing(false);
                    }
                }
                initial_x = e.X;
                initial_y = e.Y;
                array.setStatusOfDrawing(false);
            }

            if (changeSize)
            {
                for (int i = 0; i < array.size(); i++)
                {
                    if (array.getObject(i)!= null)
                    {
                        if (array.getObject(i).GetStatusClicking() == true)
                        {
                            array.getObject(i).ChangeSizeIfPossible(e.X - initial_x);
                        }
                        this.pictureBox2.Invalidate();
                        array.setStatusOfDrawing(false);
                    }
                }
                initial_x = e.X;
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

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "ControlKey")
            {
                CtrlPress = true;
            }
        }

        private void treeView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "ControlKey")
            {
                CtrlPress = false;
            }
        }
    }
}
