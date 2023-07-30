
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using WpfApp1.Model;
using WpfApp1.ViewModel;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for AddTable.xaml
    /// </summary>
    public partial class AddTable : Window
    {
        static ObservableCollection<table> tables;
        public ICommand? add_table { get; set; }
        public AddTable()
        {
            InitializeComponent();
            DataContext = this;
            add_table = new RelayCommand(exe_add_table,canexe_add_table);
            string table_json = File.ReadAllText("C:\\Users\\Elgun\\Source\\Repos\\McDonalds\\WpfApp1\\JSON Files\\Tables.json");
            tables= JsonConvert.DeserializeObject<ObservableCollection<table>>(table_json);
            table_list.ItemsSource = tables;
        }

        public void exe_add_table(object? parameter)
        {
            if (IsNumeric(chair_count.Text))
            {
                tables.Add(new table(table_name.Text, chair_count.Text));
                string tables_json = JsonConvert.SerializeObject(tables);
                File.WriteAllText("C:\\Users\\Elgun\\Source\\Repos\\McDonalds\\WpfApp1\\JSON Files\\Tables.json", tables_json);
                Invalid.Text = null;
            }
            else 
            {
                Invalid.Foreground = Brushes.Red;
                Invalid.Text = "Invalid Input !";
            }
        }
        public bool canexe_add_table(object? parameter) 
        {
            if (table_name.Text != "" && chair_count.Text != "") { return true; }
            return false;
        }

        private bool IsNumeric(string text)
        {
            // Try parsing the text as a number
            return double.TryParse(text, out _);
        }
    }
}
