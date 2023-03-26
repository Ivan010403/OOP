using System;
using System.Reflection;

namespace lab_4_2
{
    public partial class Form1 : Form
    {
        private int current_value;
        private Model model;
        private bool status_enter = false;


        public Form1()
        {
            InitializeComponent();
            model = new Model();
            UploadValues();
        }


        #region methods for A

        private void numericUpDown_A_ValueChanged(object sender, EventArgs e)
        {
            current_value = Convert.ToInt16((sender as NumericUpDown).Value);
            model.setA(current_value);

            UploadValues();
        }

        private void trackBar_A_Scroll(object sender, EventArgs e)
        {
            current_value = Convert.ToInt16((sender as TrackBar).Value);
            model.setA(current_value);

            UploadValues();
        }
        #endregion


        #region methods for C

        private void numericUpDown_C_ValueChanged(object sender, EventArgs e)
        {
            current_value = Convert.ToInt16((sender as NumericUpDown).Value);
            model.setC(current_value);

            UploadValues();
        }

        private void trackBar_C_Scroll(object sender, EventArgs e)
        {
            current_value = Convert.ToInt16((sender as TrackBar).Value);
            model.setC(current_value);

            UploadValues();
        }
        #endregion


        #region methods for B

        private void numericUpDown_B_ValueChanged(object sender, EventArgs e)
        {
            current_value = Convert.ToInt16((sender as NumericUpDown).Value);

            if (!model.setB(current_value))
            {
                UploadValues();
            }
        }

        private void trackBar_B_Scroll(object sender, EventArgs e)
        {
            current_value = Convert.ToInt16((sender as TrackBar).Value);

            if (!model.setB(current_value))
            {
                UploadValues();
            }
        }
        #endregion

        private void UploadValues()
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
                if (model.setA(Convert.ToInt16(textBox_A.Text))) UploadValues();

                if (model.setC(Convert.ToInt16(textBox_C.Text))) UploadValues();

                if (model.setB(Convert.ToInt16(textBox_B.Text))) UploadValues();
            }
        }
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
        public bool setA(int A)
        {
            if (this.A == A)
            {
                checkConditionsForA();
                return false;
            }
            else
            {
                this.A = A;
                checkConditionsForA();
                return true;
            }
        }

        public bool setB(int B)
        {
            if (checkConditionsForB(B) == 1)
            {
                this.B = B;
                return false;
            }
            else
            {
                if (this.B != B)
                {
                    MessageBox.Show("B is incorrect");
                }
                else this.B = A;
                return true;
            }
        }

        public bool setC(int C)
        {
            if (this.C == C)
            {
                checkConditionsForC();
                return false;
            }
            else
            {
                this.C = C;
                checkConditionsForC();
                return true;
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
        
        
        private void checkConditionsForA()
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

        private void checkConditionsForC()
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

        private int checkConditionsForB(int B)
        {
            if ((B < 0) || (B > 100) || (A > B) || (B > C)) return 0;
            else return 1;
        }

    }
}