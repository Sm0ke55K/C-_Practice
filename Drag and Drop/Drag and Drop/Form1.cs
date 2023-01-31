using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drag_and_Drop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void panel1_DragEnter(object sender, DragEventArgs e)
        {
            //Данные.Получить представление от этих данных (в виде дропнутого файла)
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                label1.Text = "Отпустите мышь";
                e.Effect = DragDropEffects.Copy;
            }
        }

        void panel1_DragLeave(object sender, EventArgs e)
        {
            label1.Text = "Перетащите файл";
        }

        void panel1_DragDrop(object sender, DragEventArgs e)
        {
            label1.Text = "Перетащите файл";

            //Создание списка
            List<string> paths = new List<string>();
            //Для каждого файла в массиве данные.извлечь данные(Формат данных.дропнутый файл)
            //* e - аргумент который был дропнут
            foreach (string obj in (string[])e.Data.GetData(DataFormats.FileDrop))
                //Если директория существует
                if (Directory.Exists(obj))
                    //Добавить файлы которые есть в этой папке(Откуда получить, все файлы, все подкаталоги)
                    paths.AddRange(Directory.GetFiles(obj, "*.*", SearchOption.AllDirectories));
                else 
                    //Если это объект(1 файл) добавить его
                    paths.Add(obj);
            label2.Text = string.Join("\r\n", paths);
            if (label2.Text != null)
                label3.Text = "Выбранные файлы:";
        }

        void panel1_Click(object sender, EventArgs e)
        {
            //Диологовое окно для выбора файла
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Выберите файл";
            //Начальное окно
            dlg.InitialDirectory = @"C:\Users\Super\Desktop";
            //Вывод файла
            if (dlg.ShowDialog() == DialogResult.OK)
                label2.Text = dlg.FileName;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //Создать перо и его ширину
            Pen pen = new Pen(Color.DarkGray, 2);
            //Паттерн (Длина линий, длина пробелов)
            pen.DashPattern = new float[] {5, 2};
            //Сглаживание (использовать на гладких фигурах)
            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //Рисование фигуры(Draw...(перо, координата x, координата y, ширина, высота))
            e.Graphics.DrawRectangle(pen, 1, 1, panel1.Width - 2, panel1.Height - 2);
        }
    }
}
