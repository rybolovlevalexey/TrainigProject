using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Сапёр_3._0
{

    public partial class Form1 : Form
    {
        public class SupperBtn : Button
        {
            bool bomb = false;
            public bool is_flagged = false;

            public void make_bombed()
            {
                bomb = true;
            }
            public bool is_bomb()
            {
                return bomb;
            }
            public void change_flagged()
            {
                if (is_flagged)
                {
                    is_flagged = false;
                }
                else
                {
                    is_flagged = true;
                }
            }
        }
        // константы необходимые для выполнения программы
        public const int field_size = 10;
        public const int field_cnt_bombs = 10;
        public const int btn_size = 50;
        public int[,] field = new int[field_size, field_size];
        public SupperBtn[,] buttons = new SupperBtn[field_size, field_size];
        public int cnt_btn_opened = 0;
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
                    else
                        buttons[i, j].make_bombed();
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
                    SupperBtn btn = new SupperBtn();
                    btn.Location = new Point(j * btn_size, i * btn_size);
                    btn.Size = new Size(btn_size, btn_size);
                    btn.BackColor = Color.LightSteelBlue;
                    btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular,
                        System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    btn.MouseUp += new MouseEventHandler(BtnPushedMouse);
                    btn.Name = $"{i};{j}";
                    this.Controls.Add(btn);
                    buttons[i, j] = btn;
                }
            }
        }
        
        // общий обработчик нажатия на кнопку
        private void BtnPushedMouse(object sender, MouseEventArgs e)
        {
            SupperBtn pressedBtn = sender as SupperBtn;
            int coord_i = Convert.ToInt32(pressedBtn.Name.Split(";")[0]);
            int coord_j = Convert.ToInt32(pressedBtn.Name.Split(";")[1]);

            if (e.Button == MouseButtons.Left)  // кнопка нажата левой клавишей
            {
                LeftBtnPushed(pressedBtn);
            } else  // кнопка нажата правой клавишей
            {
                RightBtnPushed(pressedBtn);
            }
        }

        private bool CheckWin()
        {
            int green_cnt = 0;
            for (int i = 0; i < field_size; i += 1)
            {
                for (int j = 0; j < field_size; j += 1)
                {
                    if (buttons[i, j].BackColor == Color.Green)
                        green_cnt += 1;
                }
            }
            if (green_cnt + field_cnt_bombs == field_size * field_size)
                return true;
            return false;
        }

        // обработчик нажатия левой кнопки мыши
        private void LeftBtnPushed(SupperBtn pressedBtn)
        {
            int coord_i = Convert.ToInt32(pressedBtn.Name.Split(";")[0]);
            int coord_j = Convert.ToInt32(pressedBtn.Name.Split(";")[1]);
            if (isFirstMove)
            {
                MakeBombs(coord_i, coord_j);
                isFirstMove = false;
            }
            if (!buttons[coord_i, coord_j].is_flagged) { 

                if (buttons[coord_i, coord_j].is_bomb())
                {
                    for (int i = 0; i < field_size; i += 1)
                    {
                        for (int j = 0; j < field_size; j += 1)
                        {
                            buttons[i, j].Text = Convert.ToString(field[i, j]);
                            buttons[i, j].BackColor = Color.Red;
                        }
                    }
                    MessageBox.Show("Поражение");
                }
                else
                {
                    buttons[coord_i, coord_j].BackColor = Color.Green;
                    buttons[coord_i, coord_j].Enabled = false;
                    buttons[coord_i, coord_j].Text = Convert.ToString(field[coord_i, coord_j]);
                    if (field[coord_i, coord_j] == 0)
                    {
                        OpenAllZeros(coord_i, coord_j);
                    }
                }

                if (CheckWin())
                {
                    for (int i = 0; i < field_size; i += 1)
                    {
                        for (int j = 0; j < field_size; j += 1)
                        {
                            buttons[i, j].Text = Convert.ToString(field[i, j]);
                        }
                    }
                    MessageBox.Show("Победа");
                }
            }
        }
        
        private void OpenAllZeros(int x, int y)  // рекурсивное открытие рядом стоящих, пустых ячеек
        {
            for (int k = x - 1; k < x + 2; k += 1)
            {
                for (int m = y - 1; m < y + 2; m += 1)
                {
                    if (k < 0 || m < 0 || k >= field_size || m >= field_size)
                        continue;
                    //MessageBox.Show($"{k} {m}");
                    if (k == x && y == m)
                        continue;
                    if (!buttons[k, m].Enabled)
                        continue;
                    //if (buttons[k, m].Text.Length == 0)
                    //    continue;
                    if (field[k, m] == 0)
                    {
                        buttons[k, m].BackColor = Color.Green;
                        buttons[k, m].Text = Convert.ToString(field[k, m]);
                        buttons[k, m].Enabled = false;
                        OpenAllZeros(k, m);
                    }
                    else if (field[k, m] > 0)
                    {
                        buttons[k, m].BackColor = Color.Green;
                        buttons[k, m].Text = Convert.ToString(field[k, m]);
                        buttons[k, m].Enabled = false;
                        break;
                    }

                }
            }
        }

        // обработчик нажатия правой кнопки мыши
        private void RightBtnPushed(SupperBtn pressedBtn)
        {
            int coord_i = Convert.ToInt32(pressedBtn.Name.Split(";")[0]);
            int coord_j = Convert.ToInt32(pressedBtn.Name.Split(";")[1]);
            if (pressedBtn.Text.Length == 0)
            {
                buttons[coord_i, coord_j].change_flagged();
            }
            if (pressedBtn.is_flagged)
            {
                buttons[coord_i, coord_j].BackColor = Color.Orange;
            } else
            {
                buttons[coord_i, coord_j].BackColor = Color.LightSteelBlue;
            }
        }
    }
}
