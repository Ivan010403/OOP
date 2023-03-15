using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    partial class Form_lab1
    {
        private TextBox text1;
        private TextBox text2;

        private CheckBox ChckBx;
        private Label label = new Label();

        private RadioButton radioButton1;
        private RadioButton radioButton2;

        private ListBox listbox;

        private ComboBox comboBox;

        private MonthCalendar calendar;

        private NumericUpDown numericUpDown;

        private PictureBox picture;

        private ProgressBar progress;
        private System.Windows.Forms.Timer time;

        private ToolTip toolTip;

        private void function0()
        {
            text1 = new TextBox();
            text2 = new TextBox();

            text1.Size = new Size(150, 30);
            text2.Size = new Size(150, 30);

            text1.Location = new Point(200, 200);
            text2.Location = new Point(800, 200);

            text1.Name = "1";
            text2.Name = "2";

            this.Controls.Add(text1);
            this.Controls.Add(text2);

            text1.TextChanged += fnct0_TxtChanged;
            text2.TextChanged += fnct0_TxtChanged;
        }

        private void fnct0_TxtChanged(object sender, EventArgs e)
        {
            string name_sender = (sender as TextBox).Name;

            if (name_sender == "1")
            {
                text2.Text = text1.Text;
            }
            else if (name_sender == "2")
            {
                text1.Text = text2.Text;
            }
        }

        private void function1()
        {
            ChckBx = new CheckBox();
            ChckBx.Checked = false;
            ChckBx.Location = new Point(200, 200);

            Controls.Add(ChckBx);

            label.Location = new Point(400, 200);
            label.Size = new Size(100, 100);
            Controls.Add(label);

            ChckBx.CheckedChanged += ChckBx_CheckedChanged;
        }

        private void ChckBx_CheckedChanged(object? sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox.Checked == true)
            {
                label.Text = "true";
            }
            else if (checkBox.Checked == false)
            {
                label.Text = "false";
            }
        }

        private void function2()
        {
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();


            radioButton1.Location = new Point(200, 200);
            radioButton2.Location = new Point(200, 250);

            Controls.Add(radioButton1);
            Controls.Add(radioButton2);

            radioButton1.Name = "1";
            radioButton2.Name = "2";

            label.Location = new Point(400, 200);
            label.Size = new Size(100, 100);
            Controls.Add(label);

            radioButton1.CheckedChanged += RadioButton_CheckedChanged;
            radioButton2.CheckedChanged += RadioButton_CheckedChanged;
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            string name = (sender as RadioButton).Name;

            if (name == "1")
            {
                label.Text = "Нажали верхнюю кнопку";
            }
            else if (name == "2")
            {
                label.Text = "Нажали нижнюю кнопку";
            }
        }

        private void function3()
        {
            listbox = new ListBox();
            listbox.Location = new Point(200, 200);
            listbox.Size = new Size(200, 200);
            Controls.Add(listbox);

            string[] full_name = new string[3] { "Козлов", "Иван", "Алексеевич" };
            listbox.Items.AddRange(full_name);

            label.Location = new Point(400, 200);
            label.Size = new Size(100, 100);
            Controls.Add(label);

            listbox.SelectedIndexChanged += Listbox_SelectedIndexChanged;
        }

        private void Listbox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ListBox lstbx = (ListBox)sender;

            label.Text = lstbx.SelectedItem.ToString();
            
        }

        private void function4()
        {
            comboBox = new ComboBox();

            comboBox.Location = new Point(200, 200);
            comboBox.Size = new Size(200, 200);
            Controls.Add(comboBox);

            comboBox.Items.AddRange(new string[] { "Макеев", "Григорий"});
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            label.Location = new Point(400, 200);
            label.Size = new Size(100, 100);
            Controls.Add(label);

            comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
        }

        private void ComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ComboBox cmbbx = (ComboBox)sender;

            label.Text = cmbbx.SelectedItem.ToString();
        }

        private void function5()
        {
            calendar = new MonthCalendar();

            calendar.Location = new Point(200, 200);
            calendar.Size = new Size(300, 300);
            Controls.Add(calendar);

            label.Location = new Point(400, 200);
            label.Size = new Size(100, 100);
            Controls.Add(label);

            calendar.DateSelected += Calendar_DateSelected;

        }

        private void Calendar_DateSelected(object? sender, DateRangeEventArgs e)
        {
            MonthCalendar calendar = (MonthCalendar)sender;
            label.Text = calendar.SelectionStart.ToString();
        }

        private void function6()
        {
            numericUpDown = new NumericUpDown();
            numericUpDown.Location = new Point(200, 200);
            Controls.Add(numericUpDown);

            label.Location = new Point(400, 200);
            label.Size = new Size(100, 100);
            Controls.Add(label);

            numericUpDown.ValueChanged += NumericUpDown_ValueChanged;
        }

        private void NumericUpDown_ValueChanged(object? sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;

            label.Text = numericUpDown.Value.ToString();
        }

        private void function7()
        {
            picture = new PictureBox();

            picture.Location = new Point(200, 200);
            picture.Size = new Size(400, 400);
            Controls.Add(picture);

            label.Location = new Point(600, 200);
            label.Size = new Size(100, 100);
            Controls.Add(label);

            picture.SizeMode = PictureBoxSizeMode.Zoom;
            picture.Image = Image.FromFile("C:\\Users\\vanyk\\OneDrive\\Изображения\\Saved Pictures\\img.jpg");

            picture.DoubleClick += Picture_DoubleClick;
        }

        private void Picture_DoubleClick(object? sender, EventArgs e)
        {
            label.Text = "Вы нажали на картинку дважды";
        }

        private void function8()
        {
            progress = new ProgressBar();
            progress.Location = new Point(200, 200);
            progress.Size = new Size(200, 100);
            Controls.Add(progress);

            progress.Minimum = 0;
            progress.Maximum = 100;
            progress.Step = 10;

            label.Location = new Point(600, 200);
            label.Size = new Size(100, 100);
            Controls.Add(label);

            time = new System.Windows.Forms.Timer();
            time.Interval = 500;
            time.Enabled = true;
            time.Tick += Time_Tick;

        }

        private void Time_Tick(object? sender, EventArgs e)
        {
            if (progress.Value == 100)
            {
                label.Text = "Ready!!!";
            }
            progress.PerformStep();
        }

        private void function9()
        {
            toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;

            TextBox text = new TextBox();
            
            text.Size = new Size(150, 30);
            text.Location = new Point(200, 200);
            Controls.Add(text);

            toolTip.SetToolTip(text, "That is textbox");
        }

        private void function10()
        {
            label.Location = new Point(600, 200);
            label.Size = new Size(200, 100);
            Controls.Add(label);
            this.label.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_lab1_MouseMove);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_lab1_MouseMove);
        }
        private void Form_lab1_MouseMove(object sender, MouseEventArgs e)
        {

            label.Text = e.Location.ToString();
        }
    }
}