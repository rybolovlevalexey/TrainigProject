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
            } else
            {
                int[] result = bot1.move();
                switch(result[0])
                {
                    case -1:  // пропуск хода из-за трёх дублей подряд
                        richTextBox1.Text = $"У первого игрока три раза выпали одинаковые числа на кубиках\n" +
                            richTextBox1.Text;
                        break;
                    case -2:  // пропускает ход по какой-то причине
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
                                "Он начал новый круг поэтому получает дополнительно 100 единиц валюты\n" +
                                richTextBox1.Text;
                        string place = main_field.give_cell_name(result[1]);
                        if (place.Split().Length > 1)
                            textBox3.Text = place.Split()[0] + "\n" + place.Split()[1];
                        else
                            textBox3.Text = place.Split()[0];
                        if (!main_field.not_for_sale.Contains(place))  // клетка которую можно гипотетически купить
                        {
                            if (!main_field.has_bought.Contains(place))  // клетка ещё не куплена
                            {
                                if (Convert.ToInt32(bot1.get_money()) < result[1] * 10)
                                {
                                    richTextBox1.Text = $"У первого игрока недостаточно денег на покупку клетки {place}\n" +
                                            richTextBox1.Text;
                                } else
                                {
                                    main_field.has_bought.Add(place);
                                    bot1.buy_new_cell(place, result[1] * 10);
                                    listBox1.Items.Add(place);
                                    richTextBox1.Text = $"Первый игрок покупает клетку {place}\n" +
                                            richTextBox1.Text;
                                }
                                
                            } else  // клетка уже куплена
                            {
                                if (bot2.all_cells.Contains(place))  //  клетка принадлежит противнику
                                {
                                    richTextBox1.Text = $"Первый игрок пришёл на клетку второго и заплатил штраф\n" +
                                        richTextBox1.Text;
                                    bot1.give_money();
                                    bot2.plus_money();
                                } else  // моя клетка - ничего не происходит
                                {
                                    richTextBox1.Text = $"Первый игрок пришёл на клетку {place}. Это его клетка\n" +
                                        richTextBox1.Text;
                                }
                                
                            }
                            
                        } else  // сервисная клетка (шанс, джекпот и т.д.)
                        {
                            if (main_field.take_away_money.Contains(place))  // клетка, на которой забирает весь банк
                            {
                                richTextBox1.Text = $"Первый игрок пришёл на клетку {place}. Можно забирать деньги!\n" +
                                        richTextBox1.Text;
                                bot1.change_money(main_field.monopoly_bank);
                                main_field.monopoly_bank = 0;
                            } else
                            {
                                if (main_field.pay_money.Contains(place))  // клетка, на которой надо заплатить в банк
                                {
                                    richTextBox1.Text = $"Первый игрок пришёл на клетку {place}. Заплатите в кассу!\n" +
                                        richTextBox1.Text;
                                    bot1.give_money();
                                    main_field.monopoly_bank += 50;
                                } else
                                {
                                    if (main_field.take_away_money.Contains(place))
                                    {
                                        richTextBox1.Text = $"Первый игрок пришёл на клетку {place}. И забирает все деньги из кассы!\n" +
                                            richTextBox1.Text;
                                        bot1.change_money(main_field.monopoly_bank);
                                        main_field.monopoly_bank = 0;
                                    }
                                    if (place == "Старт")  // клетка старт - никаких действий с деньгами не происходит
                                    {

                                    } else  // шанс, перемещение
                                    {
                                        string card_result;
                                        if (place == "шанс") // шанс
                                        {
                                            card_result = main_field.take_chanse_card();
                                            richTextBox1.Text = $"Первому игроку выпала карточка - {card_result}\n" +
                                                    richTextBox1.Text;
                                            if (card_result.Contains("Увеличить"))  // шанс - увеличение капитала
                                            {
                                                switch (card_result.Split()[3])
                                                {
                                                    case "10%":
                                                        bot1.change_money(Convert.ToInt32(bot1.get_money()) / 10);
                                                        break;
                                                    case "30%":
                                                        bot1.change_money(Convert.ToInt32(bot1.get_money()) / 10 * 3);
                                                        break;
                                                    case "50%":
                                                        bot1.change_money(Convert.ToInt32(bot1.get_money()) / 2);
                                                        break;
                                                }
                                            } else
                                            {
                                                if (card_result.Contains("Уменьшить"))  // шанс - уменьшение капитала
                                                {
                                                    switch (card_result.Split()[3])
                                                    {
                                                        case "10%":
                                                            bot1.change_money(Convert.ToInt32(bot1.get_money()) / 10 * (-1));
                                                            break;
                                                        case "30%":
                                                            bot1.change_money(Convert.ToInt32(bot1.get_money()) / 10 * 3 * (-1));
                                                            break;
                                                        case "50%":
                                                            bot1.change_money(Convert.ToInt32(bot1.get_money()) / 2 * (-1));
                                                            break;
                                                    }
                                                } else  // вы выиграли пари
                                                {
                                                    bot1.plus_money();
                                                    bot2.give_money();
                                                }
                                            }
                                        } else // перемещение
                                        {
                                            card_result = main_field.take_peremesh_card();
                                            richTextBox1.Text = $"Первому игроку выпала карточка - {card_result}\n" +
                                                    richTextBox1.Text;
                                            if (card_result.Contains("Старт"))
                                            {
                                                bot1.move(true);
                                            } else
                                            {
                                                string place1 = main_field.give_cell_name(bot1.move(Convert.ToInt32(card_result.Split()[1]))[1]);
                                                richTextBox1.Text = $"После карточки перемещения первый игрок попал на клетку {place1}\n" +
                                                    richTextBox1.Text;
                                            }
                                        }
                                        
                                    }
                                }
                            }
                            
                        }
                        textBox1.Text = bot1.get_money();
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
