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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Model;
using System.IO;
using Newtonsoft.Json;
using WpfApp1.ViewModel;
using System.Reflection;

namespace WpfApp1.View.Pages
{
    /// <summary>
    /// Interaction logic for WaiterTable.xaml
    /// </summary>
    public partial class WaiterTable : Page
    {
        ObservableCollection<table> tables { get; set; }
        public ICommand _order { get; set; }
        public ICommand _reset { get; set; }
        public WaiterTable()
        {
            InitializeComponent();
            DataContext = this;
            string table_json = File.ReadAllText("C:\\Users\\Elgun\\Source\\Repos\\McDonalds\\WpfApp1\\JSON Files\\Tables.json");
            tables = JsonConvert.DeserializeObject<ObservableCollection<table>>(table_json);
            _tables.ItemsSource = tables;
            _order = new RelayCommand(exe_order, canexe_order);
            _reset = new RelayCommand(exe_reset,can_exe_reset);
        }
        public void exe_order(object? parameter)
        {
            OrderFood orderFood = new OrderFood();
            table selecteditem = _tables.SelectedItem as table;
            selecteditem.Orders = orderFood.Order_List;
            order_schedule.ItemsSource = selecteditem.Orders;
            orderFood.ShowDialog();
        }
        public bool canexe_order(object? parameter)
        {
            if (_tables.SelectedItem != null) { return true; }
            return false;
        }

        private void _tables_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            table selecteditem = _tables.SelectedItem as table;
            order_schedule.ItemsSource = selecteditem.Orders;
        }

        public void exe_reset(object? parameter) {
            table selecteditem = _tables.SelectedItem as table;
            selecteditem.Orders = null;
            order_schedule.ItemsSource = selecteditem.Orders;

        }
        public bool can_exe_reset(object? parameter) {

            if ( order_schedule.ItemsSource!=null) { return true; }
            return false;
        }
    }
}
