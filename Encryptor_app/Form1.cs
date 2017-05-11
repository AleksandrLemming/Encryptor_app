using System;
using System.IO;
using System.Windows.Forms;

namespace Encryptor_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Encryptor encryptor = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.encryptor = new Encryptor();
            //Restrict user access 
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            textBox1.Enabled = false;
            label2.Text = "";
        }

        private void Button1_Click(object sender, EventArgs e) //Choose the file button
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "TXT files (*.txt)|*.txt";
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                encryptor.Path = ofd.FileName;
                textBox1.Enabled = true;
            }
        }

        private void Button2_Click(object sender, EventArgs e) //Confirm key button
        {
            encryptor.Key = Convert.ToUInt64((textBox1.Text));
            button2.Text = "Accepted";
            textBox1.Enabled = false;
            button4.Enabled = true;
            button2.Enabled = false;
        }

        private void Button3_Click(object sender, EventArgs e) //Change key button
        {
            textBox1.Enabled = true;
            button2.Enabled = true;
            button2.Text = "Confirm the key";
            button4.Enabled = false;
        }

        private void Button4_Click(object sender, EventArgs e) //Encrypt text button
        {
            FileInfo fi = new FileInfo(encryptor.Path);

            if (!fi.Exists || !(fi.Length > 0))// || encryptor.Key==0)
            {
                MessageBox.Show("File not exists or empty!");
            }
            else
            {
                encryptor.Text_Encryption(); //method for encryption

                MessageBox.Show("All is done!");
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e) //Allows input only numbers
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                label2.Text = "Only numbers!";
            }
            else
            {
                label2.Text = "";
            }
        }
    }
}
