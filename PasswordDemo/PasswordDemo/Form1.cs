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

namespace PasswordDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                ofd.Title = "请选择要加密的TXT文件";
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                //ofd.RestoreDirectory = true;
                ofd.DereferenceLinks = true;
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.Text = File.ReadAllText(ofd.FileName, Encoding.UTF8);
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = Passwords.Password.Encrypt(richTextBox1.Text, textBox1.Text);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = Passwords.Password.Decrypt(richTextBox2.Text, textBox1.Text);
        }
    }
}
