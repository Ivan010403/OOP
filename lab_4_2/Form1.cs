using System;
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
        }


        #region methods for A
        private void textBox_A_TextChanged(object sender, EventArgs e)
        {
            current_value = Convert.ToInt16((sender as TextBox).Text);
            model.setA(current_value);

            numericUpDown_A.Value = current_value;
            trackBar_A.Value = current_value;
        }

        private void numericUpDown_A_ValueChanged(object sender, EventArgs e)
        {
            current_value = Convert.ToInt16((sender as NumericUpDown).Value);
            model.setA(current_value);
            textBox_A.Text = Convert.ToString(current_value);
            trackBar_A.Value = current_value;
        }

        private void trackBar_A_Scroll(object sender, EventArgs e)
        {
            current_value = Convert.ToInt16((sender as TrackBar).Value);
            model.setA(current_value);
            textBox_A.Text = Convert.ToString(current_value);
            numericUpDown_A.Value = current_value;
        }
        #endregion

        #region methods for C
        private void textBox_C_TextChanged(object sender, EventArgs e)
        {
            current_value = Convert.ToInt16((sender as TextBox).Text);
            model.setC(current_value);

            numericUpDown_C.Value = current_value;
            trackBar_C.Value = current_value;
        }

        private void numericUpDown_C_ValueChanged(object sender, EventArgs e)
        {
            current_value = Convert.ToInt16((sender as NumericUpDown).Value);
            model.setC(current_value);
            textBox_C.Text = Convert.ToString(current_value);
            trackBar_C.Value = current_value;
        }

        private void trackBar_C_Scroll(object sender, EventArgs e)
        {
            current_value = Convert.ToInt16((sender as TrackBar).Value);
            model.setC(current_value);
            textBox_C.Text = Convert.ToString(current_value);
            numericUpDown_C.Value = current_value;
        }
        #endregion


        #region methods for B
        private void textBox_B_TextChanged(object sender, EventArgs e)
        {
            current_value = Convert.ToInt16((sender as TextBox).Text);
            model.setB(current_value);

            numericUpDown_B.Value = current_value;
            trackBar_B.Value = current_value;
        }

        private void numericUpDown_B_ValueChanged(object sender, EventArgs e)
        {
            current_value = Convert.ToInt16((sender as NumericUpDown).Value);
            model.setB(current_value);
            textBox_B.Text = Convert.ToString(current_value);
            trackBar_B.Value = current_value;
        }

        private void trackBar_B_Scroll(object sender, EventArgs e)
        {
            current_value = Convert.ToInt16((sender as TrackBar).Value);
            model.setB(current_value);
            textBox_B.Text = Convert.ToString(current_value);
            numericUpDown_B.Value = current_value;
        }
        #endregion

    }

    public class Model
    {
        private int A;
        private int B;
        private int C;

        private string[] readAllFile;
        private string pathToFile;
        public Model()
        {
            pathToFile = "C:\\Users\\vanyk\\OneDrive\\Документы\\GitHub\\OOP\\lab_4_2\\data.txt";
            readAllFile = File.ReadAllLines(pathToFile);

            A = Convert.ToInt16(readAllFile[0]);
            B = Convert.ToInt16(readAllFile[1]);
            C = Convert.ToInt16(readAllFile[2]);
        }

        #region Getters and setters
        public void setA(int A)
        {
            this.A = A;
            //return checkConditionsForA();
        }

        public void setB(int B)
        {
            this.B = B;
            //return checkConditionsForB();
        }

        public void setC(int C)
        {
            this.C = C;
            //return checkConditionsForC();
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
    
        //private bool checkConditionsForB()
        //{
        //    if ((B < 0) || (B > 100) || (A > B) || (B > C)) return false;
        //    else return true;
        //}

    }
}