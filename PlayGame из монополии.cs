switch (result[0])
{
  case -1:  // пропуск хода из-за трёх дублей подряд
      richTextBox.Text = $"У первого игрока три раза выпали одинаковые числа на кубиках\n" +
          richTextBox.Text;
      break;
  case -2:  // пропускает ход по какой-то причине
      richTextBox.Text = $"Первый игрок должен пропустить этот ход\n" +
          richTextBox.Text;
      bot1.flag_can_move = true;
      break;
  default:
      if (result[2] == 0)
          richTextBox.Text = $"Первый игрок бросает кубики и у него выпадает {result[0]}\n" +
              richTextBox.Text;
      else
          richTextBox.Text = $"Первый игрок бросает кубики и у него выпадает {result[0]}\n" +
              "Он начал новый круг поэтому получает дополнительно 100 единиц валюты\n" +
              richTextBox.Text;
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
                  richTextBox.Text = $"У первого игрока недостаточно денег на покупку клетки {place}\n" +
                          richTextBox.Text;
              }
              else
              {
                  main_field.has_bought.Add(place);
                  bot1.buy_new_cell(place, result[1] * 10);
                  listBox1.Items.Add(place);
                  richTextBox.Text = $"Первый игрок покупает клетку {place}\n" +
                          richTextBox.Text;
              }

          }
          else  // клетка уже куплена
          {
              if (bot2.all_cells.Contains(place))  //  клетка принадлежит противнику
              {
                  richTextBox.Text = $"Первый игрок пришёл на клетку второго и заплатил штраф\n" +
                      richTextBox.Text;
                  bot1.give_money();
                  bot2.plus_money();
              }
              else  // моя клетка - ничего не происходит
              {
                  richTextBox.Text = $"Первый игрок пришёл на клетку {place}. Это его клетка\n" +
                      richTextBox.Text;
              }

          }

      }
      else  // сервисная клетка (шанс, джекпот и т.д.)
      {
          if (main_field.take_away_money.Contains(place))  // клетка, на которой забирает весь банк
          {
              richTextBox.Text = $"Первый игрок пришёл на клетку {place}. Можно забирать деньги!\n" +
                      richTextBox.Text;
              bot1.change_money(main_field.monopoly_bank);
              main_field.monopoly_bank = 0;
          }
          else
          {
              if (main_field.pay_money.Contains(place))  // клетка, на которой надо заплатить в банк
              {
                  richTextBox.Text = $"Первый игрок пришёл на клетку {place}. Заплатите в кассу!\n" +
                      richTextBox.Text;
                  bot1.give_money();
                  main_field.monopoly_bank += 50;
              }
              else
              {
                  if (main_field.take_away_money.Contains(place))
                  {
                      richTextBox.Text = $"Первый игрок пришёл на клетку {place}. И забирает все деньги из кассы!\n" +
                          richTextBox.Text;
                      bot1.change_money(main_field.monopoly_bank);
                      main_field.monopoly_bank = 0;
                  }
                  if (place == "Старт")  // клетка старт - никаких действий с деньгами не происходит
                  {

                  }
                  else  // шанс, перемещение
                  {
                      string card_result;
                      if (place == "шанс") // шанс
                      {
                          card_result = main_field.take_chanse_card();
                          richTextBox.Text = $"Первому игроку выпала карточка - {card_result}\n" +
                                  richTextBox.Text;
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
                          }
                          else
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
                              }
                              else  // вы выиграли пари
                              {
                                  bot1.plus_money();
                                  bot2.give_money();
                              }
                          }
                      }
                      else // перемещение
                      {
                          card_result = main_field.take_peremesh_card();
                          richTextBox.Text = $"Первому игроку выпала карточка - {card_result}\n" +
                                  richTextBox.Text;
                          if (card_result.Contains("Старт"))
                          {
                              bot1.move(true);
                          }
                          else
                          {
                              string place1 = main_field.give_cell_name(bot1.move(Convert.ToInt32(card_result.Split()[1]))[1]);
                              richTextBox.Text = $"После карточки перемещения первый игрок попал на клетку {place1}\n" +
                                  richTextBox.Text;
                          }
                      }

                  }
              }
          }

      }
      textBox1.Text = bot1.get_money();
      break;
}
