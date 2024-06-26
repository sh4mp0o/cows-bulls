﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Windows;

namespace cows_bulls
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string aim;
        int attemps = 0;
        public void NewGame()
        {
            listBox.Items.Clear();
            listBox.Items.Add("Введите четырехзначное число без повторяющихся цифр.");

            Random rand = new Random();
            int num;
            bool[] used = new bool[10];
            bool isUnique = true;
            do
            {
                isUnique = true;
                // генерировать случайное число
                num = rand.Next(1000, 10000);

                // проверить, что число состоит из четырех цифр
                // и все цифры числа уникальны
                Array.Clear(used, 0, used.Length);
                foreach (char c in num.ToString())
                {
                    int digit = c - '0';
                    if (used[digit])
                    {
                        isUnique = false;
                        break;
                    }
                    used[digit] = true;
                }
            } while (num < 1000 || !isUnique);
            aim = Convert.ToString(num);
        }
        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }

        private void tryButton_Click(object sender, RoutedEventArgs e)
        {
            string attemp = tbox.Text;
            var bulls = 0; var cows = 0;

            if (attemp.Length == 4 && Int32.TryParse(attemp, out var number) && attemp.Distinct().Count() == attemp.Length)
            {
                attemps++;
                if (attemp == aim)
                {
                    CongratsWindow congratsWindow = new CongratsWindow(attemps);
                    congratsWindow.Show();
                    congratsWindow.winLabel2.Content = $"Для победы вам понадобилось {attemps} попыток!";
                    tbox.IsEnabled = false;
                    //player.name = congratsWindow.name;
                    //player.score = attemps;
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (attemp[i] == aim[i]) bulls++;
                        if (attemp[i] != aim[i] && aim.Contains(attemp[i])) cows++;
                    }
                    listBox.Items.Add(attemp + $" - содержит {bulls} быков и {cows} коров.");
                }
            }
            else
            {
                MessageBox.Show("Введите четырехзначное число без повторяющихся цифр!");
            }
            tbox.Text = "";
        }

        private void newGameButton_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
            tbox.IsEnabled = true;
        }

        private void recordsButton_Click(object sender, RoutedEventArgs e)
        {
            RecordWindow recordWindow = new RecordWindow();
            recordWindow.Owner = this;
            //Record record1 = new Record("debil", 10, new DateTime(2023, 5, 1));
            List<Record> records1 = new List<Record>();
            var json = new DataContractJsonSerializer(typeof(List<Record>));
            //records1.Add(record1);
            try
            {
                using (FileStream fs = File.OpenRead("Score.json"))
                {
                    List<Record> records = (List<Record>)json.ReadObject(fs);
                    foreach (Record record in records)
                    {
                        recordWindow.listRecords.Items.Add(record.name + "         " + record.score + "        " + record.date);
                    }
                }
            }
            catch (Exception)
            {
            }
            recordWindow.Show();
        }

        private void rulesButton_Click(object sender, RoutedEventArgs e)
        {
            RulesWindow rulesWindow = new RulesWindow();
            rulesWindow.Owner = this;
            rulesWindow.rulesLabel.Content = "Правила игры\r\nКомпьютер задумывает четыре различные цифры" +
                " из 0,1,2,...9. Игрок делает\r\nходы, чтобы узнать эти цифры и их порядок.\r\n\r\nКаждый ход" +
                " состоит из четырёх цифр.\r\n\r\nВ ответ компьютер" +
                " показывает число отгаданных цифр, стоящих на\r\nсвоих местах (число быков) и число" +
                " отгаданных цифр, стоящих не на\r\nсвоих местах (число коров).\r\n\r\nПример\r\nКомпьютер" +
                " задумал 0834.\r\n\r\nИгрок сделал ход 8134.\r\n\r\nКомпьютер ответил:" +
                " 2 быка (цифры 3 и 4) и 1 корова (цифра 8).";
            rulesWindow.Show();
        }
    }
    
}
