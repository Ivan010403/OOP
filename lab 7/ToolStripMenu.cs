using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab_7
{
    public partial class Form1 : Form
    {
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

            array.setStatusOfDrawing(false);
            if (clr.ShowDialog() == DialogResult.OK)
            {
                curr_color = clr.Color;
            }

            for (int i = 0; i < array.size(); i++)
            {
                if (array.getObject(i).GetStatusClicking() == true)
                {
                    array.getObject(i).setPen(curr_color);
                }
            }
            array.setStatusOfDrawing(false);
            this.Invalidate();
        }

        private void changeTheSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isChange = false;
            current_figure = "default";
            isChangeSize = true;
        }

        private void changeTheLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isChangeSize = false;
            current_figure = "default";
            isChange = true;
        }

        private void deleteObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            current_figure = "default";
            for (int i = 0; i < array.size(); i++)
            {
                if (array.getObject(i) != null)
                {
                    if (array.getObject(i).GetStatusClicking() == true)
                    {
                        array.RemoveObj(i);
                    }
                    array.setStatusOfDrawing(false);
                    this.Invalidate();
                }
            }
        }



        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;

            StreamWriter fstream = new StreamWriter(filename, false);

            int counter = 0;
            for (int i = 0; i < array.size(); i++)
            {
                if (array.getObject(i) != null)
                {
                    if (array.getObject(i).GetStatusClicking() == true)
                    {
                        counter++;
                    }
                            
                }
            }

            fstream.WriteLine(counter.ToString());

            for (int i = 0; i < array.size(); i++)
            {
                if (array.getObject(i) != null)
                {
                    if (array.getObject(i).GetStatusClicking() == true)
                    {
                        array.getObject(i).save(fstream);
                    }
                }
            }
            
            fstream.Close();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;

            
            array.loadFigures(filename, array);

            array.notifyTree();
            treeView1.Nodes.Clear();
            uploadTree();

            array.setStatusOfDrawing(false);
            this.pictureBox2.Invalidate();
        }


        private void groupingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < array.size(); i++)
            {
                if (array.getObject(i) != null)
                {
                    if (array.getObject(i).GetStatusClicking())
                    {
                        group.addFigure(array.getObject(i));
                        array.RemoveObj(i);
                    }
                }
            }
            
            array.AddObject(group);
            group = new CGroup();
            array.setStatusOfDrawing(false);

            array.notifyTree();
            treeView1.Nodes.Clear();
            uploadTree();


            this.pictureBox2.Invalidate();
        }

        private void ungroupingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < array.size(); i++)
            {
                if (array.getObject(i) != null)
                {
                    if (array.getObject(i).GetStatusClicking())
                    {
                        if (array.getObject(i) is CGroup)
                        {
                            array.getObject(i).ungroup(array, i);
                            return;
                        }
                    }
                }
            }
            array.notifyTree();
            treeView1.Nodes.Clear();
            uploadTree();

            this.pictureBox2.Invalidate();
        }

        private void stickyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < array.size(); i++)
            {
                if (array.getObject(i)!=null)
                {
                    if (array.getObject(i).GetStatusClicking()==true)
                    {
                        array.getObject(i).sticky(true);
                    }
                }
            }
        }
    }
}
