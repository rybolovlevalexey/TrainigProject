using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Монополия___имитация_консоли
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Button? btn = sender as Button;
            if (btn.Text == "Начать игру")
            {
                btn.Text = "Следующий ход";
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox1.Text = "2000";
                textBox2.Text = "2000";
            } else
            {

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        } 
        private void label3_Click(object sender, EventArgs e)
        {

        }  
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }  // деньги второго
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }  // деньги первого
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
