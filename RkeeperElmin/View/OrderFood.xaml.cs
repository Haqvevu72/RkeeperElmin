using Newtonsoft.Json;
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
using WpfApp1.Model;
using System.IO;
using WpfApp1.ViewModel;
using WpfApp1.View.Pages;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for OrderFood.xaml
    /// </summary>
    public partial class OrderFood : Window
    {
        ObservableCollection<Food> Menu;
        internal ObservableCollection<Order> Order_List = new ObservableCollection<Order>();
        public ICommand _done { get; set; }
        public OrderFood()
        {
            InitializeComponent();
            DataContext = this;
            string foods_json = File.ReadAllText("C:\\Users\\Elgun\\Source\\Repos\\McDonalds\\WpfApp1\\JSON Files\\Foods.json");
            Menu = JsonConvert.DeserializeObject<ObservableCollection<Food>>(foods_json);
            menu.ItemsSource = Menu;
            order_schedule.ItemsSource = Order_List;
            _done = new RelayCommand(exe_done,canexe_done);
        }

        private void menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (menu.SelectedItem != null)
            {
                Food selectedItem = menu.SelectedItem as Food;
                Order_List.Add(new Order(selectedItem.FoodName, selectedItem.FoodCost));
            }
        }
        public void exe_done(object? paramter) 
        {
            this.Close();
        }
        public bool canexe_done(object? parameter) 
        {
            if (Order_List.Count!=0) { return true; }
            return false;
        }
    }
}
