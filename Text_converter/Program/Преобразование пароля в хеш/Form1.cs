using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Преобразование_пароля_в_хеш
{
    public partial class Преобразование : Form
    {
        static public string Hash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            string HASH = Convert.ToBase64String(hash);
            button2_Click(ref HASH);
            return HASH;
        }
        public Преобразование()
        {
            InitializeComponent();
        }

        void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = Hash(textBox1.Text);
        }

        void label1_Click(object sender, EventArgs e)
        {

        }

        void label2_Click(object sender, EventArgs e)
        {

        }

        static void button2_Click(ref string HASH)
        {
            Clipboard.SetText(HASH);
        }

        void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
