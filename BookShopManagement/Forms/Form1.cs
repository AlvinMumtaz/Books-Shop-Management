using BookShopManagement.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text =="admin" && textBox2.Text =="admin")
            using (Form_Dashboard fd = new Form_Dashboard())
            {
                fd.ShowDialog();
            }
            else
            {
                MessageBox.Show("Username atau Password Salah Bro");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
