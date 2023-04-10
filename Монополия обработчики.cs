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
        Field main_field = new Field();
        Player bot1 = new Player();
        Player bot2 = new Player();
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
                //Field main_field = new Field();
            } else
            {
                int[] result = bot1.move();
                switch(result[0])
                {
                    case -1:
                        richTextBox1.Text = $"У первого игрока три раза выпали одинаковые числа на кубиках\n" +
                            richTextBox1.Text;
                        break;
                    case -2:
                        richTextBox1.Text = $"Первый игрок должен пропустить этот ход\n" +
                            richTextBox1.Text;
                        bot1.flag_can_move = true;
                        break;
                    default:
                        if (result[2] == 0)
                            richTextBox1.Text = $"Первый игрок бросает кубики и у него выпадает {result[0]}\n" +
                                richTextBox1.Text;
                        else
                            richTextBox1.Text = $"Первый игрок бросает кубики и у него выпадает {result[0]}\n" + 
                                "Он начал новый круг поэтому получает дополнительно 100 единиц валюты" +
                                richTextBox1.Text;
                        string place = main_field.give_cell_name(result[1]);
                        if (!main_field.not_for_sale.Contains(place))
                        {
                            if (!main_field.has_bought.Contains(place))
                            {
                                main_field.has_bought.Add(place);
                                bot1.buy_new_cell(place, result[1] * 10);
                            } else
                            {
                                bot1.give_money();
                                bot2.plus_money();
                            }
                            
                        }
                        break;
                }
                

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

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
