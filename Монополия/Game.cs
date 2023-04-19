using System;
using System.Collections.Generic;
using System.Text;

namespace Монополия___имитация_консоли
{
    class Game
    {
        public Game()
        {
            Field main_field = new Field();
            Dictionary<int, Player> players = new Dictionary<int, Player>();
            players[1] = new Player();
            players[2] = new Player();
        }

        public List<string> make_lexicon(int bot_number)
        {
            List<string> lexicon = new List<string>();
            switch (bot_number)  // наполнение лексикона
            {
                case 1:
                    lexicon.Add("первый");
                    lexicon.Add("первого");
                    lexicon.Add("первому");
                    break;
                case 2:
                    lexicon.Add("второй");
                    lexicon.Add("второго");
                    lexicon.Add("второму");
                    break;
                default:
                    lexicon.Add("lexicon error");
                    lexicon.Add("lexicon error");
                    lexicon.Add("lexicon error");
                    break;
            }
            return lexicon;
        }
        public void game_iteration()
        {

        }
    }
}
