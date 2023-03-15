namespace WinFormsApp1
{
    partial class Form_lab1
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenAllFunction_Click = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnStart = new System.Windows.Forms.Button();
            this.RightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.HideAllElmntsRghtClck = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.RightClickMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.OpenAllFunction_Click});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1182, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // OpenAllFunction_Click
            // 
            this.OpenAllFunction_Click.Name = "OpenAllFunction_Click";
            this.OpenAllFunction_Click.Size = new System.Drawing.Size(186, 24);
            this.OpenAllFunction_Click.Text = "Return to the initial state";
            this.OpenAllFunction_Click.Click += new System.EventHandler(this.ReturnInitialState);
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(500, 250);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(200, 70);
            this.BtnStart.TabIndex = 1;
            this.BtnStart.Text = "Начать защиту лабы!!!!!!!";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // RightClickMenu
            // 
            this.RightClickMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.RightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HideAllElmntsRghtClck});
            this.RightClickMenu.Name = "contextMenuStrip1";
            this.RightClickMenu.Size = new System.Drawing.Size(201, 28);
            // 
            // HideAllElmntsRghtClck
            // 
            this.HideAllElmntsRghtClck.Name = "HideAllElmntsRghtClck";
            this.HideAllElmntsRghtClck.Size = new System.Drawing.Size(200, 24);
            this.HideAllElmntsRghtClck.Text = "Return to the tasks";
            this.HideAllElmntsRghtClck.Click += new System.EventHandler(this.Right_Click_StripMenu);
            // 
            // Form_lab1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.ContextMenuStrip = this.RightClickMenu;
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_lab1";
            this.Text = "Lab 1";
            this.ClientSizeChanged += new System.EventHandler(this.Form_lab1_ClientSizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.RightClickMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem OpenAllFunction_Click;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Button BtnStart;
        
        private ContextMenuStrip RightClickMenu;
        private ToolStripMenuItem HideAllElmntsRghtClck;
    }
}