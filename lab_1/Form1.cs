using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form_lab1 : Form
    {
        private TableLayoutPanel Table;
        private string[] SetTasks = new string[15] {"trade information between 2 text boxes",
            "three different buttons sharing the same handler that changes the color of the button pressed",
            "calling event handler from the code",
            "program event invocation",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""};


        public Form_lab1()
        {
            InitializeComponent();
            this.BtnStart.Location = new System.Drawing.Point(this.Size.Width / 2 - 100, this.Size.Height / 2 - 35);
        }

        private void Form_lab1_ClientSizeChanged(object sender, EventArgs e)
        {
            this.BtnStart.Location = new System.Drawing.Point(this.Size.Width / 2 - 100, this.Size.Height / 2 - 35);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            this.BtnStart.Visible = false;
            this.BtnStart.Click -= new System.EventHandler(this.BtnStart_Click);
            this.BtnStart.Click += new System.EventHandler(this.BtnNext_Click);

            CreateFirstSetFunctions();
        }
        
        private void CreateFirstSetFunctions()
        {
            this.Table = new System.Windows.Forms.TableLayoutPanel();

            this.Controls.Add(this.Table);

            this.Table.Location = new System.Drawing.Point(26, 92);
            this.Table.Size = new System.Drawing.Size(800, 600);
            this.Table.Name = "Table";

            this.Table.RowCount = 15;
            for (int i = 0; i < 15; i++)
            {
                this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40));
            }

            this.Table.ColumnCount = 2;
            this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.Table.Paint += new System.Windows.Forms.PaintEventHandler(this.table_Paint);

            Button[] TableBtn = new Button[15];
            Label[] TableLbl = new Label[15];

            for (int i = 0; i < 15; i++)
            {
                TableLbl[i] = new Label();
                TableLbl[i].Dock = DockStyle.Fill;
                this.Table.Controls.Add(TableLbl[i], 0, i);
                TableLbl[i].Text = "Task " + (i+1).ToString() + ": " + this.SetTasks[i];


                TableBtn[i] = new Button();
                TableBtn[i].Dock = DockStyle.Fill;
                this.Table.Controls.Add(TableBtn[i], 1, i);

                TableBtn[i].Name = i.ToString();
                TableBtn[i].Text = "Run task " + (i + 1).ToString();
                TableBtn[i].Click += new System.EventHandler(this.TableBtnMain);
            }
        }

        private void BtnNext_Click (object sender, EventArgs e)
        {
            
        }
        private void TableBtnMain(object sender, EventArgs e)
        {
            this.Table.Visible = false;
          
            string name = (sender as Button).Name;
            
            switch (name)
            {
                case "0":
                    function0();
                    break;
                case "1":
                    function1();
                    break;
                case "2":
                    function2();
                    break;
                case "3":
                    function3();
                    break;
                case "4":
                    function4();
                    break;
                case "5":
                    function5();
                    break;
                case "6":
                    function6();
                    break;
                case "7":
                    function7();
                    break;
                case "8":
                    function8();
                    break;
                case "9":
                    function9();
                    break;
                case "10":
                    function10();
                    break;
                default:
                    break;
            }
        } // ready


        private void table_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Right_Click_StripMenu(object sender, EventArgs e)
        {
            HideAllElements();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ReturnInitialState(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is Panel) c.Visible = true;
            }
        }

        private void HideAllElements()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Panel) c.Visible = false;
            }
        }
    }
}