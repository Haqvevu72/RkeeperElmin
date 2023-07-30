using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    internal class table
    {
        public table(string? tableName, string chairNumber)
        {
            Orders = null;
            TableName = tableName;
            ChairNumber = chairNumber;
        }

        public string? TableName { get; set; }
        public string? ChairNumber { get; set; }
        public ObservableCollection<Order> Orders { get; set; } =new ObservableCollection<Order>();
    }
}
