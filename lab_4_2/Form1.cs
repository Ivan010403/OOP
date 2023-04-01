using System;
using System.IO;
using System.Reflection;

namespace lab_4_2
{
    public partial class Form1 : Form
    {
        private int current_value;
        private Model model;

        public Form1()
        {
            InitializeComponent();

            model = new Model();
            model.observers += new EventHandler(this.UploadValues);
            model.observers.Invoke(this, null);
        }


        #region methods for A

        private void numericUpDown_A_ValueChanged(object sender, EventArgs e)
        {
            current_value = Convert.ToInt16((sender as NumericUpDown).Value);
            model.setA(current_value);
        }

        private void trackBar_A_Scroll(object sender, EventArgs e)
        {
            current_value = Convert.ToInt16((sender as TrackBar).Value);
            model.setA(current_value);
        }
        #endregion


        #region methods for C

        private void numericUpDown_C_ValueChanged(object sender, EventArgs e)
        {
            current_value = Convert.ToInt16((sender as NumericUpDown).Value);
            model.setC(current_value);
        }

        private void trackBar_C_Scroll(object sender, EventArgs e)
        {
            current_value = Convert.ToInt16((sender as TrackBar).Value);
            model.setC(current_value);
        }
        #endregion


        #region methods for B

        private void numericUpDown_B_ValueChanged(object sender, EventArgs e)
        {
            current_value = Convert.ToInt16((sender as NumericUpDown).Value);

            model.setB(current_value);
        }

        private void trackBar_B_Scroll(object sender, EventArgs e)
        {
            current_value = Convert.ToInt16((sender as TrackBar).Value);

            model.setB(current_value);
        }
        #endregion

        private void UploadValues(object sender, EventArgs e)
        {
            textBox_A.Text = Convert.ToString(model.getA());
            numericUpDown_A.Value = model.getA();
            trackBar_A.Value = model.getA();

            textBox_B.Text = Convert.ToString(model.getB());
            numericUpDown_B.Value = model.getB();
            trackBar_B.Value = model.getB();

            textBox_C.Text = Convert.ToString(model.getC());
            numericUpDown_C.Value = model.getC();
            trackBar_C.Value = model.getC();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
       {
            if (e.KeyCode == Keys.Enter)
            {
                model.setA(Convert.ToInt16(textBox_A.Text));

                model.setB(Convert.ToInt16(textBox_B.Text));

                model.setC(Convert.ToInt16(textBox_C.Text));
            }
        }

        private void textBox_A_Leave(object sender, EventArgs e)
        {
            model.observers.Invoke(this, null);
        }

        private void textBox_B_Leave(object sender, EventArgs e)
        {
            model.observers.Invoke(this, null);
        }

        private void textBox_C_Leave(object sender, EventArgs e)
        {
            model.observers.Invoke(this, null);
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
}