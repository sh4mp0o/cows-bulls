﻿using System;
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

        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            RecordWindow recordWindow = new RecordWindow();
            recordWindow.Show();
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            RulesWindow rulesWindow = new RulesWindow();
            rulesWindow.Show();
        }
    }
}
