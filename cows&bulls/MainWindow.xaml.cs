using System;
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
        public void NewGame()
        {
            listBox.Items.Clear();
            listBox.Items.Add("Введите четырехзначное число без повторяющихся цифр.");
        }
        public MainWindow()
        {
            InitializeComponent();
            NewGame();


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

        private void tryButton_Click(object sender, RoutedEventArgs e)
        {
            string attemp = tbox.Text;
            var bulls = 0; var cows = 0; var attemps = 0;
            if (attemp.Length == 4 && Int32.TryParse(attemp, out var number))
            {
                if (attemp == aim)
                {
                    MessageBox.Show($"Поздравляю! Вы победили!\nДля победы вам понадобилось {attemps} попыток!"); //congratsWindow.Show();
                    tbox.IsEnabled = false;
                }
                for (int i = 0; i < 4; i++)
                {
                    if (attemp[i] == aim[i]) bulls++;
                    if (attemp[i] != aim[i] && aim.Contains(attemp[i])) cows++;
                }
                listBox.Items.Add(attemp + $" - содержит {bulls} быков и {cows} коров.");
                attemps++;
            }
            else
            {
                MessageBox.Show("Введите четырехзначное число!");
                tbox.Text = "";
            }

        }

        private void newGameButton_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

        private void recordsButton_Click(object sender, RoutedEventArgs e)
        {
            RecordWindow recordWindow = new RecordWindow();
            var json = new DataContractJsonSerializer(typeof(List<Record>));
            using (FileStream fs = File.OpenRead("Score.json"))
            {
                List<Record> records = (List<Record>)json.ReadObject(fs);
                foreach (Record record in records)
                {

                }
            }
            recordWindow.Show();
            recordWindow.Show();
        }

        private void rulesButton_Click(object sender, RoutedEventArgs e)
        {
            RulesWindow rulesWindow = new RulesWindow();
            rulesWindow.rulesLabel.Content = "Правила игры\r\nКомпьютер задумывает четыре различные цифры" +
                " из 0,1,2,...9. Игрок делает\r\nходы, чтобы узнать эти цифры и их порядок.\r\n\r\nКаждый ход" +
                " состоит из четырёх цифр, 0 может стоять на первом месте.\r\n\r\nВ ответ компьютер" +
                " показывает число отгаданных цифр, стоящих на\r\nсвоих местах (число быков) и число" +
                " отгаданных цифр, стоящих не на\r\nсвоих местах (число коров).\r\n\r\nПример\r\nКомпьютер" +
                " задумал 0834.\r\n\r\nИгрок сделал ход 8134.\r\n\r\nКомпьютер ответил:" +
                " 2 быка (цифры 3 и 4) и 1 корова (цифра 8).";
            rulesWindow.Show();
        }
    }
    [Serializable]
    public class Record
    {
        public string name;
        public int score;
        public DateTime date;
        public Record(string name, int score, DateTime date)
        {
            this.name = name;
            this.score = score;
            this.date = date;
        }
    }
}
