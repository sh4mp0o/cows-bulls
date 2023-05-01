using System;
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
            var rand = new Random();
            int num;
            bool[] used = new bool[10];
            bool isUnique = true;
            do
            {
                // сгенерировать случайное четырехзначное число
                num = rand.Next(0, 10000);

                // проверить, что все цифры числа уникальны и первая цифра не равна 0
                Array.Clear(used, 0, used.Length);
                foreach (char c in num.ToString())
                {
                    int digit = c - '0';
                    if (used[digit] || (digit == 0 && c != '0'))
                    {
                        isUnique = false;
                        break;
                    }
                    used[digit] = true;
                }
            } while (!isUnique);
            aim = Convert.ToString(num);
        }

        private void tryButton_Click(object sender, RoutedEventArgs e)
        {
            string attemp = tbox.Text;
            if (attemp.Length == 4 && Int32.TryParse(attemp, out var number))
            {

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
}
