using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Самостоятельная_работа_WindowsForm
{
    public partial class Form1 : Form
    {
        public bool flag = true;
        Elephant el1 = new Elephant() { Name = "Lloyd", EarSize = 40 };
        Elephant el2 = new Elephant() { Name = "Lucinda", EarSize = 33 };
        public Form1()
        {
            InitializeComponent();
        }
        class Elephant
        {
            public string Name { get; set; }
            public int EarSize { get; set; }
            public void WhoAmI()
            {
                MessageBox.Show($"My ears are {EarSize} inches tall.", $"{Name} says...");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                el1.WhoAmI();
            } else
            {
                el2.WhoAmI();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                el2.WhoAmI();
            }
            else
            {
                el1.WhoAmI();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                flag = false;
            } else
            {
                flag = true;
            }
        }
    }
}
