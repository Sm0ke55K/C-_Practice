using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numerical_game
{
    public partial class Form1 : Form
    {
        int answer;
        string[] numbers = {"zero", "one", "two", "three", "four", "five",
                "six", "seven", "eight", "nine", "ten", "eleven", "twelve",
                "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", 
                "eighteen", "nineteen", "twenty", "twenty - one", "twenty - two",
                "twenty - three", "twenty - four", "twenty - five", "twenty - six",
                "twenty - seven", "twenty - eight", "twenty - nine", "thirty",
                "thirty - one", "thirty - two", "thirty - three", "thirty - four",
                "thirty - five", "thirty - six", "thirty - seven", "thirty - eight",
                "thirty - nine", "forty", "forty - one", "forty - two", "forty - three",
                "forty - four", "forty - five", "forty - six", "forty - seven",
                "forty - eight", "forty - nine", "fifty", "fifty - one", "fifty - two",
                "fifty - three", "fifty - four", "fifty - five", "fifty - six",
                "fifty - seven", "fifty - eight", "fifty - nine", "sixty", "sixty - one",
                "sixty - two", "sixty - three", "sixty - four", "sixty - five",
                "sixty - six", "sixty - seven", "sixty - eight", "sixty - nine",
                "seventy", "seventy - one", "seventy - two", "seventy - three",
                "seventy - four", "seventy - five", "seventy - six", "seventy - seven",
                "seventy - eight", "seventy - nine", "eighty", "eighty - one",
                "eighty - two", "eighty - three", "eighty - four", "eighty - five",
                "eighty - six", "eighty - seven", "eighty - eight", "eighty - nine",
                "ninety", "ninety - one", "ninety - two", "ninety - three",
                "ninety - four", "ninety - five", "ninety - six", "ninety - seven",
                "ninety - eight", "ninety - nine", "hundred"};
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            button1_Click(null, null);
            textBox1.Focus();
        }

        void button2_Click(object sender, EventArgs e) // Проверить
        {
            string answer2 = textBox1.Text;
            if (answer2 == numbers[answer])
            {
                label4.ForeColor = Color.Lime;
                label4.Text = "Правильно!";
            }
            else
            {
                label4.ForeColor = Color.Red;
                label4.Text = "Не правильно! :(";
            }
            textBox1.Focus();
        }

        void button1_Click(object sender, EventArgs e) // Новый пример
        {
            label4.Text = "";
            textBox1.Text = "";
            textBox1.Focus();

            Random rnd = new Random();

            if (radioButton1.Checked)
            {
                int value1 = rnd.Next(1, 6);
                label1.Text = numbers[value1];
                int value2 = rnd.Next(1, 6);
                label2.Text = numbers[value2];
                answer = value1 + value2;
            }

            if (radioButton2.Checked)
            {
                int value1 = rnd.Next(1, 11);
                label1.Text = numbers[value1];
                int value2 = rnd.Next(1, 11);
                label2.Text = numbers[value2];
                answer = value1 + value2;
            }

            if (radioButton3.Checked)
            {
                int value1 = rnd.Next(1, 26);
                label1.Text = numbers[value1];
                int value2 = rnd.Next(1, 26);
                label2.Text = numbers[value2];
                answer = value1 + value2;
            }

            if (radioButton4.Checked)
            {
                int value1 = rnd.Next(1, 51);
                label1.Text = numbers[value1];
                int value2 = rnd.Next(1, 51);
                label2.Text = numbers[value2];
                answer = value1 + value2;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                button2.Enabled = true;
            else
            {
                label4.Text = "";
                button2.Enabled = false;
            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter & textBox1.Text != "")
            {
                e.SuppressKeyPress = true;
                button2_Click(null, null);
            }
        }
    }
}