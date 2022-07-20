using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Интерактивный_список
{
    public partial class List : Form
    {
        public List()
        {
            InitializeComponent();
        }

        List<string> social = new List<string>();

        void Print_list() // Вывод списка
        {
            textBox5.Text = "";
            for (int i = 0; i < social.Count; i++)
            {
                textBox5.Text += $"#{i + 1}     {social[i].ToString()}{Environment.NewLine}";
            }
        }


        void button2_Click(object sender, EventArgs e) // Добавить в начало
        {
            if (textBox1.Text != "")
            {
                social.Add(textBox1.Text);
                textBox1.Text = "";
            }
            Print_list();
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e) // Entrer "Добавить в начало"
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(null, null);
                e.SuppressKeyPress = true;
            }
        }
        private void button6_Click(object sender, EventArgs e) // Вставить под номером
        {
            if (textBox2.Text != "")
            {
                int numb = int.Parse(textBox2.Text) - 1;
                if (numb >= 0 && numb <= social.Count) 
                { 
                    social.Insert(numb, textBox3.Text);
                    textBox2.Text = "";
                    textBox3.Text = "";
                    Print_list();
                }
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e) // Entrer "Вставить под номером"
        {
            if (e.KeyCode == Keys.Enter)
            {
                button6_Click(null, null);
                e.SuppressKeyPress = true;
            }
        }

        void button1_Click(object sender, EventArgs e) // Сортировка
        {
            social.Sort();
            Print_list();
        }

        void button3_Click(object sender, EventArgs e) // Сохранение
        {
            using (SaveFileDialog saveFile = new SaveFileDialog() { Filter = "Text File|*.txt", FilterIndex = 2, RestoreDirectory = true })
            
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter wr = new StreamWriter(saveFile.FileName))
                {
                     wr.WriteLine(string.Join("\n", social));
                }
            }
        }

        void button4_Click(object sender, EventArgs e) // Очистить список
        {
            social.Clear();
            textBox5.Text = "";
        }

        void button5_Click(object sender, EventArgs e) // Удалить под номером
        {
            
            if (textBox4.Text != "")
            {   
                int nom = int.Parse(textBox4.Text) - 1;
                if (nom >= 0 && nom < social.Count)
                {
                    social.RemoveAt(nom);
                    textBox4.Text = "";
                    Print_list();
                }
            }
        }


        private void List_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textBox5.Text != "") 
            { 
                DialogResult saveYesNo = MessageBox.Show("Список имеет несохранённые изменения. Сохранить?",
                    "Несохранённые изменения", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (saveYesNo == DialogResult.Yes)
                {
                    button3_Click(null, null);
                }
                if (saveYesNo == DialogResult.No)
                {        
                }
                if (saveYesNo == DialogResult.Cancel)
                {
                   e.Cancel = true;
                }

            }
        }

    }
}
