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
        public List<string> all_cells = new List<string>();  // все купленные участки пользователя
        int position = 0;
        public bool flag_can_move = true;
        private Dictionary<string[], string> cells_otrasl = new Dictionary<string[], string>();

        public Player()
        {
            config();
        }
        
        // проверка на возможность покупки филиалов и предприятий
        public void buy_filial()
        {

        }
        private void config()
        {
            string[] otrasl = new string[3];
            otrasl[0] = "кинотеатр"; otrasl[1] = "караоке"; otrasl[2] = "ночной клуб";
            cells_otrasl[otrasl] = "Индустрия развлечений";
            otrasl[0] = "швейная фабрика"; otrasl[1] = "хлебопекарня"; otrasl[2] = "пивоваренный завод";
            cells_otrasl[otrasl] = "Пищевая промышленность";
            otrasl[0] = "интернет-провайдер"; otrasl[1] = "пейджинговая компания"; otrasl[2] = "оператор сотовой связи";
            cells_otrasl[otrasl] = "Связь и коммуникации";
            otrasl[0] = "обувная фабрика"; otrasl[1] = "мебельное производство"; otrasl[2] = "швейное объединение";
            cells_otrasl[otrasl] = "Лёгкая промышленность";
            otrasl[0] = "издательский дом"; otrasl[1] = "радиостанция"; otrasl[2] = "телевизионная компания";
            cells_otrasl[otrasl] = "Средства массовой информации";
            otrasl[0] = "железнодорожное предприятие"; otrasl[1] = "морское пароходство"; otrasl[2] = "авиакомпания";
            cells_otrasl[otrasl] = "Транспортная отрасль";
            otrasl[0] = "автомобильный завод"; otrasl[1] = "судостроительная верфь"; otrasl[2] = "металлургический комбинат";
            cells_otrasl[otrasl] = "Тяжёлая промышленность";
            otrasl[0] = "угольный синдикат"; otrasl[1] = "газодобывающий холдинг"; otrasl[2] = "угольный холдинг";
            cells_otrasl[otrasl] = "Добывающая промышленность";
        }
        public string get_money()
        {
            return Convert.ToString(money);
        }
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
        // в методе move: number = -3 (карточка перемещение), -2 (пропускает ход по какой-то причине), -1 (пропуск хода из-за дубля)
        // остальные числа - обычный ход после броска кубика
        // стандратный move
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
        // move после перемещения
        public int[] move(int number)
        {
            int new_lap_flag = 0;
            position += number;
            if (position > 39)
            {
                position -= 39;
                money += 100;
                new_lap_flag = 1;
            }
            if (position == 30)
            {
                flag_can_move = false;
            }
            number = -3;
            return new int[] { number, position, new_lap_flag };
        }
        // на клетку старт - получите деньги за круг
        public int[] move(bool num)
        {
            position = 0;
            money += 100;
            int new_lap_flag = 1;
            int number = -3;
            return new int[] { number, position, new_lap_flag };
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
        private List<string> all_chanses = new List<string>();
        private List<string> all_peremesh = new List<string>();

        public Field()
        {
            config();

        }
        public string give_cell_name(int number)
        {
            return cells_info[number];
        }
        public string take_chanse_card()
        {
            Random rnd = new Random();
            return all_chanses[rnd.Next(0, all_chanses.Count - 1)];
        }
        public string take_peremesh_card()
        {
            Random rnd = new Random();
            return all_peremesh[rnd.Next(0, all_peremesh.Count - 1)];
        }
        private void config()
        {
            all_peremesh.Add("На клетку Старт");
            all_peremesh.Add("На 5 клеток вперёд");
            all_peremesh.Add("На 10 клеток вперёд");
            all_peremesh.Add("На 15 клеток вперёд");
            all_peremesh.Add("На 20 клеток вперёд");
            all_peremesh.Add("На клетку Старт");

            all_chanses.Add("Увеличить капитал на 10%");
            all_chanses.Add("Увеличить капитал на 30%");
            all_chanses.Add("Увеличить капитал на 50%");
            all_chanses.Add("Уменьшить капитал на 10%");
            all_chanses.Add("Уменьшить капитал на 30%");
            all_chanses.Add("Уменьшить капитал на 50%");
            all_chanses.Add("Поздравляем, вы выиграли пари у вашего соперника");

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
