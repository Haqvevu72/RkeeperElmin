using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    internal class Food
    {
        public Food(string? foodName, int foodCost, string? foodImage)
        {
            FoodName = foodName;
            FoodCost = foodCost;
            FoodImage = foodImage;
        }

        public string? FoodName { get; set; }
        public int FoodCost { get; set; }
        public string? FoodImage { get; set; }
    }
}
