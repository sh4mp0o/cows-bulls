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
using System.Windows.Shapes;

namespace cows_bulls
{
    /// <summary>
    /// Логика взаимодействия для CongratsWindow.xaml
    /// </summary>
    public partial class CongratsWindow : Window
    {
        public CongratsWindow()
        {
            InitializeComponent();
        }

        private void nameButton_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTextBox.Text;
        }
    }
}
