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
using WpfApp1.ViewModel;

namespace WpfApp1.View.Pages
{
    public partial class AdminTable : Page
    {
        
        public AdminTable()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void AddTable_Click(object sender, RoutedEventArgs e)
        {
            AddTable addTable = new AddTable();
            addTable.ShowDialog();
        }

        private void AddFood_Click(object sender, RoutedEventArgs e)
        {
            AddFood addFood = new AddFood();
            addFood.ShowDialog();
        }
    }
}
