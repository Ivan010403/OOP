﻿using System.Windows.Forms;

namespace lab_7
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.figuresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeTheColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeTheSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeTheLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ungroupingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.stickyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.figuresToolStripMenuItem,
            this.actionsToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.groupingToolStripMenuItem,
            this.ungroupingToolStripMenuItem,
            this.stickyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1078, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // figuresToolStripMenuItem
            // 
            this.figuresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.circleToolStripMenuItem,
            this.triangleToolStripMenuItem,
            this.rectangleToolStripMenuItem,
            this.defaultToolStripMenuItem1});
            this.figuresToolStripMenuItem.Name = "figuresToolStripMenuItem";
            this.figuresToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.figuresToolStripMenuItem.Text = "Figures";
            // 
            // circleToolStripMenuItem
            // 
            this.circleToolStripMenuItem.Name = "circleToolStripMenuItem";
            this.circleToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.circleToolStripMenuItem.Text = "Circle";
            this.circleToolStripMenuItem.Click += new System.EventHandler(this.circleToolStripMenuItem_Click);
            // 
            // triangleToolStripMenuItem
            // 
            this.triangleToolStripMenuItem.Name = "triangleToolStripMenuItem";
            this.triangleToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.triangleToolStripMenuItem.Text = "Triangle";
            this.triangleToolStripMenuItem.Click += new System.EventHandler(this.triangleToolStripMenuItem_Click);
            // 
            // rectangleToolStripMenuItem
            // 
            this.rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem";
            this.rectangleToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.rectangleToolStripMenuItem.Text = "Rectangle";
            this.rectangleToolStripMenuItem.Click += new System.EventHandler(this.rectangleToolStripMenuItem_Click);
            // 
            // defaultToolStripMenuItem1
            // 
            this.defaultToolStripMenuItem1.Name = "defaultToolStripMenuItem1";
            this.defaultToolStripMenuItem1.Size = new System.Drawing.Size(158, 26);
            this.defaultToolStripMenuItem1.Text = "Default";
            this.defaultToolStripMenuItem1.Click += new System.EventHandler(this.defaultToolStripMenuItem1_Click);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeTheColorToolStripMenuItem,
            this.changeTheSizeToolStripMenuItem,
            this.changeTheLocationToolStripMenuItem,
            this.deleteObjectToolStripMenuItem,
            this.defaultToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // changeTheColorToolStripMenuItem
            // 
            this.changeTheColorToolStripMenuItem.Name = "changeTheColorToolStripMenuItem";
            this.changeTheColorToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.changeTheColorToolStripMenuItem.Text = "Change the color";
            this.changeTheColorToolStripMenuItem.Click += new System.EventHandler(this.changeTheColorToolStripMenuItem_Click);
            // 
            // changeTheSizeToolStripMenuItem
            // 
            this.changeTheSizeToolStripMenuItem.Name = "changeTheSizeToolStripMenuItem";
            this.changeTheSizeToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.changeTheSizeToolStripMenuItem.Text = "Change the size";
            this.changeTheSizeToolStripMenuItem.Click += new System.EventHandler(this.changeTheSizeToolStripMenuItem_Click);
            // 
            // changeTheLocationToolStripMenuItem
            // 
            this.changeTheLocationToolStripMenuItem.Name = "changeTheLocationToolStripMenuItem";
            this.changeTheLocationToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.changeTheLocationToolStripMenuItem.Text = "Change the location";
            this.changeTheLocationToolStripMenuItem.Click += new System.EventHandler(this.changeTheLocationToolStripMenuItem_Click);
            // 
            // deleteObjectToolStripMenuItem
            // 
            this.deleteObjectToolStripMenuItem.Name = "deleteObjectToolStripMenuItem";
            this.deleteObjectToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.deleteObjectToolStripMenuItem.Text = "Delete object";
            this.deleteObjectToolStripMenuItem.Click += new System.EventHandler(this.deleteObjectToolStripMenuItem_Click);
            // 
            // defaultToolStripMenuItem
            // 
            this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            this.defaultToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(54, 24);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // groupingToolStripMenuItem
            // 
            this.groupingToolStripMenuItem.Name = "groupingToolStripMenuItem";
            this.groupingToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.groupingToolStripMenuItem.Text = "Grouping";
            this.groupingToolStripMenuItem.Click += new System.EventHandler(this.groupingToolStripMenuItem_Click);
            // 
            // ungroupingToolStripMenuItem
            // 
            this.ungroupingToolStripMenuItem.Name = "ungroupingToolStripMenuItem";
            this.ungroupingToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.ungroupingToolStripMenuItem.Text = "Ungrouping";
            this.ungroupingToolStripMenuItem.Click += new System.EventHandler(this.ungroupingToolStripMenuItem_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 31);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(800, 417);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
            this.pictureBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseClick);
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseMove);
            this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseUp);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(806, 31);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(270, 417);
            this.treeView1.TabIndex = 2;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            this.treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
            this.treeView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyUp);
            // 
            // stickyToolStripMenuItem
            // 
            this.stickyToolStripMenuItem.Name = "stickyToolStripMenuItem";
            this.stickyToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.stickyToolStripMenuItem.Text = "Sticky";
            this.stickyToolStripMenuItem.Click += new System.EventHandler(this.stickyToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 450);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem figuresToolStripMenuItem;
        private ToolStripMenuItem circleToolStripMenuItem;
        private ToolStripMenuItem triangleToolStripMenuItem;
        private ToolStripMenuItem rectangleToolStripMenuItem;
        private ToolStripMenuItem defaultToolStripMenuItem1;
        private ToolStripMenuItem actionsToolStripMenuItem;
        private ToolStripMenuItem changeTheColorToolStripMenuItem;
        private ToolStripMenuItem changeTheSizeToolStripMenuItem;
        private ToolStripMenuItem changeTheLocationToolStripMenuItem;
        private ToolStripMenuItem deleteObjectToolStripMenuItem;
        private ToolStripMenuItem defaultToolStripMenuItem;
        private PictureBox pictureBox2;
        private Graphics graph;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private ToolStripMenuItem groupingToolStripMenuItem;
        private ToolStripMenuItem ungroupingToolStripMenuItem;
        private TreeView treeView1;
        private ToolStripMenuItem stickyToolStripMenuItem;
    }
}