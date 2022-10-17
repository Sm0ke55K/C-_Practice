using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Программа
{
    public partial class Form1 : Form
    {
        List<ClassChars> List = new List<ClassChars>();
        public Form1()
        {
            InitializeComponent();
            textBox3.ScrollBars = ScrollBars.Both;
        }
        void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text.Replace("   ", " ").Replace("  ", " ");
            string raw_text = textBox1.Text;
            if (checkBox1.Checked == true) raw_text = raw_text.Replace("\n", "").Replace(" ", "").Replace("\t", "");

            if (checkBox2.Checked == true)
            {
                var charsToRemove = new string[] { "@", ",", ".", ";", "'", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "_", "-", "+", "=", "   ", "?" };
                foreach (var c in charsToRemove)
                {
                    raw_text = raw_text.Replace(c, "");
                }
            }

            if (checkBox3.Checked == true) raw_text = raw_text.ToLower();

            textBox2.Text = raw_text;
            Measurements();
            Print_Data();
        }
        void Measurements()
        {
            string raw_text = textBox2.Text.Trim();
            int N = textBox2.TextLength;
            label1.Text = "";

            Dictionary<char, int> dictionarys = raw_text.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

            float sum = dictionarys.Sum(x => x.Value);
            List.Clear();
            foreach (KeyValuePair<char, int> keyValuePair in dictionarys.OrderByDescending(x => x.Value))
            {
                List.Add(new ClassChars(keyValuePair.Key, keyValuePair.Value, keyValuePair.Value / sum, ""));
            }
        }
        void Print_Data()
        {
            textBox3.Text = "";
            foreach (ClassChars i in List)
            {
                textBox3.Text += $"{i.Letter}  {i.Count}  {i.Probability}  {i.CodeSF}\r\n";
            }
        }
        void del_mass(int[] mass)
        {
            for (var i = 0; i < List.Count; i++)
            {
                if (List[i].Probability < 0.5 || List[List.Count() - 1].Probability > List[i].Probability)
                {

                }
            }
        }
    }
}

