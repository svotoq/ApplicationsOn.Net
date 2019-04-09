using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrigonometricCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CurrentState = state.nonstate;
        }
        #region variables
        string buff;
        state CurrentState;
        string memory = "";
        int number = 0;
        enum state
        {
            substraction,
            addiction,
            multiplication,
            divide,
            remained,
            nonstate
        }
        #endregion
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        #region number
        private void button1_Click(object sender, EventArgs e)
        {
            number = 1;
            textBox1.Text += number;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            number = 2;
            textBox1.Text += number;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            number = 3;
            textBox1.Text += number;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            number = 4;
            textBox1.Text += number;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            number = 5;
            textBox1.Text += number;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            number = 6;
            textBox1.Text += number;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            number = 7;
            textBox1.Text += number;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            number = 8;
            textBox1.Text += number;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            number = 9;
            textBox1.Text += number;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            number = 0;
            textBox1.Text += number;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += ',';
        }
        #endregion
        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = (double.Parse(textBox1.Text) * (-1)).ToString();
            }
            catch (Exception) { }
        }
        private void button13_Click(object sender, EventArgs e)
        {
            if (CurrentState == state.nonstate)
            {
                CurrentState = state.divide;
                buff = textBox1.Text;
                textBox1.Text = "";
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (CurrentState == state.nonstate)
            {
                CurrentState = state.substraction;
                buff = textBox1.Text;
                textBox1.Text = "";
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (CurrentState == state.nonstate)
            {
                CurrentState = state.multiplication;
                buff = textBox1.Text;
                textBox1.Text = "";
                textBox1.Focus();//focus on textbox1 and clear it
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if(CurrentState == state.nonstate)
            {
                CurrentState = state.addiction;
                buff = textBox1.Text;
                textBox1.Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (CurrentState == state.nonstate)
            {
                CurrentState = state.remained;
                buff = textBox1.Text;
                textBox1.Text = "";
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            textBox1.Text += memory;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text.Remove(textBox1.Text.Last());
            }
            catch (Exception) { }
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentState == state.divide)
                {
                    CurrentState = state.nonstate;
                    double buff2 = double.Parse(textBox1.Text);
                    textBox1.Text = (double.Parse(buff) / buff2).ToString();
                }
                if (CurrentState == state.multiplication)
                {
                    CurrentState = state.nonstate;
                    double buff2 = double.Parse(textBox1.Text);
                    textBox1.Text = (double.Parse(buff) * buff2).ToString();
                }
                if (CurrentState == state.substraction)
                {
                    CurrentState = state.nonstate;
                    double buff2 = double.Parse(textBox1.Text);
                    textBox1.Text = (double.Parse(buff) - buff2).ToString();
                }
                if (CurrentState == state.addiction)
                {
                    CurrentState = state.nonstate;
                    double buff2 = double.Parse(textBox1.Text);
                    textBox1.Text = (double.Parse(buff) + buff2).ToString();
                }
                if (CurrentState == state.remained)
                {
                    CurrentState = state.nonstate;
                    double buff2 = double.Parse(textBox1.Text);
                    textBox1.Text = (double.Parse(buff) % buff2).ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Некоректные данные");
            }
        }

        private void Button19_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void Button20_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            CurrentState = state.nonstate;
            buff = "";
        }

        private void Button23_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length > 0)
                {
                    button22.Enabled = true;
                    memory = textBox1.Text;
                }
                else
                {
                    MessageBox.Show("Попытайтесь ввести корректные для\nданной операции данные и повторите", "Калькулятор", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception)
            {
            }
        }

        private void Button24_Click(object sender, EventArgs e)
        {
            memory = "";
        }
    }
}
