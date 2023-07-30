using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    internal class Order
    {
        public Order(string? food_name, int food_cost)
        {
            this.food_name = food_name;
            this.food_cost = food_cost;
            food_count+=1;
        }

        public string? food_name { get; set; }
        public int food_cost { get; set; }
        public int food_count { get; set; } = 0;
    }
}
