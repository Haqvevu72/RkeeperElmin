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
using WpfApp1.ViewModel;
using System.IO;
using System.Configuration;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Threading;
using WpfApp1.View.Pages;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public ICommand? _login { get; set; }
        public ICommand? _register { get; set; }
        static ObservableCollection<User> _users;


        public LogIn()
        {
            InitializeComponent();
            DataContext = this;
            _login = new RelayCommand(exe_log, can_exe_log);
            _register = new RelayCommand(exe_reg, can_exe_log);
            string txt_users = File.ReadAllText("C:\\Users\\Elgun\\Desktop\\McDonalds\\WpfApp1\\JSON Files\\Users.json");
            _users = JsonConvert.DeserializeObject<ObservableCollection<User>>(txt_users);
        }

        public void exe_log(object? parameter)
        {

            for (int i = 0; i < _users.Count; i++)
            {
                if (Username.Text == _users[i].Username && Password.Password == _users[i].Password)
                {
                    if (Username.Text == "admin" && Password.Password == "admin") LogInFrame.Navigate(new AdminTable());
                    else LogInFrame.Navigate(new WaiterTable()); 
                    break;
                }
                situation.Foreground = Brushes.Red;
                situation.Text = "Access Denied !";
            }
        }
        public void exe_reg(object? parameter)
        {
            bool exist = false;
            for (int i = 0; i < _users.Count; i++)
            {
                if (Username.Text == _users[i].Username && Password.Password == _users[i].Password)
                {
                    exist = true;
                    break;
                }
                
            }
            if (exist == false)
            {
                _users.Add(new User(Username.Text, Password.Password));
                string txt_reg = JsonConvert.SerializeObject(_users);
                File.WriteAllText("C:\\Users\\Elgun\\Source\\Repos\\McDonalds\\WpfApp1\\JSON Files\\Users.json", txt_reg);
                situation.Foreground = Brushes.ForestGreen;
                situation.Text = "Register Successful !";
            }
            else
            {
                situation.Foreground = Brushes.Red;
                situation.Text = "Register Denied !";
            }
        }
        public bool can_exe_log(object? parameter)
        {
            if (Username.Text != "" && Password.Password != "") { return true; }
            return false;
        }
    }
}
