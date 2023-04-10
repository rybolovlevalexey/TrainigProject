using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Монополия___имитация_консоли
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class Player
    {
        Random rnd = new Random();
        private int money = 2000;
        List<string> all_cells = new List<string>();
        int position = 0;
        public bool flag_can_move = true;
        
        public bool change_money(int value)
        {
            money += value;
            if (money <= 0)
                return false;
            return true;
        }
        public void give_money()
        {
            money -= 50;
        }
        public void plus_money()
        {
            money += 50;
        }
        public void buy_new_cell(string name, int value)
        {
            money -= value;
            all_cells.Add(name);
        }
        public int[] move()
        {
            if (flag_can_move)
            {
                int number = 0, cnt = 1;
                int number1 = rnd.Next(1, 6);
                int number2 = rnd.Next(1, 6);
                int new_lap_flag = 0;
                if (number1 != number2)
                {
                    number = number1 + number2;
                }
                else
                {

                    while (number1 == number2)
                    {
                        number += (number1 + number2);
                        cnt += 1;
                        number1 = rnd.Next(1, 6);
                        number2 = rnd.Next(1, 6);
                    }
                }
                if (cnt < 3)
                {
                    position += number;
                    if (position > 39)
                    {
                        position -= 39;
                        money += 100;
                        new_lap_flag = 1;
                    }
                }
                else
                {
                    number = -1;
                    position = 30;
                }

                return new int[] { number, position, new_lap_flag };
            }
            flag_can_move = true;
            return new int[] { -2, 0, 0 };
        }
    }

    public class Field
    {
        // позиция(id), [название, отрасль]
        private Dictionary<int, string> cells_info = new Dictionary<int, string>();
        public List<string> not_for_sale = new List<string>();
        public List<string> has_bought = new List<string>();
        public int monopoly_bank = 0;
        public List<string> take_away_money = new List<string>();
        public List<string> pay_money = new List<string>();

        public Field()
        {
            config();

        }
        public string give_cell_name(int number)
        {
            return cells_info[number];
        }
        public void config()
        {
            pay_money.Add("налоговая инспекция");
            pay_money.Add("чёрный бизнес");
            pay_money.Add("налоговая полиция");

            take_away_money.Add("благотворительный фонд");
            take_away_money.Add("джекпот");
            take_away_money.Add("белый бизнес");

            not_for_sale.Add("Старт");
            not_for_sale.Add("перемещение");
            not_for_sale.Add("шанс");
            not_for_sale.Add("налоговая инспекция");
            not_for_sale.Add("чёрный бизнес");
            not_for_sale.Add("благотворительный фонд");
            not_for_sale.Add("джекпот");
            not_for_sale.Add("белый бизнес");
            not_for_sale.Add("налоговая полиция");

            cells_info[0] = "Старт";
            cells_info[1] = "кинотеатр";
            cells_info[2] = "караоке";
            cells_info[3] = "перемещение";
            cells_info[4] = "ночной клуб";
            cells_info[5] = "благотворительный фонд";
            cells_info[6] = "швейная фабрика";
            cells_info[7] = "хлебопекарня";
            cells_info[8] = "шанс";
            cells_info[9] = "пивоваренный завод";
            cells_info[10] = "налоговая инспекция";
            cells_info[11] = "интернет-провайдер";
            cells_info[12] = "пейджинговая компания";
            cells_info[13] = "перемещение";
            cells_info[14] = "оператор сотовой связи";
            cells_info[15] = "чёрный бизнес";
            cells_info[16] = "обувная фабрика";
            cells_info[17] = "мебельное производство";
            cells_info[18] = "шанс";
            cells_info[19] = "швейное объединение";
            cells_info[20] = "джекпот";
            cells_info[21] = "издательский дом";
            cells_info[22] = "перемещение";
            cells_info[23] = "радиостанция";
            cells_info[24] = "телевизионная компания";
            cells_info[25] = "белый бизнес";
            cells_info[26] = "железнодорожное предприятие";
            cells_info[27] = "шанс";
            cells_info[28] = "морское пароходство";
            cells_info[29] = "авиакомпания";
            cells_info[30] = "налоговая полиция";
            cells_info[31] = "автомобильный завод";
            cells_info[32] = "перемещение";
            cells_info[33] = "судостроительная верфь";
            cells_info[34] = "металлургический комбинат";
            cells_info[35] = "чёрный бизнес";
            cells_info[36] = "угольный синдикат";
            cells_info[37] = "шанс";
            cells_info[38] = "газодобывающий холдинг";
            cells_info[39] = "угольный холдинг";
        }
    }
}
