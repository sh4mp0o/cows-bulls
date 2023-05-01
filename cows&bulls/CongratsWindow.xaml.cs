using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
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
using System.IO;

namespace cows_bulls
{
    /// <summary>
    /// Логика взаимодействия для CongratsWindow.xaml
    /// </summary>
    public partial class CongratsWindow : Window
    {
        public string name;
        public int count;
        public CongratsWindow(int count)
        {
            InitializeComponent();
            this.count = count;
        }

        private void nameButton_Click(object sender, RoutedEventArgs e)
        {
            this.name = nameTextBox.Text;
            Record record = new Record(name, count);
            var json = new DataContractJsonSerializer(typeof(List<Record>));
            using (FileStream fs = File.Open("Score.json", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {
                List<Record> records = (List<Record>)json.ReadObject(fs);
                records.Add(record);
                records.Sort();
                json.WriteObject(fs, records);
            }
            this.Close();
        }
    }
    
}
