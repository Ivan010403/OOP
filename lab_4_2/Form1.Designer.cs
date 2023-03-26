namespace lab_4_2
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
            this.trackBar_A = new System.Windows.Forms.TrackBar();
            this.trackBar_B = new System.Windows.Forms.TrackBar();
            this.trackBar_C = new System.Windows.Forms.TrackBar();
            this.textBox_A = new System.Windows.Forms.TextBox();
            this.textBox_B = new System.Windows.Forms.TextBox();
            this.textBox_C = new System.Windows.Forms.TextBox();
            this.numericUpDown_C = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_B = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_A = new System.Windows.Forms.NumericUpDown();
            this.label_B = new System.Windows.Forms.Label();
            this.label_A = new System.Windows.Forms.Label();
            this.label_C = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_B)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_C)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_C)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_B)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_A)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar_A
            // 
            this.trackBar_A.Location = new System.Drawing.Point(71, 284);
            this.trackBar_A.Maximum = 100;
            this.trackBar_A.Name = "trackBar_A";
            this.trackBar_A.Size = new System.Drawing.Size(125, 56);
            this.trackBar_A.TabIndex = 0;
            this.trackBar_A.Scroll += new System.EventHandler(this.trackBar_A_Scroll);
            // 
            // trackBar_B
            // 
            this.trackBar_B.Location = new System.Drawing.Point(330, 284);
            this.trackBar_B.Maximum = 100;
            this.trackBar_B.Name = "trackBar_B";
            this.trackBar_B.Size = new System.Drawing.Size(125, 56);
            this.trackBar_B.TabIndex = 1;
            // 
            // trackBar_C
            // 
            this.trackBar_C.Location = new System.Drawing.Point(583, 284);
            this.trackBar_C.Maximum = 100;
            this.trackBar_C.Name = "trackBar_C";
            this.trackBar_C.Size = new System.Drawing.Size(125, 56);
            this.trackBar_C.TabIndex = 2;
            // 
            // textBox_A
            // 
            this.textBox_A.Location = new System.Drawing.Point(71, 155);
            this.textBox_A.Name = "textBox_A";
            this.textBox_A.Size = new System.Drawing.Size(125, 27);
            this.textBox_A.TabIndex = 3;
            this.textBox_A.TextChanged += new System.EventHandler(this.textBox_A_TextChanged);
            // 
            // textBox_B
            // 
            this.textBox_B.Location = new System.Drawing.Point(330, 155);
            this.textBox_B.Name = "textBox_B";
            this.textBox_B.Size = new System.Drawing.Size(125, 27);
            this.textBox_B.TabIndex = 4;
            // 
            // textBox_C
            // 
            this.textBox_C.Location = new System.Drawing.Point(583, 155);
            this.textBox_C.Name = "textBox_C";
            this.textBox_C.Size = new System.Drawing.Size(125, 27);
            this.textBox_C.TabIndex = 5;
            // 
            // numericUpDown_C
            // 
            this.numericUpDown_C.Location = new System.Drawing.Point(583, 230);
            this.numericUpDown_C.Name = "numericUpDown_C";
            this.numericUpDown_C.Size = new System.Drawing.Size(125, 27);
            this.numericUpDown_C.TabIndex = 6;
            // 
            // numericUpDown_B
            // 
            this.numericUpDown_B.Location = new System.Drawing.Point(330, 230);
            this.numericUpDown_B.Name = "numericUpDown_B";
            this.numericUpDown_B.Size = new System.Drawing.Size(125, 27);
            this.numericUpDown_B.TabIndex = 7;
            // 
            // numericUpDown_A
            // 
            this.numericUpDown_A.Location = new System.Drawing.Point(71, 230);
            this.numericUpDown_A.Name = "numericUpDown_A";
            this.numericUpDown_A.Size = new System.Drawing.Size(125, 27);
            this.numericUpDown_A.TabIndex = 8;
            this.numericUpDown_A.ValueChanged += new System.EventHandler(this.numericUpDown_A_ValueChanged);
            // 
            // label_B
            // 
            this.label_B.AutoSize = true;
            this.label_B.Font = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_B.Location = new System.Drawing.Point(355, 52);
            this.label_B.Name = "label_B";
            this.label_B.Size = new System.Drawing.Size(76, 89);
            this.label_B.TabIndex = 9;
            this.label_B.Text = "B";
            // 
            // label_A
            // 
            this.label_A.AutoSize = true;
            this.label_A.Font = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_A.Location = new System.Drawing.Point(95, 52);
            this.label_A.Name = "label_A";
            this.label_A.Size = new System.Drawing.Size(81, 89);
            this.label_A.TabIndex = 10;
            this.label_A.Text = "A";
            // 
            // label_C
            // 
            this.label_C.AutoSize = true;
            this.label_C.Font = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_C.Location = new System.Drawing.Point(606, 52);
            this.label_C.Name = "label_C";
            this.label_C.Size = new System.Drawing.Size(79, 89);
            this.label_C.TabIndex = 11;
            this.label_C.Text = "C";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(199, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 89);
            this.label4.TabIndex = 12;
            this.label4.Text = "<=";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(453, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 89);
            this.label5.TabIndex = 13;
            this.label5.Text = "<=";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_C);
            this.Controls.Add(this.label_A);
            this.Controls.Add(this.label_B);
            this.Controls.Add(this.numericUpDown_A);
            this.Controls.Add(this.numericUpDown_B);
            this.Controls.Add(this.numericUpDown_C);
            this.Controls.Add(this.textBox_C);
            this.Controls.Add(this.textBox_B);
            this.Controls.Add(this.textBox_A);
            this.Controls.Add(this.trackBar_C);
            this.Controls.Add(this.trackBar_B);
            this.Controls.Add(this.trackBar_A);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_B)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_C)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_C)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_B)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_A)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TrackBar trackBar_A;
        private TrackBar trackBar_B;
        private TrackBar trackBar_C;
        private TextBox textBox_A;
        private TextBox textBox_B;
        private TextBox textBox_C;
        private NumericUpDown numericUpDown_C;
        private NumericUpDown numericUpDown_B;
        private NumericUpDown numericUpDown_A;
        private Label label_B;
        private Label label_A;
        private Label label_C;
        private Label label4;
        private Label label5;
    }
}