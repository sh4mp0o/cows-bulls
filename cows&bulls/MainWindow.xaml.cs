using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cows_bulls
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public void NewGame()
        {
            listBox.Items.Add("Введите четырехзначное число без повторяющихся цифр.");
        }
        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }

        private void tryButton_Click(object sender, RoutedEventArgs e)
        {

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
                " из 0,1,2,...9. Игрок делает\r\n ходы, чтобы узнать эти цифры и их порядок.\r\n\r\nКаждый ход" +
                " состоит из четырёх цифр, 0 может стоять на первом месте.\r\n\r\nВ ответ компьютер" +
                " показывает число отгаданных цифр, стоящих на\r\nсвоих местах (число быков) и число" +
                " отгаданных цифр, стоящих не на\r\nсвоих местах (число коров).\r\n\r\nПример\r\nКомпьютер" +
                " задумал 0834.\r\n\r\nИгрок сделал ход 8134.\r\n\r\nКомпьютер ответил:" +
                " 2 быка (цифры 3 и 4) и 1 корова (цифра 8).";
            rulesWindow.Show();
        }
    }
}
