using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

class SupperBtn : Button
{
    bool is_bomb = false;
    bool is_flagged = false;
}

namespace Сапёр_3._0
{
    public partial class Form1 : Form
    {
        // константы необходимые для выполнения программы
        public const int field_size = 10;
        public const int field_cnt_bombs = 10;
        public const int btn_size = 50;
        public int[,] field = new int[field_size, field_size];
        public Button[,] buttons = new Button[field_size, field_size];
        public List<String> sp_moves = new List<String>();
        bool isFirstMove = true;

        // инициализация
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        // установка размеров поля и генерация бомб
        private void Init()
        {
            isFirstMove = true;
            this.Width = field_size * btn_size + 20;
            this.Height = (field_size + 1) * btn_size - 5;
            InitField();
            InitButtons();
        }

        // генерация бомб
        private void MakeBombs(int coord_i, int coord_j)
        {
            Random rnd = new Random();
            for (int k = 0; k < field_cnt_bombs; k += 1)
            {
                int bombI = rnd.Next(0, field_size - 1);
                int bombJ = rnd.Next(0, field_size - 1);
                while (field[bombI, bombJ] == -1 || (bombI == coord_i && bombJ == coord_j))
                {
                    bombI = rnd.Next(0, field_size - 1);
                    bombJ = rnd.Next(0, field_size - 1);
                }
                field[bombI, bombJ] = -1;
            }
            
            for (int i = 0; i < field_size; i += 1)
            {
                for (int j = 0; j < field_size; j += 1)
                {
                    int bombs_around = 0;
                    for (int di = -1; di < 2; di += 1)
                    {
                        for (int dj = -1; dj < 2; dj += 1)
                        {
                            if ((di == dj && di == 0) || i + di < 0 || j + dj < 0 || i + di >= field_size || j + dj >= field_size || field[i, j] == -1)
                            {
                                continue;
                            }
                            if (field[i + di, j + dj] == -1)
                            {
                                bombs_around += 1;
                            }
                        }
                    }
                    if (field[i, j] != -1)
                        field[i, j] = bombs_around;
                }
            }
        }

        // создание поля
        private void InitField() {
            for (int i = 0; i < field_size; i += 1)
            {
                for (int j = 0; j < field_size; j += 1)
                {
                    field[i, j] = 0;
                }
            }
        }

        // создание кнопок
        private void InitButtons()
        {
            for (int i = 0; i < field_size; i += 1)
            {
                for (int j = 0; j < field_size; j += 1)
                {
                    Button btn = new Button();
                    btn.Location = new Point(j * btn_size, i * btn_size);
                    btn.Size = new Size(btn_size, btn_size);
                    btn.MouseUp += new MouseEventHandler(BtnPushedMouse);
                    btn.Name = $"{i};{j}";
                    this.Controls.Add(btn);
                    buttons[i, j] = btn;
                }
            }
        }
        
        
        private void BtnPushedMouse(object sender, MouseEventArgs e)
        {
            Button pressedBtn = sender as Button;
            int coord_i = Convert.ToInt32(pressedBtn.Name.Split(";")[0]);
            int coord_j = Convert.ToInt32(pressedBtn.Name.Split(";")[1]);

            if (e.Button == MouseButtons.Left)  // кнопка нажата левой клавишей
            {
                buttons[coord_i, coord_j].BackColor = Color.Green;
                LeftBtnPushed(pressedBtn);
            } else  // кнопка нажата правой клавишей
            {
                
                buttons[coord_i, coord_j].BackColor = Color.Red;
            }
        }
        

        // обработчик нажатия левой кнопки мыши
        private void LeftBtnPushed(Button pressedBtn)
        {
            int coord_i = Convert.ToInt32(pressedBtn.Name.Split(";")[0]);
            int coord_j = Convert.ToInt32(pressedBtn.Name.Split(";")[1]);
            if (isFirstMove)
            {
                MakeBombs(coord_i, coord_j);
                isFirstMove = false;
            }
            buttons[coord_i, coord_j].Text = Convert.ToString(field[coord_i, coord_j]);
            for (int i = 0; i < field_size; i += 1)
            {
                for (int j = 0; j < field_size; j += 1)
                {
                    buttons[i, j].Text = Convert.ToString(field[i, j]);
                }
            }
        }

        // обработчик нажатия правой кнопки мыши
        private void RightBtnPushed(Button pressedBtn)
        {
            int coord_i = Convert.ToInt32(pressedBtn.Name.Split(";")[0]);
            int coord_j = Convert.ToInt32(pressedBtn.Name.Split(";")[1]);
        }
    }
}
